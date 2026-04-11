using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.JavaScript
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [AllureNUnit]
    public class JavaScriptTests(string browser) : BaseTest(browser)
    {
        private JavaScriptPage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/javascript-delays/");
            return new JavaScriptPage(_driver);
        }

        [Test]
        [AllureName("Проверка ожидания текста Liftoff! через 15 сек")]
        [AllureDescription("Тест ожидает появления текста Liftoff! после нажатия на кнопку Start")]
        [AllureTag("Javascript-delays", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void OpenJavaScriptPage_ClickStart_WaitMessage()
        {
            var jsPage = Page();

            bool actual = jsPage
                .StartRocket()
                .WaitMessageText("Liftoff!");

            Assert.That(actual, Is.True);
        }
    }
}
