using DemoQATests.TestHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQATests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        protected void SetUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(TestHelp.Url);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void TearDown()
        {
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            driver.Dispose();
        }

    }
}
