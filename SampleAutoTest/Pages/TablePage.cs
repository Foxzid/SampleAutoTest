using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class TablePage(IWebDriver driver):BasePage(driver)
    {
        private By Table => By.ClassName("wp-block-table");
        public string GetItemPrice(string item)
        {
            WaitElementVisible(Table);
            return GetTextElement(By.XPath($"//td[text()='{item}']/following-sibling::td"));
        }
    }
}
