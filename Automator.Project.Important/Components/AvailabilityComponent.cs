using Automator.Project.Important.Common.Component;
using Automator.Project.Important.Domain.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automator.Project.Important.Components
{
    public class AvailabilityComponent : ComponentBase
    {
        #region Constructor
        /// <summary>
        /// Availability Component Constructor
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="action"></param>
        /// <param name="waitDrive"></param>
        public AvailabilityComponent(IWebDriver driver, Actions action, WebDriverWait waitDrive)
            : base(driver, action, waitDrive)
        {
            _availabilityPage = new();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Availability Page Properties
        /// </summary>
        private readonly AvailabilityPage _availabilityPage;
        #endregion

        #region SelectVehicle
        /// <summary>
        /// Select Vehicle
        /// </summary>
        public void SelectVehicle()
        => WaitAndClickElement(_availabilityPage.ButtonSelectCar);
        #endregion
    }
}
