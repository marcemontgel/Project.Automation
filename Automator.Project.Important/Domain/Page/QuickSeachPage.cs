using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class QuickSeachPage
    {
        /// <summary>
        /// Location PickUp
        /// </summary>
        public By LocationPickUp
            => By.Id("pickup_location");

        /// <summary>
        /// Cancel PickUp
        /// </summary>
        public By CancelPickUp
            => By.XPath("//*[@class='searchbar__location pickup-location']//*[@class='dropdown__clear-icon']");

        /// <summary>
        /// Loading Group Autocomplete
        /// </summary>
        public By LoadingGroupAutocomplete
            => By.XPath("//*[@class='searchbar__location pickup-location']//*[@class='dropdown__select']");

        /// <summary>
        /// Autocomplete Location PickUp
        /// </summary>
        public By AutocompleteLocationPickUp
            => By.XPath("//*[@class='searchbar__location pickup-location']//*[@class='dropdown__select-option']/text()");

        /// <summary>
        /// Button Search Car
        /// </summary>
        public By ButtonSearchCar
            => By.XPath("//*[@aria-label='search car']");

        /// <summary>
        /// Date PickUp
        /// </summary>
        public By DatePickUp
            => By.Id("start");

        /// <summary>
        /// Hour PickUp
        /// </summary>
        public By HourPickUp
            => By.Id("t1v");

        /// <summary>
        /// Hour Return
        /// </summary>
        public By HourReturn
            => By.Id("tv");

        /// <summary>
        /// ComboBox List Hours
        /// </summary>
        public By ComboBoxListHours            
            => By.XPath("//*[@class='ui-menu-item']//*[@data-time]");
    }
}
