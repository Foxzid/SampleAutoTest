using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class AccordionsTests : BaseTest
    {
        private AccordionsPage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/accordions/");
            return new AccordionsPage(_driver);
        }

        [Test]
        [AllureName("Проверка раскрытия аккордеона")]
        [AllureDescription("Тест проверяет раскрытие аккордеона на странице")]
        [AllureTag("Accordions", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void OpenJavaScriptPage_ClickStart_WaitMessage()
        {
            var acPage = Page();

            bool actual = acPage
                .WaitAccordionParagraph();

            Assert.That(actual, Is.True);
        }
    }
}
