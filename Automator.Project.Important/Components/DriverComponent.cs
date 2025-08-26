using Automator.Project.Important.Common.Component;
using Automator.Project.Important.Domain.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automator.Project.Important.Components
{
    public class DriverComponent : ComponentBase
    {
        #region Constructor
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
        #endregion

        #region Properties
        /// <summary>
        /// Properties Booking Page
        /// </summary>
        private readonly DriverPage _bookinPage;
        #endregion

        #region SetFullNameToReservation
        /// <summary>
        /// Set Full Name To Reservation
        /// </summary>
        /// <param name="name"></param>
        public void SetFullNameToReservation(string name)
        => WaitAndSetText(_bookinPage.InputNameCostumer, name);
        #endregion

        #region SetPhoneToReservation
        /// <summary>
        /// Set Phone To Reservation
        /// </summary>
        /// <param name="phone"></param>
        public void SetPhoneToReservation(string phone)
        => WaitAndSetText(_bookinPage.InputTelephoneCostumer, phone);
        #endregion

        #region SetEmailToReservation
        /// <summary>
        /// Set Email To Reservation
        /// </summary>
        /// <param name="email"></param>
        public void SetEmailToReservation(string email)
        => WaitAndSetText(_bookinPage.InputEmailCostumer, email);
        #endregion

        #region PressButtonReserverNow
        /// <summary>
        /// Press Button Reserver Now
        /// </summary>
        public void PressButtonReserverNow()
            => WaitAndClickElement(_bookinPage.ButtonReservationNow);
        #endregion
    }
}
