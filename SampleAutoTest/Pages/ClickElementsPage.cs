using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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

        public void ClickCatButton()
        {
            WaitElementVisible(CatButton);
            _driver.FindElement(CatButton).Click();
        }

        public void ClickDogButton()
        {
            WaitElementVisible(DogButton);
            _driver.FindElement(DogButton).Click();
        }

        public void ClickPigButton()
        {
            WaitElementVisible(PigButton);
            _driver.FindElement(PigButton).Click();
        }

        public void ClickCowButton()
        {
            WaitElementVisible(CowButton);
            _driver.FindElement(CowButton).Click();
        }

        public string GetTextButtonClick()
        {
            return _driver.FindElement(TextMessage).Text;
        }
    }
}
