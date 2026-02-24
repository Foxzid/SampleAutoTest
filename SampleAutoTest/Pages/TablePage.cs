using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class TablePage(IWebDriver driver):BasePage(driver)
    {
        private By _table => By.ClassName("wp-block-table");
        public string GetItemPrice(string item)
        {
            WaitElementVisible(_table);
            return _driver.FindElement(By.XPath($"//td[text()='{item}']/following-sibling::td")).Text;
        }
    }
}
