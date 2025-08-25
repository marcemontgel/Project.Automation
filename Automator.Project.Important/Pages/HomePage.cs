using Automator.Project.Important.Common.Page;
using Automator.Project.Important.Components;
using Automator.Project.Important.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.Pages
{
    public class HomePage : PageBase
    {
        #region Constructor
        /// <summary>
        /// Home Page Constructor
        /// </summary>
        public HomePage()
        {
            QuickSearch = new(Driver, Action, Wait);
            Availability = new(Driver, Action, Wait);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Quick Search Component
        /// </summary>
        public QuickSearchComponent QuickSearch { get; private set; }

        /// <summary>
        /// Availability Component
        /// </summary>
        public AvailabilityComponent Availability { get; private set; }
        #endregion

        #region NavigateToUrl
        /// <summary>
        /// Gets the home page url.
        /// </summary>
        //private static Uri HomePageUrl => new Uri(ConfigurationProvider.Env.ApplicationUrl);
        internal void NavigateToUrl(string url)
            => Driver.Navigate().GoToUrl(url);
        #endregion
    }
}
