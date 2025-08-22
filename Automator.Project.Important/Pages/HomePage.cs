using Automator.Project.Important.Common.Page;
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

        }
        #endregion

        #region Properties


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
