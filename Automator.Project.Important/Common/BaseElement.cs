using Automator.Project.Important.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Globalization;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Automator.Project.Important.Common
{
    public class BaseElement
    {
        #region Constructor
        /// <summary>
        /// Base Element Constructor
        /// </summary>
        /// <param name="driver">Web Driver</param>
        /// <param name="action">Actions</param>
        /// <param name="waitDrive">Web Driver Wait</param>
        public BaseElement(IWebDriver driver, Actions action, WebDriverWait waitDrive)
        {
            Driver = SeleniumDriver._driver;
            Wait = new WebDriverWait(SeleniumDriver._driver, TimeSpan.FromSeconds(120));
            Action = new Actions(Driver);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the element.
        /// </summary>
        protected IWebElement Element { get; private set; }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        protected IWebDriver Driver { get; private set; }

        /// <summary>
        /// Gets the wait.
        /// </summary>
        protected WebDriverWait Wait { get; private set; }

        /// <summary>
        /// Get Action
        /// </summary>
        protected Actions Action { get; private set; }

        /// <summary>
        /// Base Path
        /// </summary>
        public readonly string BasePath = Path.GetFullPath(@"..\..\..\");
        #endregion

        #region LocaleElements
        /// <summary>
        /// Locates elements by locator.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>A list of IWebElements.</returns>
        protected IList<IWebElement> LocateElements(By locator) => Driver.FindElements(locator);

        /// <summary>
        /// Locates element by locator.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>An IWebElement.</returns>
        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);

        /// <summary>
        /// Gets the element after waiting.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>An IWebElement.</returns>
        protected IWebElement GetElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator));
        #endregion

        #region TextElement
        /// <summary>
        /// Gets the text of element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>A text of element.</returns>
        public string GetTextOfElement(By locator)
        {
            SwitchToFirstWindow();
            WaitElement(locator);
            return LocateElement(locator).Text;
        }

        /// <summary>
        /// Gets the text of elements.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>A text of elements.</returns>
        protected string GetTextOfElements(By locator) => LocateElements(locator)[1].Text;
        #endregion

        #region Clicks
        /// <summary>
        /// Clicks element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void Click(By locator)
            => Driver.FindElement(locator).Click();

        /// <summary>
        /// Clicks element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void Click(IWebElement element)
            => element.Click();

        /// <summary>
        /// Doubles the click.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void DoubleClick(By locator)
        {
            WaitElement(locator);
            Element = Driver.FindElement(locator);
            Thread.Sleep(1500);
            Action.DoubleClick(Element).Perform();
        }
        #endregion

        #region Elements
        /// <summary>
        /// Sets text after waiting.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <param name="text">The text.</param>
        protected void SetTextAfterWaiting(By locator, string text)
            => Wait.Until(EC.ElementIsVisible(locator)).SendKeys(text);

        /// <summary>
        /// Clears the field.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void ClearField(By locator)
            => Wait.Until(EC.ElementIsVisible(locator)).Clear();

        /// <summary>
        /// Validates if are the element displayed after waiting.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>A bool.</returns>
        protected bool IsElementDisplayedAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Displayed;

        /// <summary>
        /// Are the element enabled after waiting.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>A bool.</returns>
        protected bool IsElementEnabledAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Enabled;

        /// <summary>
        /// Clicks on clickable element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void ClickOnClickableElement(By locator) => Wait.Until(EC.ElementToBeClickable(locator)).Click();

        /// <summary>
        /// Waits the element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void WaitElement(By locator)
        {
            try
            {
                WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(60));
                wait.Until(EC.ElementIsVisible(locator));
            }
            catch (TimeoutException e)
            {
                e.StackTrace.ToString();
            }
        }

        /// <summary>
        /// Waits the until all elements are presents.
        /// </summary>
        /// <param name="locator">The locator.</param>
        public void WaitUntilAllElementsArePresents(By locator)
            => Wait.Until(EC.PresenceOfAllElementsLocatedBy(locator));

        /// <summary>
        /// Waits the until text is present and visible.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <param name="expectedText">The expected text.</param>
        public void WaitUntilTextIsVisible(By locator, string expectedText)
            => Wait.Until(EC.TextToBePresentInElementLocated(locator, expectedText));

        /// <summary>
        /// Clears the field.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void WaitFrameElement(By locator)
            => Wait.Until(EC.FrameToBeAvailableAndSwitchToIt(locator));

        /// <summary>
        /// Clears the field.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void WaitElementClickeable(By locator)
            => Wait.Until(EC.ElementToBeClickable(locator));
        #endregion

        #region Scrolls
        /// <summary>
        /// Scroll Element Visible
        /// </summary>
        /// <param name="locator"></param>
        protected void ScrollElementVisible(By locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            WebElement Element = (WebElement)Driver.FindElement(locator);
            js.ExecuteScript("arguments[0].scrollIntoView();", Element);
        }

        /// <summary>
        /// Switches the to last window.
        /// </summary>
        protected void SwitchToLastWindow()
            => Driver.SwitchTo().Window(Driver.WindowHandles.Last());

        /// <summary>
        /// Switches the to first window.
        /// </summary>
        protected void SwitchToFirstWindow()
            => Driver.SwitchTo().Window(Driver.WindowHandles.First());

        /// <summary>
        /// Scrolls to end page.
        /// </summary>
        protected void ScrollEndPage()
        {
            for (int i = 0; i < 2; i++)
            {
                Action.SendKeys(Keys.End).Build().Perform();
                Thread.Sleep(800);
            }
        }

        /// <summary>
        /// Scrolls the to element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void ScrollToElement(By locator)
        {
            Action.MoveToElement(LocateElement(locator));
            Action.Perform();
        }

        /// <summary>
        /// Moves the to element and click it.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void MoveToElement(By locator)
            => Action.MoveToElement(Driver.FindElement(locator)).Build().Perform();

        /// <summary>
        /// Send data
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// /// <param name="text">The text.</param>
        protected void SendData(By locator, string text)
            => Driver.FindElement(locator).SendKeys(text);

        /// <summary>
        /// Handles the window.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        protected void HandleWindow(int pageNumber)
        {
            var windowSecond = Driver.WindowHandles[pageNumber];
            Driver.SwitchTo().Window(windowSecond);
        }

        /// <summary>
        /// Moves the to element and click it.
        /// </summary>
        /// <param name="locator">The locator.</param>
        protected void MoveToElementAndClickIt(string locator)
        {
            Action.MoveToElement(Driver.FindElement(By.XPath(locator)));
            Action.Perform();
            IWebElement _element = Driver.FindElement(By.XPath(locator));
            _element.Click();
        }

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        protected void RefreshPage()
            => Driver.Navigate().Refresh();

        /// <summary>
        /// <c>ScrollToTop</c> Scroll the wintow to top
        /// </summary>
        protected void ScrollToTop()
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0);", null);
            Thread.Sleep(1000);
        }
        #endregion

        #region AttachFilePdf
        /// <summary>
        /// Attach File Pdf
        /// </summary>
        protected void AttachFilePdf(By locator, string filepdf)
            => Driver.FindElement(locator).SendKeys(filepdf);
        #endregion

        #region Date
        /// <summary>
        /// Select Start Date
        /// </summary>
        protected void SelectStartDate(int dayAfterStart)
        {
            DateTime td = DateTime.Now;
            DateTime daysAdd = td.AddDays(dayAfterStart);
            var laterDay = daysAdd.ToString("d-MMMM-yyyy");
            var laterDayEs = daysAdd.ToString("d-MMMM-yyyy", CultureInfo.GetCultureInfo("es-ES"));
            var laterDayPt = daysAdd.ToString("d-MMMM-yyyy", CultureInfo.GetCultureInfo("pt-PT"));

            string emonth = laterDay.Split("-")[1];
            string emonthEs = laterDayEs.Split("-").Select(i => i.Substring(0, 1).ToUpper() + i.Substring(1).ToLower()).ToArray()[1];
            string emonthPt = laterDayPt.Split("-").Select(i => i.Substring(0, 1).ToUpper() + i.Substring(1).ToLower()).ToArray()[1];
            string eyear = laterDay.Split("-")[2];
            string edate = laterDay.Split("-")[0];

            Driver.FindElement(By.XPath("//*[@class='datetime-input']")).Click();
            string cmonth = Driver.FindElement(By.XPath("(//*[@class='month-item-name'])[1]")).Text.Trim();
            string cyear = Driver.FindElement(By.XPath("(//span[@class='month-item-year'])[1]")).Text.Trim();
            IWebElement next;

            while ((!cmonth.Equals(emonth) && !cmonth.Equals(emonthEs) && !cmonth.Equals(emonthPt)) || (!cyear.Equals(eyear)))
            {
                next = Driver.FindElement(By.XPath("(//button[@class='button-next-month'])[2]"));
                next.Click();
                cmonth = Driver.FindElement(By.XPath("(//*[@class='month-item-name'])[1]")).Text.Trim();
                cyear = Driver.FindElement(By.XPath("(//span[@class='month-item-year'])[1]")).Text.Trim();
            }

            List<IWebElement> dates = Driver.FindElements(By.XPath("//*[@class='day-item']")).ToList();

            foreach (IWebElement e in dates)
            {
                if (e.Text.Trim().Equals(edate))
                {
                    e.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Select End Date
        /// </summary>
        protected void SelectEndDate(int dayAfterEnd)
            => SelectStartDate(dayAfterEnd);
        #endregion

        #region GetTextOfListElements
        /// <summary>
        /// Get Text Of List Elements
        /// </summary>
        /// <param name="textElement"></param>
        /// <param name="locator"></param>
        protected void GetTextOfListElements(string textElement, By locator)
        {
            IWebElement element = Driver.FindElements(locator).ToList()
                .Where(x => x.Text.Equals(textElement)).FirstOrDefault()
                ?? throw new Exception();

            element.Click();
        }
        #endregion

        #region GetLocationPickUp
        /// <summary>
        /// <c>GetLocationPickUp</c> Get Location PickUp
        /// </summary>
        /// <param name="textElement">Text element</param>
        /// <param name="locator">Locator</param>
        protected void GetLocationPickUp(string textElement, By locator)
        {
            List<IWebElement> elementsOptions = Driver.FindElements(locator).ToList();
            bool existsFilters = elementsOptions.Exists(e => e.Text.Equals(textElement));

            if (!existsFilters)
                throw new Exception();

            for (int i = 0; i < elementsOptions.Count; i++)
            {
                IWebElement elems = elementsOptions[i];
                string valueOption = elems.Text;
                if (valueOption.Equals(textElement))
                {
                    elems.Click();
                    break;
                }
            }
        }
        #endregion

        #region Waiters

        #region WaitAndClickElement
        /// <summary>
        /// <c>WaitAndClickElement</c> Wait And Click Element
        /// </summary>
        /// <param name="element">Element</param>
        public void WaitAndClickElement(By element)
        {
            WaitElement(element);
            Click(element);
        }
        #endregion

        #region WaitAndSetText
        /// <summary>
        /// <c>WaitAndSetText</c> Wait And Set Text
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="text">Text</param>
        public void WaitAndSetText(By element, string text)
        {
            WaitElement(element);
            SetTextAfterWaiting(element, text);
        }
        #endregion

        #region WaitAndValidateText
        /// <summary>
        /// Wait And Validate Text
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="text">Text</param>
        public void WaitAndValidateText(By element, string text)
        {
            WaitElement(element);
            Assert.AreEqual(text, GetTextOfElement(element));
        }
        #endregion

        #region WaitAndFindElement
        /// <summary>
        /// <c>WaitAndFindElement</c> Wait And Find Element
        /// </summary>
        /// <param name="locator">Locator</param>
        /// <returns>Web Element</returns>
        public IWebElement WaitAndFindElement(By locator)
        {
            WaitElement(locator);
            return Driver.FindElement(locator);
        }
        #endregion

        #region WaitAndFindElements
        /// <summary>
        /// <c>WaitAndFindElement</c> Wait And Find Elements
        /// </summary>
        /// <param name="locator">Locator</param>
        /// <returns>Web Element</returns>
        public ReadOnlyCollection<IWebElement> WaitAndFindElements(By locator)
        {
            WaitElement(locator);
            return Driver.FindElements(locator);
        }
        #endregion

        #endregion
    }
}
