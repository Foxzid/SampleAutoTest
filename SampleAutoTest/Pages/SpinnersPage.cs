using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
            bool res = WaitElementInvisible(_spinner);
            return res;
        }
    }
}
