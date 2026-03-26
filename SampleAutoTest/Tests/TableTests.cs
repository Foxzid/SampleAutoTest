using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class TableTests : BaseTest
    {
        private TablePage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/tables//");
            return new TablePage(_driver);
        }

        [TestCase("Oranges", "$3.99")]
        [TestCase("Laptop", "$1200.00")]
        [TestCase("Marbles", "$1.25")]
        [AllureName("Сравнение актуальных цен с ожидаемыми")]
        [AllureDescription("Тест сравнивает актуальную цену на товар с ожидаемой")]
        [AllureTag("Tables", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void SpinnerPage_WaitSpinnerInvisible(string itemP, string expectedP)
        {
            var tablePage = Page();

            string actualP = tablePage
                .GetItemPrice(itemP);

            Assert.That(actualP, Is.EqualTo(expectedP));
        }
    }
}