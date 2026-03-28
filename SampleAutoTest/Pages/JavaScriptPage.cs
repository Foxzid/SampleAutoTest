using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleAutoTest.Pages
{
    public class JavaScriptPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Кнопка запуска
        /// </summary>
        private readonly By _startButton = By.Id("start");

        /// <summary>
        /// Текст отчета времени
        /// </summary>
        private readonly By _message = By.Id("delay");

        /// <summary>
        /// Ожидает появления кнопки старта на странице и нажимает на нее
        /// </summary>
        [AllureStep("Нажать на кнопку Start")]
        public JavaScriptPage StartRocket()
        {
            WaitElement(_startButton);
            ClickElement(_startButton);
            return this;
        }

        /// <summary>
        /// Ожидает появления текста из элемента
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [AllureStep("Ожидать появления текста: {0}")]
        public bool WaitMessageText(string text)
        {
            bool res = Wait.Until(d => d.FindElement(_message).Text.Trim() == text);
            return res;
        }
            

    }
}
