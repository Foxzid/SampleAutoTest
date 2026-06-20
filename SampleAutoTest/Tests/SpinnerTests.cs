using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.Spiner
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [AllureNUnit]
    public class SpinnerTests(string browser) : BaseTest(browser)
    {
        [Test]
        [AllureName("Ожидание исчезновения спинера при загрузке страницы")]
        [AllureDescription("Тест ожидает исчезновения спинера при загрузке страницы")]
        [AllureTag("Spinners", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void SpinnerPage_WaitSpinnerInvisible()
        {
            var spinnerPage = new SpinnersPage(_driver);
            spinnerPage.Open(jsonContains.Url);

            bool actual = spinnerPage
                .WaitSpinnerInvisible();

            Assert.That(actual, Is.True);
        }
    }
}