using Automator.Project.Important.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.StepDefinitions
{
    /// <summary>
    /// QuickSearch Step Definition
    /// </summary>
    [Binding]
    public class QuickSearchStepDefinition
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of scenario context <see cref="ScenarioContext"/> class.
        /// </summary>
        public QuickSearchStepDefinition(ScenarioContext scenarioContext)
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
        /// Change Language
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Write location (.*) and select location (.+)")]
        public void SetLocationPickUp(string location, string nameLocation)
            => _homePage.QuickSearch.SetLocationPickUp(location, nameLocation);
        #endregion

        //
        #region ClickButtonSearchCar
        /// <summary>
        /// Change Language
        /// </summary>
        /// <param name="lang">Language</param>
        [When(@"Click Button SearchCar")]
        public void ClickButtonSearchCar()
            => _homePage.QuickSearch.ClickButtonSearchCar();
        #endregion

        #region AsignPickUpDateInitial
        /// <summary>
        /// AsignPickUpDateInitial
        /// </summary>
        /// <param name="dayStart">Start day</param>
        [When(@"Select Pick-Up Date (.+)")]
        public void AsignPickUpDateInitial(int dayStart)
            => _homePage.QuickSearch.AsignPickUpDateInitial(dayStart);
        #endregion

        #region PressPickUpDateFinally
        /// <summary>
        /// Select Drop-off Date
        /// </summary>
        /// <param name="dayEnd">End day</param>
        [When(@"Select Drop-off Date (.+)")]
        public void AsignPickUpDateFinally(int dayEnd)
            => _homePage.QuickSearch.AsignPickUpDateFinally(dayEnd);
        #endregion

        #region AsignHourPickUp
        /// <summary>
        /// Asign Hour PickUp
        /// </summary>
        /// <param name="dayEnd">End day</param>
        [When(@"Select Hour PickUp (.+)")]
        public void AsignHourPickUp(string hourPickUp)
            => _homePage.QuickSearch.AsignHourPickUp(hourPickUp);
        #endregion

        #region AsignHourReturn
        /// <summary>
        /// Asign Hour Return
        /// </summary>
        /// <param name="dayEnd">End day</param>
        [When(@"Asign Hour Return (.+)")]
        public void AsignHourReturn(string hourReturn)
            => _homePage.QuickSearch.AsignHourReturn(hourReturn);
        #endregion
    }
}
