using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class SpinnerTests : BaseTest
    {
        private SpinnersPage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/spinners/");
            return new SpinnersPage(_driver);
        }

        [Test]
        [AllureName("Ожидание исчезновения спинера при загрузке страницы")]
        [AllureDescription("Тест ожидает исчезновения спинера при загрузке страницы")]
        [AllureTag("Spinners", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void SpinnerPage_WaitSpinnerInvisible()
        {
            var spinnerPage = Page();

            bool actual = spinnerPage
                .WaitSpinnerInvisible();

            Assert.That(actual, Is.True);
        }
    }
}