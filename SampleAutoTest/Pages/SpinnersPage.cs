using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class SpinnersPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Спинер загрузки
        /// </summary>
        private By _spinner => By.ClassName("spinner.spinner-hidden");

        public bool WaitSpinnerInvisible()
        {
            return WaitElementInvisible(_spinner);
        }
    }
}
