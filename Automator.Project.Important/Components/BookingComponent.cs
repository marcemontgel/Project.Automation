using Automator.Project.Important.Common.Component;
using Automator.Project.Important.Domain.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automator.Project.Important.Components
{
    public class BookingComponent : ComponentBase
    {
        public BookingComponent(IWebDriver driver, Actions action, WebDriverWait waitDrive) 
            : base(driver, action, waitDrive)
        {
            _bookinPage = new();
        }

        private readonly BookingPage _bookinPage;
    }
}
