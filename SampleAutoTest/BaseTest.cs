using Allure.Net.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SampleAutoTest.TestHelpers;

namespace SampleAutoTest
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        private readonly string _browser;
        protected JsonContains jsonContains;

        public BaseTest(string browser)
        {
            _browser = browser;
        }

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            InitializeData();
            _driver = _browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"Браузер {_browser} не поддерживается")
            };
            _driver.Manage().Window.Maximize();
        }

        [SetUp]
        protected void SetUp()
        {            
        }

        private void InitializeData()
        {
            new JsonContainsProvider().Provide(out JsonContains jsonContainsObject);
            jsonContains = jsonContainsObject;
        }

        [TearDown]
        protected void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                byte[] content = screenshot.AsByteArray;
                AllureApi.AddAttachment("Screenshot на момент ошибки", "image/png", content);
            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.localStorage.clear();");
            js.ExecuteScript("window.sessionStorage.clear();");
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().Refresh();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
        
    }
}
