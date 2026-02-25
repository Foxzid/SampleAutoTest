using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleAutoTest.Pages
{
    public class ModalsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Заголовок страницы
        /// </summary>
        private By _title => By.XPath("//h1");

        /// <summary>
        /// Кнопка открытия паростого модального окна
        /// </summary>
        private By _simpleModalBtn => By.Id("simpleModal");

        /// <summary>
        /// Простое модальное окно
        /// </summary>
        private By _simpleModalWindow => By.Id("popmake-1318");

        /// <summary>
        /// Кнопка модального окна с формой
        /// </summary>
        private By _formModalBtn => By.Id("formModal");

        /// <summary>
        /// Модальное окно с формой
        /// </summary>
        private By _formModalWindow => By.Id("popmake-674");

        /// <summary>
        /// Поле ввоода имени в модальном окне
        /// </summary>
        private By _nameFieldFormModalWindow => By.Id("g1051-name");

        /// <summary>
        /// Поле ввоода почты в модальном окне
        /// </summary>
        private By _emailFieldFormModalWindow => By.Id("g1051-email");

        /// <summary>
        /// Поле ввоода сообщения в модальном окне
        /// </summary>
        private By _messageFieldFormModalWindow => By.Id("g1051-message");

        /// <summary>
        /// Поле ввоода сообщения в модальном окне
        /// </summary>
        private By _submitBtnFormModalWindow => By.ClassName("pushbutton-wide");

        


        /// <summary>
        /// Проверяет, появилось ли простое модальное окно в течение заданного времени
        /// </summary>
        public bool OpenSimplModal()
        {
            WaitElement(_title);
            ClickElement(_simpleModalBtn);
            bool el = WaitElementInvisible(_simpleModalWindow);
            return el;
        }

        /// <summary>
        /// Открывает модальное окно с формой
        /// </summary>
        public ModalsPage OpenFormModal()
        {
            WaitElement(_title);
            ClickElement(_formModalBtn);
            WaitElementInvisible(_formModalWindow);
            return this;
        }
    }
}
