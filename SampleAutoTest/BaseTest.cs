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
        private ThreadLocal<IWebDriver> _driverThread = new ThreadLocal<IWebDriver>();
        protected IWebDriver _driver
        {
            get => _driverThread.Value!;
            set => _driverThread.Value = value;
        }
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
        }

        [SetUp]
        protected void SetUp()
        {
            IWebDriver driver = _browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"Браузер {_browser} не поддерживается")
            };
            _driver = driver;
            _driver.Manage().Window.Maximize();
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
            _driver?.Quit();
            _driver?.Dispose();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            _driverThread?.Dispose();
        }
        
    }
}
