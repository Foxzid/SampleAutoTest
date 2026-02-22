using SampleAutoTest;
using SampleAutoTest.Pages;
using SampleAutoTest.TestHelper;
using System.ComponentModel;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class ClickButtonTests : BaseTest
    {
        public ClickElementsPage Page()
        {
            driver.Navigate().GoToUrl($"{jsonContains.Url}/click-events/");
            return new ClickElementsPage(driver);
        }

        [Test]
        public void ClickCatButton_WaitText()
        {
            var cbPage = Page();

            cbPage
                .ClickCatButton();
            string actual = cbPage.GetTextButtonClick();

            Assert.That(actual, Is.EqualTo(jsonContains.Animal.Cat));
        }

        [Test]
        public void ClickDogButton_WaitText()
        {
            var cbPage = Page();

            cbPage
                .ClickDogButton();
            string actual = cbPage.GetTextButtonClick();

            Assert.That(actual, Is.EqualTo(jsonContains.Animal.Dog));
        }

        [Test]
        public void ClickPigButton_WaitText()
        {
            var cbPage = Page();

            cbPage
                .ClickPigButton();
            string actual = cbPage.GetTextButtonClick();

            Assert.That(actual, Is.EqualTo(jsonContains.Animal.Pig));
        }

        [Test]
        public void ClickCowButton_WaitText()
        {
            var cbPage = Page();

            cbPage
                .ClickCowButton();
            string actual = cbPage.GetTextButtonClick();

            Assert.That(actual, Is.EqualTo(jsonContains.Animal.Cow));
        }
    }
}