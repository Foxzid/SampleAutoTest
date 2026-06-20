using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class SpinnersPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Спинер загрузки
        /// </summary>
        private readonly By _spinner = By.CssSelector(".spinner.spinner-hidden");

        [AllureStep("Дождаться исчезновения спинера")]
        public bool WaitSpinnerInvisible()
        {
            return WaitElementInvisible(_spinner);
        }
    }
}
