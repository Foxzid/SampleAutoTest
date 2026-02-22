using DemoQATests;
using DemoQATests.Pages;
using DemoQATests.TestHelper;

[TestFixture]
public class TextBoxTests : BaseTest
{
    public TextBoxPage Report()
    {
        driver.Navigate().GoToUrl($"{TestHelp.Url}/text-box");
        return new TextBoxPage(driver);
    }
    [Test]
    public void Test1()
    {
        TextBoxPage textBoxPage = Report();

        textBoxPage
            .FillingBoxFields("Bob", "bob@test.com", "ул. Пушкина, д. Колотушкина", "ул. Пушкина, д. Колотушкина");

        Assert.Pass();
    }
}
