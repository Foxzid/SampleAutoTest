using SampleAutoTest;
using SampleAutoTest.Pages;
using System.ComponentModel;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class JavaScriptTests : BaseTest
    {
        private JavaScriptPage Page()
        {
            driver.Navigate().GoToUrl($"{jsonContains.Url}/javascript-delays/");
            return new JavaScriptPage(driver);
        }

        [Test]
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
