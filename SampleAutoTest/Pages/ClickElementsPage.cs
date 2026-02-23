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
        /// Кнопка кота
        /// </summary>
        private By CatButton => By.XPath("//button[@onclick = 'catSound()']");
        //*[text()='Cat']

        /// <summary>
        /// Кнопка собаки
        /// </summary>
        private By DogButton => By.XPath("//button[@onclick = 'dogSound()']");

        /// <summary>
        /// Кнопка свиньи
        /// </summary>
        private By PigButton => By.XPath("//button[@onclick = 'pigSound()']");

        /// <summary>
        /// Кнопка свиньи
        /// </summary>
        private By CowButton => By.XPath("//button[@onclick = 'cowSound()']");

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
        
        public void ClickCatButton()
        {
            WaitElementVisible(CatButton);
            Click(CatButton);
        }

        public void ClickDogButton()
        {
            WaitElementVisible(DogButton);
            Click(DogButton);
        }

        public void ClickPigButton()
        {
            WaitElementVisible(PigButton);
            Click(PigButton);
        }

        public void ClickCowButton()
        {
            WaitElementVisible(CowButton);
            Click(CowButton);
        }

        public string GetTextButtonClick()
        {
            return _driver.FindElement(TextMessage).Text;
        }
    }
}
