using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SampleAutoTest.TestHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAutoTest
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        protected JsonContains jsonContains;

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            _driver = new ChromeDriver();

            InitializeData();
        }

        [SetUp]
        protected void SetUp()
        {
            var options = new ChromeOptions();
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
