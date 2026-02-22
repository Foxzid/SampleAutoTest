using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DemoQATests.Pages
{
    public class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver) : base(driver)
        {
        }
        #region[Элементы]
        /// <summary>
        /// Заголовок страницы
        /// </summary>
        private By TextBoxTitle => By.ClassName("text-center");

        /// <summary>
        /// Поле ввода имени пользователя
        /// </summary>
        private By UserName => By.Id("userName");

        /// <summary>
        /// Поле ввода электронной почты пользователя
        /// </summary>
        private By UserEmail => By.Id("userEmail");

        /// <summary>
        /// Поле ввода текущего адреса пользователя
        /// </summary>
        private By UserCurrentAdress => By.Id("currentAddress");

        /// <summary>
        /// Поле ввода постоянного адреса пользователя
        /// </summary>
        private By UserPermanentAdress => By.Id("permanentAddress");

        /// <summary>
        /// Поле ввода постоянного адреса пользователя
        /// </summary>
        private By SubmitButton => By.Id("submit");

        /// <summary>
        /// Поле ввода постоянного адреса пользователя
        /// </summary>
        //private By SubmitButton => By.Id("submit");

        #endregion

        #region[Методы]
        /// <summary>
        /// Заполняет поля Text Box данными
        /// </summary>
        public void FillingBoxFields(string userName, string userEmail, string currentAddress, string permanentAdress)
        {
            WaitForElement(TextBoxTitle);
            _driver.FindElement(UserName).SendKeys(userName);
            _driver.FindElement(UserEmail).SendKeys(userEmail);
            _driver.FindElement(UserCurrentAdress).SendKeys(currentAddress);
            _driver.FindElement(UserPermanentAdress).SendKeys(permanentAdress);
            _driver.FindElement(SubmitButton).Click();
        }

        /// <summary>
        /// 
        /// </summary>

        #endregion
    }
}