using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.Accordions
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [AllureNUnit]
    public class AccordionsTests(string browser) : BaseTest(browser)
    {
        [Test]
        [AllureName("Проверка раскрытия аккордеона")]
        [AllureDescription("Тест проверяет раскрытие аккордеона на странице")]
        [AllureTag("Accordions", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void OpenJavaScriptPage_ClickStart_WaitMessage()
        {
            var acPage = new AccordionsPage(_driver);
            acPage.Open(jsonContains.Url);

            bool actual = acPage
                .WaitAccordionParagraph();

            Assert.That(actual, Is.True);
        }
    }
}
