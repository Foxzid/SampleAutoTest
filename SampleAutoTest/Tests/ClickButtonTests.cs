using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.ClickButton
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [AllureNUnit]
    public class ClickButtonTests(string browser) : BaseTest(browser)
    {
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
            var cbPage = new ClickElementsPage(_driver);
            cbPage.Open(jsonContains.Url);

            string actual = cbPage
                .ClickAnimal(animal)
                .GetTextButtonClick();

            Assert.That(actual, Is.EqualTo(animalSay));
        }
    }
}