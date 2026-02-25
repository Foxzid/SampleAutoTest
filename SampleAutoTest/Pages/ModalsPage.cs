using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleAutoTest.Pages
{
    public class ModalsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Кнопка запуска
        /// </summary>
        private By _title => By.XPath("//h1");

        /// <summary>
        /// Текст отчета времени
        /// </summary>
        private By _simpleModalBtn => By.Id("simpleModal");

        /// <summary>
        /// Текст отчета времени
        /// </summary>
        private By _simpleModalWindow => By.Id("popmake-1318");

        /// <summary>
        /// Текст отчета времени
        /// </summary>
        private By _formModalBtn => By.Id("formModal");

        /// <summary>
        /// Ожидает появления кнопки старта на странице и нажимает на нее
        /// </summary>
        public bool OpenSimplModal()
        {
            WaitElement(_title);
            ClickElement(_simpleModalBtn);
            bool el = WaitElementInvisible(_simpleModalWindow);
            return el;
        }

    }
}
