using SampleAutoTest;
using SampleAutoTest.Pages;
using System.ComponentModel;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class TableTests : BaseTest
    {
        private TablePage Page()
        {
            driver.Navigate().GoToUrl($"{jsonContains.Url}/tables//");
            return new TablePage(driver);
        }

        [TestCase("Oranges", "$3.99")]
        [TestCase("Laptop", "$1200.00")]
        [TestCase("Marbles", "$1.25")]
        public void SpinnerPage_WaitSpinnerInvisible(string itemP, string expectedP)
        {
            var tablePage = Page();

            string actualP = tablePage
                .GetItemPrice(itemP);

            Assert.That(actualP, Is.EqualTo(expectedP));
        }
    }
}