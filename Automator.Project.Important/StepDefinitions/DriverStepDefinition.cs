using Automator.Project.Important.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.StepDefinitions
{
    [Binding]
    public class DriverStepDefinition
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of scenario context <see cref="ScenarioContext"/> class.
        /// </summary>
        public DriverStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Home Page
        /// </summary>
        readonly HomePage _homePage = new();

        /// <summary>
        /// Context Scenario
        /// </summary>
        readonly ScenarioContext _scenarioContext;
        #endregion

        #region SetFullNameToReservation
        /// <summary>
        /// Add Name
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Add Name (.*)")]
        public void SetFullNameToReservation(string name)
            => _homePage.Booking.SetFullNameToReservation(name);
        #endregion

        #region SetPhoneToReservation
        /// <summary>
        /// Add Telephone
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Add Telephone (.*)")]
        public void SetPhoneToReservation(string phone)
            => _homePage.Booking.SetPhoneToReservation(phone);
        #endregion

        #region SetEmailToReservation
        /// <summary>
        /// Add Telephone
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Add Email (.*)")]
        public void SetEmailToReservation(string email)
            => _homePage.Booking.SetEmailToReservation(email);
        #endregion

        #region PressButtonReserverNow
        /// <summary>
        /// Add Telephone
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Click Button Reserve Now")]
        public void PressButtonReserverNow()
            => _homePage.Booking.PressButtonReserverNow();
        #endregion
    }
}
