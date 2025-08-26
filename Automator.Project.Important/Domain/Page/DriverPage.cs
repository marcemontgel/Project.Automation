using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class DriverPage
    {
        /// <summary>
        /// Input Name Costumer
        /// </summary>
        public By InputNameCostumer
            => By.Id("client_name");

        /// <summary>
        /// Input Telephone Costumer
        /// </summary>
        public By InputTelephoneCostumer
            => By.XPath("//*[@id='phone_fold']//*[@class='form-field__form-input']");

        /// <summary>
        /// Input Email Costumer
        /// </summary>
        public By InputEmailCostumer
            => By.Id("client_email");

        /// <summary>
        /// Button Reservation Now
        /// </summary>
        public By ButtonReservationNow
            => By.XPath("//*[@class='transaction__inner']//button");
    }
}
