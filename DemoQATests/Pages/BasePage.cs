using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQATests.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        private WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        public BasePage(IWebDriver driver) => _driver = driver;

        protected bool IsElementPresent(By locator) =>
            _driver.FindElements(locator).Count > 0;

        protected void WaitElementVisible(By locator)
        {
            Wait.Until(d => d.FindElement(locator).Displayed);
        }

        protected void WaitForElement(By locator) =>
            Wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed && el.Enabled;
            });
    }
}