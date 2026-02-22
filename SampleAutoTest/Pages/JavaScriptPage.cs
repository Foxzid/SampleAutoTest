using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class JavaScriptPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Кнопка запуска
        /// </summary>
        private By StartButton => By.Id("start");

        /// <summary>
        /// Текст отчета времени
        /// </summary>
        private By Message => By.Id("delay");

        /// <summary>
        /// Ожидает появления кнопки старта на странице
        /// </summary>
        public void StartRocket()
        {
            WaitForElement(StartButton);
            _driver.FindElement(StartButton).Click();
        }

        public void WaitMessageText()
        {
            WaitForTextToBe(Message, "Liftoff!");
        }
            

    }
}
