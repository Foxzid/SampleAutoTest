using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests
{
    [TestFixture]
    public class ClickButtonTests : BaseTest
    {
        public ClickElementsPage Page()
        {
            _driver.Navigate().GoToUrl($"{jsonContains.Url}/click-events/");
            return new ClickElementsPage(_driver);
        }

        [TestCase("Cat", "Meow!")]
        [TestCase("Dog", "Woof!")]
        [TestCase("Pig", "Oink!")]
        [TestCase("Cow", "Moo!")]
        public void ClickEventsPage_ClickAnimalButton_WaitText(string animal, string animalSay)
        {
            var cbPage = Page();

            string actual = cbPage
                .ClickAnimal(animal)
                .GetTextButtonClick();

            Assert.That(actual, Is.EqualTo(animalSay));
        }
    }
}