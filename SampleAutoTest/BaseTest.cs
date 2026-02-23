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
        protected IWebDriver driver;
        protected JsonContains jsonContains;

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            driver = new ChromeDriver();

            InitializeData();
        }

        [SetUp]
        protected void SetUp()
        {
            var options = new ChromeOptions();
            driver.Manage().Window.Maximize();
        }

        private void InitializeData()
        {
            new JsonContainsProvider().Provide(out JsonContains jsonContainsObject);
            jsonContains = jsonContainsObject;
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            driver.Dispose();
        }
        
    }
}
