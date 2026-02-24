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
            WaitElementVisible(_accordionBtn);
            Click(_accordionBtn);
            if(WaitElementInvisible(_accordionParagraph)==true)
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
