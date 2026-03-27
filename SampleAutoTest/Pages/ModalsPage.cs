using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleAutoTest.Pages
{
    public class ModalsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Заголовок страницы
        /// </summary>
        private By Title => By.XPath("//h1");

        /// <summary>
        /// Кнопка открытия паростого модального окна
        /// </summary>
        private By SimpleModalBtn => By.Id("simpleModal");

        /// <summary>
        /// Простое модальное окно
        /// </summary>
        private By SimpleModalWindow => By.Id("popmake-1318");

        /// <summary>
        /// Кнопка модального окна с формой
        /// </summary>
        private By FormModalBtn => By.Id("formModal");

        /// <summary>
        /// Модальное окно с формой
        /// </summary>
        private By FormModalWindow => By.Id("popmake-674");

        /// <summary>
        /// Поле ввоода имени в модальном окне
        /// </summary>
        private By NameFieldFormModalWindow => By.Id("g1051-name");

        /// <summary>
        /// Поле ввоода почты в модальном окне
        /// </summary>
        private By EmailFieldFormModalWindow => By.Id("g1051-email");

        /// <summary>
        /// Поле ввоода сообщения в модальном окне
        /// </summary>
        private By MessageFieldFormModalWindow => By.Id("contact-form-comment-g1051-message");

        /// <summary>
        /// Поле ввоода сообщения в модальном окне
        /// </summary>
        private By SubmitBtnFormModalWindow => By.ClassName("pushbutton-wide");

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private By CartName => By.XPath("//div[@class='field-name-wrapper'][.//div[text()='Name:']]/following-sibling::div[1]");

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private By CartEmail => By.XPath("//div[@class='field-name-wrapper'][.//div[text()='Email:']]/following-sibling::div[1]");

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private By CartMessage => By.XPath("//div[@class='field-name-wrapper'][.//div[text()='Message:']]/following-sibling::div[1]");

        /// <summary>
        /// Проверяет, появилось ли простое модальное окно в течение заданного времени
        /// </summary>
        public bool OpenSimplModal()
        {
            WaitElement(Title);
            ClickElement(SimpleModalBtn);
            bool el = WaitElementVisible(SimpleModalWindow);
            return el;
        }

        /// <summary>
        /// Открывает модальное окно с формой
        /// </summary>
        public ModalsPage OpenFormModal()
        {
            WaitElement(Title);
            ClickElement(FormModalBtn);
            WaitElement(FormModalWindow);
            return this;
        }

        public string SendNameModalForm(string name)
        {
            WaitElement(NameFieldFormModalWindow);
            SendKey(NameFieldFormModalWindow, name);
            return name;
        }

        public string SendEmailModalForm(string email)
        {
            WaitElement(EmailFieldFormModalWindow);
            SendKey(EmailFieldFormModalWindow, email);
            return email;
        }

        public string SendMessageModalForm(string message)
        {
            WaitElement(MessageFieldFormModalWindow);
            SendKey(MessageFieldFormModalWindow, message);
            return message;
        }

        public ModalsPage ClickSubmitModalForm()
        {
            WaitElement(SubmitBtnFormModalWindow);
            ClickAndWait(SubmitBtnFormModalWindow, CartName);
            return this;
        }
        public string ActualNameModalForm()
        {
            return GetTextElement(CartName);
        }

        public string ActualEmailModalForm()
        {
            return GetTextElement(CartEmail);
        }

        public string ActualMessageModalForm()
        {
            return GetTextElement(CartMessage);
        }

    }
}
