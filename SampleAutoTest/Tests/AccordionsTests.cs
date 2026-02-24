using SampleAutoTest;
using SampleAutoTest.Pages;
using System.ComponentModel;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class AccordionsTests : BaseTest
    {
        private AccordionsPage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/accordions/");
            return new AccordionsPage(_driver);
        }

        [Test]
        public void OpenJavaScriptPage_ClickStart_WaitMessage()
        {
            var acPage = Page();

            bool actual = acPage
                .WaitAccordionParagraph();

            Assert.That(actual, Is.True);
        }
    }
}
