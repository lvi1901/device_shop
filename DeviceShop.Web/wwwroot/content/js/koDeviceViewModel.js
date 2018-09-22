var DeviceViewModel = function (options) {
    var self = this;

    var firstPage = 1,
        maxPageCount = 9;

    self.pageSize = ko.observable(options.PageSize);
    self.currentPage = ko.observable(firstPage);
    self.pageData = ko.observableArray();
    self.devices = ko.observableArray([]);

    ko.computed(function () {
        var start = self.pageSize() * (self.currentPage() - 1),
            end = start + self.pageSize();

        self.pageData(self.devices.slice(start, end));
    }, self);

    self.pageCount = function () {
        if (self.pageSize() !== 0) {
            return Math.ceil(self.devices().length / self.pageSize());
        } else {
            return 0;
        }
    };

    self.generateAllPages = function () {
        var pages = [];
        for (var i = firstPage; i <= self.pageCount(); i++) {
            pages.push(i);
        }
        return pages;
    };

    self.generateMaxPage = function () {
        var sectionLength = parseInt((maxPageCount - 1) / 2),
            upperLimit = self.currentPage() + sectionLength;
        downLimit = self.currentPage() - sectionLength;

        while (upperLimit > self.pageCount()) {
            upperLimit--;
            if (downLimit > firstPage) {
                downLimit--;
            }
        }

        while (downLimit < firstPage) {
            downLimit++;
            if (upperLimit < self.pageCount()) {
                upperLimit++;
            }
        }

        var pages = [];
        for (var i = downLimit; i <= upperLimit; i++) {
            pages.push(i);
        }
        return pages;
    };

    self.getPages = ko.pureComputed(function () {
        if (self.pageCount() <= maxPageCount)
            return ko.observableArray(self.generateAllPages());
        else
            return ko.observableArray(self.generateMaxPage());
    });

    self.setCurrentPage = function (page) {
        self.currentPage(page);
    };

    // Next button
    self.hasNextPage = ko.pureComputed(function () {
        return self.getNextPage() != null;
    });

    self.getNextPage = ko.pureComputed(function () {
        var next = self.currentPage() + 1;
        if (next > self.pageCount()) {
            return null;
        }
        return next;
    });

    self.setNextPage = function () {
        var next = self.getNextPage();
        if (next != null) {
            self.setCurrentPage(next);
        }
    };

    // Previous button
    self.hasPreviousPage = ko.pureComputed(function () {
        return self.getPreviousPage() != null;
    });

    self.getPreviousPage = ko.pureComputed(function () {
        var previous = self.currentPage() - 1;
        if (previous < firstPage) {
            return null;
        }
        return previous;
    });

    self.setPreviousPage = function () {
        var previous = self.getPreviousPage();
        if (previous != null) {
            self.setCurrentPage(previous);
        }
    };

    var getDevices = function () {
        $.ajax({
            url: "http://localhost:64323/Device/" + options.RequestUrl,
            type: "GET",
            dataType: "json",
            contentType: "application/json;utf-8"
        }).done(function (resp) {
            self.devices(resp);
        }).fail(function (err) {
            alert("Error!! " + err.status + "  " + err.statusText);
        });
    }
    getDevices();
};

$(document).ready(function () {
    var options = JSON.parse($("#devices").attr("data-value"));
    ko.applyBindings(new DeviceViewModel(options));
});
