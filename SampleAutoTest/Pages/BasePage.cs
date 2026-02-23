using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace SampleAutoTest.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        public BasePage(IWebDriver driver) => _driver = driver;

        protected bool IsElementPresent(By locator) =>
            _driver.FindElements(locator).Count > 0;

        protected void WaitElementVisible(By locator)
        {
            Wait.Until(d => d.FindElement(locator).Displayed);
        }

        /// <summary>
        /// Ожидает появления текста у элемента
        /// </summary>
        /// <param name="locator">Необходимый локатор</param>
        /// <param name="expectedText">Необходимы текст</param>
        protected void WaitForTextToBe(By locator, string expectedText)
        {
            Wait.Until(driver =>
            {
                var element = driver.FindElement(locator);
                return element.Text == expectedText;
            });
        }

        /// <summary>
        /// Ожидание появления элемента
        /// </summary>
        /// <param name="locator"></param>
        protected void WaitForElement(By locator) =>
            Wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed && el.Enabled;
            });

        /// <summary>
        /// Клик по элементу
        /// </summary>
        /// <param name="locator">Элемент по которому совершается клик</param>
        public void Click(By locator)
        {
            _driver.FindElement(locator).Click();
        }
    }
}
