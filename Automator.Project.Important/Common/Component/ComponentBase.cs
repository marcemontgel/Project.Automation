using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Automator.Project.Important.Common.Component
{
    /// <summary>
    /// Component Base
    /// </summary>
    public class ComponentBase : BaseElement
    {
        #region Constructor
        /// <summary>
        /// Component Base Constructor
        /// </summary>
        /// <param name="driver">Web Driver</param>
        /// <param name="action">Actions</param>
        /// <param name="waitDrive">Web Driver Wait</param>
        public ComponentBase(IWebDriver driver, Actions action, WebDriverWait waitDrive)
            : base(driver, action, waitDrive) { }
        #endregion
    }
}
