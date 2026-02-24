using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleAutoTest.Pages
{
    public class JavaScriptPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Кнопка запуска
        /// </summary>
        private By _startButton => By.Id("start");

        /// <summary>
        /// Текст отчета времени
        /// </summary>
        private By _message => By.Id("delay");

        /// <summary>
        /// Ожидает появления кнопки старта на странице и нажимает на нее
        /// </summary>
        public JavaScriptPage StartRocket()
        {
            WaitElement(_startButton);
            Click(_startButton);
            return this;
        }

        /// <summary>
        /// Ожидает появления текста из элемента
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool WaitMessageText(string text)
        {
            bool res = Wait.Until(d => d.FindElement(_message).Text.Trim() == text);
            return res;
        }
            

    }
}
