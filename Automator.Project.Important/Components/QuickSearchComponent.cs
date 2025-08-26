using Automator.Project.Important.Common.Component;
using Automator.Project.Important.Domain.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automator.Project.Important.Components
{
    /// <summary>
    /// Quick Search Component
    /// </summary>
    public class QuickSearchComponent : ComponentBase
    {
        #region Constructor
        /// <summary>
        /// Quick Search Component Constructor
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="action">Actions</param>
        /// <param name="waitDrive">Web Driver Wait</param>
        public QuickSearchComponent(IWebDriver driver, Actions action, WebDriverWait waitDrive)
            : base(driver, action, waitDrive)
        {
            _quickSeachPage = new();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Quick Seach Page
        /// </summary>
        private readonly QuickSeachPage _quickSeachPage;
        #endregion

        #region GetElementsListHours
        /// <summary>
        /// <c>GetElementsListTypePrice</c> Get Elements List Type Price - Element value
        /// </summary>
        /// <param name="hours">Price type</param>
        /// <param name="locator">Locator</param>
        private void GetElementsListHours(string hours, By locator)
        {
            List<IWebElement> elementsOptions = Driver.FindElements(locator).ToList();
            IWebElement elements = elementsOptions.Where(x => x.GetAttribute("data-time").Equals(hours)).FirstOrDefault()
                ?? throw new Exception();

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView();", elements);
            executor.ExecuteScript("arguments[0].click();", elements);
        }
        #endregion

        #region SetLocationPickUp
        /// <summary>
        /// Write Location
        /// </summary>
        /// <param name="location">Location</param>
        /// <param name="nameLocation">Location name</param>
        public void SetLocationPickUp(string location, string nameLocation)
        {
            WaitAndClickElement(_quickSeachPage.LocationPickUp);
            WaitAndClickElement(_quickSeachPage.CancelPickUp);
            WaitAndClickElement(_quickSeachPage.LocationPickUp);
            SetTextAfterWaiting(_quickSeachPage.LocationPickUp, location);
            WaitElement(_quickSeachPage.LoadingGroupAutocomplete);
            GetTextOfListElements(nameLocation, _quickSeachPage.AutocompleteLocationPickUp);
        }
        #endregion

        #region ClickButtonSearchCar
        /// <summary>
        /// Click Button SearchCar
        /// </summary>
        public void ClickButtonSearchCar()
        {
            WaitAndClickElement(_quickSeachPage.ButtonSearchCar);
            Thread.Sleep(2000);
        }
        #endregion

        #region AsignPickUpDateInitial
        /// <summary>
        /// Press PickUp Date Initial
        /// </summary>
        /// <param name="dayStart">Start day</param>
        public void AsignPickUpDateInitial(int dayStart)
        {
            WaitElement(_quickSeachPage.DatePickUp);
            SelectStartDate(dayStart);
        }
        #endregion

        #region AsignPickUpDateFinally
        /// <summary>
        /// Press PickUp Date Finally
        /// </summary>
        /// <param name="dayEnd">End day</param>
        public void AsignPickUpDateFinally(int dayEnd)
            => SelectEndDate(dayEnd);
        #endregion

        #region AsignHourPickUp
        /// <summary>
        /// Asign Hour PickUp
        /// </summary>
        /// <param name="hourPickUp"></param>
        public void AsignHourPickUp(string hourPickUp)
        {
            WaitAndClickElement(_quickSeachPage.HourPickUp);       
            GetElementsListHours(hourPickUp, _quickSeachPage.ComboBoxListHours);        }
        #endregion

        #region AsignHourReturn
        /// <summary>
        /// Asign Hour Return
        /// </summary>
        /// <param name="hourReturn"></param>
        public void AsignHourReturn(string hourReturn)
        {
            WaitAndClickElement(_quickSeachPage.HourReturn);
            GetElementsListHours(hourReturn, _quickSeachPage.ComboBoxListHours);
        }
        #endregion
    }
}
