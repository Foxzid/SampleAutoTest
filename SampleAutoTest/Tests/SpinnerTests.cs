using SampleAutoTest;
using SampleAutoTest.Pages;
using System.ComponentModel;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class SpinnerTests : BaseTest
    {
        private SpinnersPage Page()
        {
            driver.Navigate().GoToUrl($"{jsonContains.Url}/spinners/");
            return new SpinnersPage(driver);
        }

        [Test]
        public void SpinnerPage_WaitSpinnerInvisible()
        {
            var spinnerPage = Page();

            bool actual = spinnerPage
                .WaitSpinnerInvisible();

            Assert.That(actual, Is.True);
        }
    }
}