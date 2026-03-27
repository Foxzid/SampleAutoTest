using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class AccordionsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// опка открытия аккордиона
        /// </summary>
        private By AccordionBtn => By.ClassName("wp-block-coblocks-accordion-item__title");

        /// <summary>
        /// опка открытия аккордиона
        /// </summary>
        private By AccordionParagraph => By.ClassName("wp-block-paragraph");

        /// <summary>
        /// Открытие аккордеона и ожидание непутого значения в аккордеоне
        /// </summary>
        /// <returns></returns>
        public bool WaitAccordionParagraph()
        {
            WaitElement(AccordionBtn);
            ClickElement(AccordionBtn);
            var el = WaitElement(AccordionParagraph);
            if(el!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
