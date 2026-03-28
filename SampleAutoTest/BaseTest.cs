using Allure.Net.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SampleAutoTest.TestHelpers;

namespace SampleAutoTest
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        protected JsonContains jsonContains;

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            InitializeData();
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
            _driver.Dispose();
        }
        
    }
}
