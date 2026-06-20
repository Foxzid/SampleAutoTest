using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.JavaScript
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [AllureNUnit]
    public class JavaScriptTests(string browser) : BaseTest(browser)
    {
        [Test]
        [AllureName("Проверка ожидания текста Liftoff! через 15 сек")]
        [AllureDescription("Тест ожидает появления текста Liftoff! после нажатия на кнопку Start")]
        [AllureTag("Javascript-delays", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void OpenJavaScriptPage_ClickStart_WaitMessage()
        {
            var jsPage = new JavaScriptPage(_driver);
            jsPage.Open(jsonContains.Url);

            bool actual = jsPage
                .StartRocket()
                .WaitMessageText("Liftoff!");

            Assert.That(actual, Is.True);
        }
    }
}
