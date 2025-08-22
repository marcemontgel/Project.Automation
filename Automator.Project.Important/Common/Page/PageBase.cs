using Automator.Project.Important.Hooks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Automator.Project.Important.Common.Page
{
    /// <summary>
    /// Base page for Selenium
    /// </summary>
    public class PageBase : BaseElement
    {
        #region Constructor
        /// <summary>
        /// Page Base Constructor
        /// </summary>
        public PageBase()
            : base(
                 SeleniumDriver._driver,
                 new Actions(SeleniumDriver._driver),
                 new WebDriverWait(SeleniumDriver._driver, TimeSpan.FromSeconds(60)))
        { }
        #endregion
    }
}
