using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleAutoTest.Pages
{
    public class ModalsPage(IWebDriver driver) : BasePage(driver)
    {
        protected override string UrlPath => "/modals/";

        /// <summary>
        /// Заголовок страницы
        /// </summary>
        private readonly By _title = By.XPath("//h1");

        /// <summary>
        /// Кнопка открытия паростого модального окна
        /// </summary>
        private readonly By _simpleModalBtn = By.Id("simpleModal");

        /// <summary>
        /// Простое модальное окно
        /// </summary>
        private readonly By _simpleModalWindow = By.Id("popmake-1318");

        /// <summary>
        /// Кнопка модального окна с формой
        /// </summary>
        private readonly By _formModalBtn = By.Id("formModal");

        /// <summary>
        /// Модальное окно с формой
        /// </summary>
        private readonly By _formModalWindow = By.Id("popmake-674");

        /// <summary>
        /// Поле ввоода имени в модальном окне
        /// </summary>
        private readonly By _nameFieldFormModalWindow = By.Id("g1051-name");

        /// <summary>
        /// Поле ввоода почты в модальном окне
        /// </summary>
        private readonly By _emailFieldFormModalWindow = By.Id("g1051-email");

        /// <summary>
        /// Поле ввоода сообщения в модальном окне
        /// </summary>
        private readonly By _messageFieldFormModalWindow = By.Id("contact-form-comment-g1051-message");

        /// <summary>
        /// Поле ввоода сообщения в модальном окне
        /// </summary>
        private readonly By _submitBtnFormModalWindow = By.ClassName("pushbutton-wide");

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private readonly By _cartName = By.XPath("//div[@class='field-name-wrapper'][.//div[text()='Name:']]/following-sibling::div[1]");

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private readonly By _cartEmail = By.XPath("//div[@class='field-name-wrapper'][.//div[text()='Email:']]/following-sibling::div[1]");

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private readonly By _cartMessage = By.XPath("//div[@class='field-name-wrapper'][.//div[text()='Message:']]/following-sibling::div[1]");

        /// <summary>
        /// Проверяет, появилось ли простое модальное окно в течение заданного времени
        /// </summary>
        [AllureStep("Открыть простое модальное окно")]
        public bool OpenSimplModal()
        {
            WaitElement(_title);
            ClickElement(_simpleModalBtn);
            bool el = WaitElementVisible(_simpleModalWindow);
            return el;
        }

        /// <summary>
        /// Открывает модальное окно с формой
        /// </summary>
        [AllureStep("Открыть модальное окно с формой")]
        public ModalsPage OpenFormModal()
        {
            WaitElement(_title);
            ClickElement(_formModalBtn);
            WaitElement(_formModalWindow);
            return this;
        }

        [AllureStep("Ввести в поле Name значение: {0}")]
        public string SendNameModalForm(string name)
        {
            WaitElement(_nameFieldFormModalWindow);
            SendKey(_nameFieldFormModalWindow, name);
            return name;
        }

        [AllureStep("Ввести в поле Email значение: {0}")]
        public string SendEmailModalForm(string email)
        {
            WaitElement(_emailFieldFormModalWindow);
            SendKey(_emailFieldFormModalWindow, email);
            return email;
        }

        [AllureStep("Ввести в поле Message значение: {0}")]
        public string SendMessageModalForm(string message)
        {
            WaitElement(_messageFieldFormModalWindow);
            SendKey(_messageFieldFormModalWindow, message);
            return message;
        }

        [AllureStep("Отправить заполненную форму")]
        public ModalsPage ClickSubmitModalForm()
        {
            WaitElement(_submitBtnFormModalWindow);
            ClickAndWait(_submitBtnFormModalWindow, _cartName);
            return this;
        }
        public string ActualNameModalForm()
        {
            return GetTextElement(_cartName);
        }

        public string ActualEmailModalForm()
        {
            return GetTextElement(_cartEmail);
        }

        public string ActualMessageModalForm()
        {
            return GetTextElement(_cartMessage);
        }

    }
}
