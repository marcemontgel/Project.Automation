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
        public BookComponent(IWebDriver driver, Actions action, WebDriverWait waitDrive) 
            : base(driver, action, waitDrive)
        {
            _bookPage = new ();
        }

        private readonly BookPage _bookPage;

        public void SetCreditCard(string creditCard)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
            WaitElementClickeable(_bookPage.InputCreditCard);
            SetTextAfterWaiting(_bookPage.InputCreditCard, creditCard);
            Driver.SwitchTo().DefaultContent();
        }

        public void SetDateExpiration(string dateExp)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
            WaitElementClickeable(_bookPage.InputExpiry);
            SetTextAfterWaiting(_bookPage.InputExpiry, dateExp);
            Driver.SwitchTo().DefaultContent();
        }

        public void SetCodeVerification(string cvv)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
            WaitElementClickeable(_bookPage.InputCodeVerification);
            SetTextAfterWaiting(_bookPage.InputCodeVerification, cvv);
            Driver.SwitchTo().DefaultContent();
        }

        public void SetSelectCountry(string country)
        {
            WaitFrameElement(_bookPage.IFrameMethodCreditCard);
        }

        public void ClickButtonPayNow()
        { 
            WaitAndClickElement(_bookPage.ButtonPayNow); 
            Thread.Sleep(10000);
        }
    }
}
