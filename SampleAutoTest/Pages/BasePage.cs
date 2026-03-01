using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace SampleAutoTest.Pages
{
    public class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver _driver = driver;
        protected WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

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
        protected bool WaitElementVisible(By locator)
        {
            return Wait.Until(d => d.FindElement(locator).Displayed);
        }

        /// <summary>
        /// Ожидание исчезновения элемента со страницы
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool WaitElementInvisible(By locator)
        {
            return Wait.Until(drv =>
            {
                try
                {
                    var el = drv.FindElement(locator);
                    return !el.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
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
                catch (StaleElementReferenceException)
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
        /// Вводит в поле string значение
        /// </summary>
        public void SendKey(By locator, string value)
        {
            var elem = WaitElement(locator);
            elem.Clear();
            elem.SendKeys(value);
        }

        /// <summary>
        /// Вводит в поле string значение
        /// </summary>
        public string GetTextElement(By locator)
        {
            return _driver.FindElement(locator).Text;
        }
    }
}
