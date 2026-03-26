using Allure.Net.Commons;
using Allure.NUnit.Attributes;
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
        [AllureName("Проверка отображения текста после наждатия на кнопку")]
        [AllureDescription("Тест сравнивает полученный и ожидаемый текст после нажатия на кнопку")]
        [AllureTag("Сlick-events", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
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