using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class ClickElementsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Страница клика по элементам
        /// </summary>
        private By ClickPage => By.Id("box");

        /// <summary>
        /// Текст, который появится после нажатия на кнопку
        /// </summary>
        private By TextMessage => By.Id("demo");

        public ClickElementsPage ClickAnimal(string animal)
        {
            By elAnimal = By.XPath($"//button[normalize-space(.)='{animal}']");
            WaitElementVisible(elAnimal);
            Click(elAnimal);
            return this;
        }

        public string GetTextButtonClick()
        {
            return _driver.FindElement(TextMessage).Text;
        }
    }
}
