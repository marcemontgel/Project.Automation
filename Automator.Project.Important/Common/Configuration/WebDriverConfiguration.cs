using Automator.Project.Important.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.Common.Configuration
{
    /// <summary>
    /// The web driver configuration class used by configuration provider and the hook.
    /// </summary>
    public class WebDriverConfiguration
    {
        /// <summary>
        /// Gets or sets the browser name to use in driver configuration.
        /// </summary>
        public BrowserName BrowserName { get; set; }

        /// <summary>
        /// Gets or sets the browser language to use in browser options.
        /// </summary>
        public string? BrowserLanguage { get; set; }
    }
}
