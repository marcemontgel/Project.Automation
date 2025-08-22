using Automator.Project.Important.Common.Configuration;
using Automator.Project.Important.Domain.Enum;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Model;


namespace Automator.Project.Important.Hooks
{
    /// <summary>
    /// General Selenium Driver
    /// </summary>
    [Binding]
    public class SeleniumDriver
    {
        #region Properties
        /// <summary>
        /// Scenario Context
        /// </summary>
        private static ScenarioContext _scenarioContext;

        /// <summary>
        /// Extent Reports
        /// </summary>
        private static ExtentReports _extentReports;

        /// <summary>
        /// Extent Test
        /// </summary>
        private static ExtentTest _feature;

        /// <summary>
        /// Extent Test
        /// </summary>
        private static ExtentTest _scenario;

        /// <summary>
        /// IWebDriver interface
        /// </summary>
        public static IWebDriver _driver;

        /// <summary>
        /// Configuration Driver Selelium
        /// </summary>
        readonly WebDriverConfiguration config = new();

        /// <summary>
        /// Base Path
        /// </summary>
        private static readonly string BasePath = Path.GetFullPath(@"..\..\..\");
        #endregion

        #region InitializeReport
        /// <summary>
        /// <c>InitializeReport</c> to inicialize the report
        /// </summary>
        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Path defined
            string path = $"{BasePath}Reports{Path.DirectorySeparatorChar}index.html";

            //Initialize Extent report before test starts
            ExtentSparkReporter spark = new(@path);
            spark.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            //Attach report to reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(spark);
        }

        /// <summary>
        /// <c>InitializeReport</c> to inicialize the report
        /// </summary>
        /// <param name="path">Path</param>
        public static void InitializeReport(string path)
        {
            //Initialize Extent report before test starts
            ExtentSparkReporter spark = new(@path);
            spark.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            //Attach report to reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(spark);
        }
        #endregion

        #region BeforeFeature
        /// <summary>
        /// <c>BeforeFeature</c> Before Feature
        /// </summary>
        /// <param name="featureContext">Feature Context</param>
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name0
            if (null != featureContext)
                _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title,
                    featureContext.FeatureInfo.Description);
        }
        #endregion

        #region Initialize
        /// <summary>
        /// <c>Initialize</c> to Initialize
        /// </summary>
        /// <param name="scenarioContex">Scenario Context</param>
        [BeforeScenario]
        public void Initialize(ScenarioContext scenarioContex)
        {
            BrowserName browserName = BrowserName.Chrome;
            browserName = SelectBrowserScenario(scenarioContex, browserName);
            SelectBrowser(browserName);

            if (null != scenarioContex)
            {
                _scenarioContext = scenarioContex;
                _scenario = _feature.CreateNode<Scenario>(scenarioContex.ScenarioInfo.Title,
                    scenarioContex.ScenarioInfo.Description);
            }
        }

        /// <summary>
        /// <c>SelectBrowserScenario</c> Select Browser Scenario
        /// </summary>
        /// <param name="scenarioContex">Scenario Context</param>
        /// <param name="browser">Browser Name</param>
        /// <returns>Browser Name</returns>
        public static BrowserName SelectBrowserScenario(ScenarioContext scenarioContex, BrowserName browser)
        {
            string[]? browserName = scenarioContex?.ScenarioInfo?.Tags?.Where(x => x.StartsWith("Browser"))?.FirstOrDefault()?.Split("=");

            if (browserName is not null)
                Enum.TryParse(browserName?[1], out browser);

            return browser;
        }
        #endregion

        #region InsertReportingSteps
        /// <summary>
        /// Insert Reporting Steps
        /// </summary>
        [AfterStep]
        public static void InsertReportingSteps()
        {
            switch (_scenarioContext.CurrentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }
        }
        #endregion

        #region CreateNode
        /// <summary>
        /// <c>CreateNode</c> to create the node
        /// </summary>
        /// <typeparam name="T">Generic model</typeparam>
        public static void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                //Take the screenshot
                Screenshot image = ((ITakesScreenshot)_driver).GetScreenshot();

                //Path defined
                string path = $"{BasePath}Reports{Path.DirectorySeparatorChar}";

                //save the screenshot
                // image.SaveAsFile($"{AppDomain.CurrentDomain.DynamicDirectory}{@path}{_scenarioContext.ScenarioInfo.Title.Replace(" ", "")}{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png", ScreenshotImageFormat.Png);
                image.SaveAsFile($"{AppDomain.CurrentDomain.DynamicDirectory}{@path}{_scenarioContext.ScenarioInfo.Title.Replace(" ", "")}{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png");

                _scenario.CreateNode<T>(_scenarioContext.TestError.Message.ToUpper()).
                Fail("\n" + _scenarioContext.StepContext.StepInfo.Text).
                Fail("\n" + _scenarioContext.TestError.StackTrace);
            }
            else
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
        }
        #endregion

        #region TearDownReport
        /// <summary>
        /// Tear Down Report
        /// </summary>
        [AfterTestRun]
        public static void TearDownReport()
            => _extentReports.Flush();
        #endregion

        #region SelectBrowser
        /// <summary>
        /// <c>SelectBrowser</c> to Select Browser
        /// </summary>
        /// <param name="browserName">Browser Name</param>
        private void SelectBrowser(BrowserName browserName)
        {
            switch (browserName)
            {
                case BrowserName.Chrome:
                    var options = new ChromeOptions();
                    options.AddAdditionalOption("useAutomationExtension", false);
                    options.AddExcludedArgument("enable-automation");
                    options.AddArgument("--disable-save-password-bubble");
                    options.AddArgument("ignore-certificate-errors");
                    options.AddArgument("start-maximized");
                    options.AddArgument($"--lang={config.BrowserLanguage}");
                    options.AddUserProfilePreference("intl.accept_languages", config.BrowserLanguage);
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver(options);
                    break;
                case BrowserName.Firefox:
                    var optionsFirefox = new FirefoxOptions { AcceptInsecureCertificates = true };
                    _driver = new FirefoxDriver(optionsFirefox);
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver.Manage().Window.Maximize();
                    break;
                case BrowserName.Edge:
                    var optionsEdge = new EdgeOptions();
                    _driver = new EdgeDriver(optionsEdge);
                    _driver.Manage().Window.Maximize();
                    optionsEdge.PageLoadStrategy = PageLoadStrategy.Normal;
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    break;
                case BrowserName.Safari:
                    break;
            }
        }
        #endregion

        #region AfterScenario
        /// <summary>
        /// <c>AfterScenario</c> to After Scenario
        /// </summary>
        [AfterScenario]
        public static void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }
        #endregion

        #region GetExtentReports
        /// <summary>
        /// <c>GetExtentReports</c> Get Extent Reports
        /// </summary>
        /// <returns></returns>
        public static Test GetExtentReports()
            => _scenario.Model;
        #endregion
    }
}
