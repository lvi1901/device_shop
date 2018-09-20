using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System;
using DeviceShop.Core.Entities;

namespace DeviceShop.Core.Infrastructure
{
    public static class DbInitializer
    {
        public static void Execute(AppDbContext context)
        {
            if (context.Devices.Count() == 0)
            {
                var smartphones = GetCategoryDevices(9355, out Guid smartphoneCategoryId);
                context.Add(new CategoryItem
                {
                    Id = smartphoneCategoryId,
                    Name = "Smartphones",
                    Devices = smartphones
                });
                context.AddRange(smartphones);

                var tablets = GetCategoryDevices(171485, out Guid tabletCategoryId);
                context.Add(new CategoryItem
                {
                    Id = tabletCategoryId,
                    Name = "Tablets",
                    Devices = tablets
                });
                context.AddRange(tablets);

                var laptops = GetCategoryDevices(177, out Guid laptopCategoryId);
                context.Add(new CategoryItem
                {
                    Id = laptopCategoryId,
                    Name = "Laptops",
                    Devices = laptops
                });
                context.AddRange(laptops);

                context.SaveChanges();
            }
        }

        private static List<ItemDetailsDto> GetEBayItemsByCategory(long categoryId, int itemsLimit = 100)
        {
            var itemDetailsList = new List<ItemDetailsDto>();
            const string APP_ID = "ViliCode-ViliDev-PRD-866850dff-64c4cdb2";

            var findItemsRequest = SendRequest($"https://svcs.ebay.com/services/search/FindingService/v1?SECURITY-APPNAME={APP_ID}&OPERATION-NAME=findItemsByCategory&categoryId={categoryId}&SERVICE-VERSION=1.0.0&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&GLOBAL-ID=EBAY-US&siteid=0&paginationInput.entriesPerPage={itemsLimit}&itemFilter.name=HideDuplicateItems&itemFilter.value=true");
            var items = JObject.Parse(findItemsRequest)["findItemsByCategoryResponse"][0]["searchResult"][0]["item"].ToObject<List<ItemIdentityDto>>();

            var itemIds = items.Select(item => item.ItemId[0].ToString());
            const int STEP = 20;
            var i = 0;
            bool flag = true;
            while (true)
            {
                var subItemIds = itemIds.Skip(STEP * i).Take(STEP);
                if (subItemIds.Count() == 0)
                {
                    break;
                }
                var getMultipleItemsRequest = SendRequest($"http://open.api.ebay.com/shopping?callname=GetMultipleItems&responseencoding=JSON&appid={APP_ID}&siteid=0&version=967&ItemID={string.Join(",", subItemIds)}&IncludeSelector=TextDescription");
                var itemsDetails = JObject.Parse(getMultipleItemsRequest)["Item"].ToObject<List<ItemDetailsDto>>();
                if (flag)
                {
                    itemsDetails.ForEach(item => item.IsPopular = true);
                    flag = false;
                }

                itemDetailsList.AddRange(itemsDetails);
                i++;
            }

            return itemDetailsList;
        }

        private static List<DeviceItem> GetCategoryDevices(int eBayCategoryId, out Guid categoryId)
        {
            var eBayItems = GetEBayItemsByCategory(eBayCategoryId);
            var categoryDevices = new List<DeviceItem>();
            categoryId = Guid.NewGuid();

            foreach (var item in eBayItems)
            {
                categoryDevices.Add(new DeviceItem
                {
                    Id = Guid.NewGuid(),
                    Name = item.Title,
                    Description = item.Description,
                    CategoryId = categoryId,
                    ImageUrl = item.PictureUrls.FirstOrDefault(),
                    Price = item.ConvertedCurrentPrice.Value,
                    Currency = item.ConvertedCurrentPrice.Currency,
                    IsPopular = item.IsPopular
                });
            }

            return categoryDevices;
        }

        private static string SendRequest(string url)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            using (var response = httpRequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private class ItemIdentityDto
        {
            [JsonProperty("itemId", Required = Required.Always)]
            public long[] ItemId { get; set; }
        }

        private class ItemDetailsDto
        {
            [JsonProperty("Title", Required = Required.Always)]
            public string Title { get; set; }

            [JsonProperty("Description", Required = Required.Default)]
            public string Description { get; set; }

            [JsonProperty("PictureURL", Required = Required.Always)]
            public string[] PictureUrls { get; set; }

            [JsonProperty("ConvertedCurrentPrice", Required = Required.Always)]
            public ConvertedCurrentPriceData ConvertedCurrentPrice { get; set; }

            [JsonIgnore]
            public bool IsPopular { get; set; }

            internal class ConvertedCurrentPriceData
            {
                [JsonProperty("Value", Required = Required.Always)]
                public decimal Value { get; set; }

                [JsonProperty("CurrencyID", Required = Required.Always)]
                public string Currency { get; set; }
            }
        }
    }
}
