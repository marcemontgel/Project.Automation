using Automator.Project.Important.Common.Component;
using Automator.Project.Important.Domain.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator.Project.Important.Components
{
    public class BookComponent : ComponentBase
    {
        #region Constructor
        /// <summary>
        /// Constructor Book Component
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="action"></param>
        /// <param name="waitDrive"></param>
        public BookComponent(IWebDriver driver, Actions action, WebDriverWait waitDrive)
            : base(driver, action, waitDrive)
        {
            _bookPage = new();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Properties Book Page
        /// </summary>
        private readonly BookPage _bookPage;
        #endregion

        #region SetCreditCard
        /// <summary>
        /// Set Credit Card
        /// </summary>
        /// <param name="creditCard"></param>
        public void SetCreditCard(string creditCard)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
            WaitElementClickeable(_bookPage.InputCreditCard);
            SetTextAfterWaiting(_bookPage.InputCreditCard, creditCard);
            Driver.SwitchTo().DefaultContent();
        }
        #endregion

        #region SetDateExpiration
        /// <summary>
        /// Set Date Expiration
        /// </summary>
        /// <param name="dateExp"></param>
        public void SetDateExpiration(string dateExp)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
            WaitElementClickeable(_bookPage.InputExpiry);
            SetTextAfterWaiting(_bookPage.InputExpiry, dateExp);
            Driver.SwitchTo().DefaultContent();
        }
        #endregion

        #region SetCodeVerification
        /// <summary>
        /// Set Code Verification
        /// </summary>
        /// <param name="cvv"></param>
        public void SetCodeVerification(string cvv)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
            WaitElementClickeable(_bookPage.InputCodeVerification);
            SetTextAfterWaiting(_bookPage.InputCodeVerification, cvv);
            Driver.SwitchTo().DefaultContent();
        }
        #endregion

        #region SetSelectCountry
        /// <summary>
        /// Set Select Country
        /// </summary>
        /// <param name="country"></param>
        public void SetSelectCountry(string country)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// Click Button Pay Now
        /// </summary>
        public void ClickButtonPayNow()
        {
            WaitAndClickElement(_bookPage.ButtonPayNow);
            Thread.Sleep(10000);
        }
        #endregion        
    }
}
