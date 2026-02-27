using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class ModalsTests : BaseTest
    {
        private ModalsPage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/modals/");
            return new ModalsPage(_driver);
        }

        [Test]
        public void ModalsPage_OpenSimplModal_SimplModalIsVisable()
        {
            var page = Page();

            bool actual = page
                .OpenSimplModal();

            Assert.That(actual, Is.True);
        }
    }
}