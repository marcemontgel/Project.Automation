using Automator.Project.Important.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.StepDefinitions
{
    [Binding]
    public class BookingStepDefinition
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of scenario context <see cref="ScenarioContext"/> class.
        /// </summary>
        public BookingStepDefinition(ScenarioContext scenarioContext)
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
    }
}
