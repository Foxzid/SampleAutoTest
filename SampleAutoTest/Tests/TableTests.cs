using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.Table
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [AllureNUnit]
    public class TableTests(string browser) : BaseTest(browser)
    {
        [TestCase("Oranges", "$3.99")]
        [TestCase("Laptop", "$1200.00")]
        [TestCase("Marbles", "$1.25")]
        [AllureName("Сравнение актуальных цен с ожидаемыми")]
        [AllureDescription("Тест сравнивает актуальную цену на товар с ожидаемой")]
        [AllureTag("Tables", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void TablePage_GetItemPrice_PriceMatchesExpected(string itemP, string expectedP)
        {
            var tablePage = new TablePage(_driver);
            tablePage.Open(jsonContains.Url);

            string actualP = tablePage
                .GetItemPrice(itemP);

            Assert.That(actualP, Is.EqualTo(expectedP));
        }
    }
}