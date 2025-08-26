using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class AvailabilityPage
    {
        /// <summary>
        /// Button Select Car
        /// </summary>
        public By ButtonSelectCar
            => By.XPath("(//*[@id='availability-to-details'])[1]");
    }
}
