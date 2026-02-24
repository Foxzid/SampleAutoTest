using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class AccordionsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// опка открытия аккордиона
        /// </summary>
        private By _accordionBtn => By.ClassName("wp-block-coblocks-accordion-item__title");

        /// <summary>
        /// опка открытия аккордиона
        /// </summary>
        private By _accordionParagraph => By.ClassName("wp-block-paragraph");

        
        public bool WaitAccordionParagraph()
        {
            WaitElement(_accordionBtn);
            Click(_accordionBtn);
            var el = WaitElement(_accordionParagraph);
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
