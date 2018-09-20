using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DeviceShop.Web.ViewModels;

namespace DeviceShop.Web.Components
{
    public class DevicesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DevicesViewComponentModel devicesViewModel) =>
            View(await GetStringAsync(devicesViewModel));

        private Task<DevicesViewComponentModel> GetStringAsync(DevicesViewComponentModel devicesViewModel) =>
            Task.Run(() => devicesViewModel);
    }
}
