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
        /// Страница клика по элементам
        /// </summary>
        private By ClickPage => By.Id("box");
    }
}
