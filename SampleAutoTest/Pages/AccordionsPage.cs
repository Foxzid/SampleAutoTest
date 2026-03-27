using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class AccordionsPage(IWebDriver driver) : BasePage(driver)
    {

        /// <summary>
        /// опка открытия аккордиона
        /// </summary>
        private readonly By _accordionBtn = By.ClassName("wp-block-coblocks-accordion-item__title");

        /// <summary>
        /// опка открытия аккордиона
        /// </summary>
        private readonly By _accordionParagraph = By.ClassName("wp-block-paragraph");

        /// <summary>
        /// Открытие аккордеона и ожидание непутого значения в аккордеоне
        /// </summary>
        /// <returns></returns>
        public bool WaitAccordionParagraph()
        {
            WaitElement(_accordionBtn);
            ClickElement(_accordionBtn);
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
