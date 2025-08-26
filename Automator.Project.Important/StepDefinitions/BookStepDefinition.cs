using Automator.Project.Important.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.StepDefinitions
{

    [Binding]
    public class BookStepDefinition
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of scenario context <see cref="ScenarioContext"/> class.
        /// </summary>
        public BookStepDefinition(ScenarioContext scenarioContext)
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

        #region SetLocationPickUp
        /// <summary>
        /// SetCreditCard
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Write Credit Card (.*)")]
        public void SetCreditCard(string creditCard)
            => _homePage.Booking.SetCreditCard(creditCard);
        #endregion

        #region SetLocationPickUp
        /// <summary>
        /// SetCreditCard
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Write Date Expiration MMYY (.*)")]
        public void SetDateExpiration(string dateExp)
            => _homePage.Booking.SetDateExpiration(dateExp);
        #endregion

        #region SetLocationPickUp
        /// <summary>
        /// SetCreditCard
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Write CVV (.*)")]
        public void SetCodeVerification(string cvv)
            => _homePage.Booking.SetCodeVerification(cvv);
        #endregion

        #region ClickButtonPayNow
        /// <summary>
        /// SetCreditCard
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Click Button Pay Now")]
        public void ClickButtonPayNow()
            => _homePage.Booking.ClickButtonPayNow();
        #endregion
    }
}
