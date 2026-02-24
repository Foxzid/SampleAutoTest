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
        /// Совершает клик по элементу
        /// </summary>
        public BasePage ClickElement(By locator)
        {
            Wait.Until(drv => {
                var el = drv.FindElement(locator);
                return el.Displayed && el.Enabled ? el : null;
            })?.Click();
            return this;
        }
        /// <summary>
        /// Ожидание появления элемента
        /// </summary>
        protected IWebElement WaitElement(By locator)
        {
            Wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException));

            return Wait.Until(drv => {
                try
                {
                    var el = drv.FindElement(locator);
                    return (el.Displayed && el.Enabled) ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
        /// <summary>
        /// Совершает клик по элементу и ожидает появление другого элемента
        /// </summary>
        public BasePage ClickAndWait(By clickLocator, By waitLocator)
        {
            ClickElement(clickLocator);
            WaitElement(waitLocator);
            return this;
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
