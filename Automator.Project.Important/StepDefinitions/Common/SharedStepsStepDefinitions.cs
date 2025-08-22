using Automator.Project.Important.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.StepDefinitions.Common
{
    /// <summary>
    /// The shared step definitions.
    /// </summary>
    [Binding]
    public class SharedStepsStepDefinitions
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of scenario context <see cref="SharedStepsStepDefinitions"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public SharedStepsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The scenario context.
        /// </summary>
        private readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Home
        /// </summary>
        private readonly HomePage _homePage = new();
        #endregion

        #region GivenSharedStepsContext
        /// <summary>
        /// Givens the shared steps context.
        /// </summary>
        [Given(@"Shared steps context")]
        public static void GivenSharedStepsContext()
            => Console.WriteLine("Init Shared Steps");
        #endregion

        #region GivenNavigateToTheWebsiteHomePage
        /// <summary>
        /// Navigate to the home page.
        /// </summary>
        /// <param name="url">Url</param>
        [Given(@"Navigate to the website home page (.+)")]
        public void GivenNavigateToTheWebsiteHomePage(string url)
            => _homePage.NavigateToUrl(url);
        #endregion
    }
}
