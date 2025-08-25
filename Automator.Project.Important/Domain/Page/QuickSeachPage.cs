using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class QuickSeachPage
    {
        public By LocationPickUp
            => By.Id("pickup_location");

        public By CancelPickUp
            => By.XPath("//*[@class='searchbar__location pickup-location']//*[@class='dropdown__clear-icon']");

        public By LoadingGroupAutocomplete
            => By.XPath("//*[@class='searchbar__location pickup-location']//*[@class='dropdown__select']");

        public By AutocompleteLocationPickUp
            => By.XPath("//*[@class='searchbar__location pickup-location']//*[@class='dropdown__select-option']/text()");

        public By ButtonSearchCar
            => By.XPath("//*[@aria-label='search car']");

        public By DatePickUp
            => By.Id("start");

        public By HourPickUp
            => By.Id("t1v");

        public By HourReturn
            => By.Id("tv");

        public By ComboBoxListHours            
            => By.XPath("//*[@class='ui-menu-item']//*[@data-time]");
    }
}
