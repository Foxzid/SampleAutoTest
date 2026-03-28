using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace SampleAutoTest.Pages
{
    public class TablePage(IWebDriver driver):BasePage(driver)
    {
        private readonly By _table = By.ClassName("wp-block-table");

        [AllureStep("Получить актуальную цену продукта: {0}")]
        public string GetItemPrice(string item)
        {
            WaitElementVisible(_table);
            return GetTextElement(By.XPath($"//td[text()='{item}']/following-sibling::td"));
        }
    }
}
