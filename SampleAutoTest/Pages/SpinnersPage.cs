using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class SpinnersPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// Спинер загрузки
        /// </summary>
        private By Spinner => By.ClassName("spinner.spinner-hidden");

        public bool WaitSpinnerInvisible()
        {
            return WaitElementInvisible(Spinner);
        }
    }
}
