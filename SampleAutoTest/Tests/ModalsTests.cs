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
        public void ModalsPage_OpenSimpleModal_SimpleModalIsVisable()
        {
            var page = Page();

            bool actual = page
                .OpenSimplModal();

            Assert.That(actual, Is.True);
        }

        [Test]
        public void ModalsPage_OpenFormModal_SendForm()
        {
            var page = Page();
            page.OpenFormModal();
            string expectedName = page.SendNameModalForm("John");
            string expectedEmail = page.SendEmailModalForm("JohnAuto@test.csh");
            string expectedMessage = page.SendMessageModalForm("Hello! I am an autotest!");

            page.ClickSubmitModalForm();

            string actualName = page.ActualNameModalForm();
            string actualEmail = page.ActualEmailModalForm();
            string actualMessage = page.ActualMessageModalForm();

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.That(actualEmail, Is.EqualTo(expectedEmail));
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }
    }
}