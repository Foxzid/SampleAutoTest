using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using SampleAutoTest.Pages;

namespace SampleAutoTest.Tests.Modals
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [AllureNUnit]
    public class ModalsTests(string browser) : BaseTest(browser)
    {
        [Test]
        [AllureName("Проверка открытия простого модального окна")]
        [AllureDescription("Тест проверяет отображение простого модального окна после нажатия накнопку")]
        [AllureTag("Modals", "UI")]
        [AllureSeverity(SeverityLevel.minor)]
        public void ModalsPage_OpenSimpleModal_SimpleModalIsVisable()
        {
            var page = new ModalsPage(_driver);
            page.Open(jsonContains.Url);

            bool actual = page
                .OpenSimplModal();

            Assert.That(actual, Is.True);
        }

        [Test]
        [AllureName("Валидация данных при отправке формы в модальном окне")]
        [AllureDescription("Тест сравнивает данные из блока информации с введенными ранее")]
        [AllureTag("Modals", "UI")]
        [AllureSeverity(SeverityLevel.critical)]
        public void ModalsPage_OpenFormModal_SendForm()
        {
            var page = new ModalsPage(_driver);
            page.Open(jsonContains.Url);
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