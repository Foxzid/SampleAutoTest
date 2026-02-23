using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace SampleAutoTest.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        public BasePage(IWebDriver driver) => _driver = driver;

        /// <summary>
        /// Проверка наличия элемента без вызова исключения
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected bool IsElementPresent(By locator) =>
            _driver.FindElements(locator).Count > 0;

        /// <summary>
        /// Проверка наличия элемента на странице
        /// </summary>
        /// <param name="locator"></param>
        protected void WaitElementVisible(By locator)
        {
            Wait.Until(d => d.FindElement(locator).Displayed);
        }

        /// <summary>
        /// Ожидание появления элемента
        /// </summary>
        /// <param name="locator"></param>
        protected void WaitForElement(By locator)
        {
            Wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed && el.Enabled;
            });
        }
        /// <summary>
        /// Ожидание исчезновения элемента со страницы
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool WaitElementInvisible(By locator)
        {
            return Wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }
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
