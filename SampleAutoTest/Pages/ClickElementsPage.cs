using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class ClickElementsPage(IWebDriver driver) : BasePage(driver)
    {
        /// <summary>
        /// Текст, который появится после нажатия на кнопку
        /// </summary>
        private readonly By _textMessage = By.Id("demo");

        /// <summary>
        /// Метод ждет появления кнопки и нажимает на нее
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public ClickElementsPage ClickAnimal(string animal)
        {
            By elAnimal = By.XPath($"//button[normalize-space(.)='{animal}']");
            WaitElementVisible(elAnimal);
            ClickElement(elAnimal);
            return this;
        }

        /// <summary>
        /// Возвращает текст из элемента
        /// </summary>
        /// <returns></returns>
        public string GetTextButtonClick()
        {
            return GetTextElement(_textMessage);
        }
    }
}
