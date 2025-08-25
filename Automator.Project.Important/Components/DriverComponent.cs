using Automator.Project.Important.Common.Component;
using Automator.Project.Important.Domain.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automator.Project.Important.Components
{
    public class DriverComponent : ComponentBase
    {
        /// <summary>
        /// Constructor Booking Component
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="action"></param>
        /// <param name="waitDrive"></param>
        public DriverComponent(IWebDriver driver, Actions action, WebDriverWait waitDrive) 
            : base(driver, action, waitDrive)
        {
            _bookinPage = new();
        }

        /// <summary>
        /// Properties Booking Page
        /// </summary>
        private readonly DriverPage _bookinPage;

        public void SetFullNameToReservation(string name)
        => WaitAndSetText(_bookinPage.InputNameCostumer, name);

        public void SetPhoneToReservation(string phone)
        => WaitAndSetText(_bookinPage.InputTelephoneCostumer, phone);         
        
        public void SetEmailToReservation(string email)
        => WaitAndSetText(_bookinPage.InputEmailCostumer, email);

        public void PressButtonReserverNow()
            => WaitAndClickElement(_bookinPage.ButtonReservationNow);
    }
}
