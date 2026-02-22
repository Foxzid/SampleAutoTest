using SampleAutoTest;
using SampleAutoTest.Pages;
using SampleAutoTest.TestHelper;
using System.ComponentModel;


[TestFixture]
public class JavaScriptTests : BaseTest
{
    public JavaScriptPage Page()
    {
        driver.Navigate().GoToUrl($"{TestSettings.Url}");
        return new JavaScriptPage(driver);
    }

    //[Test]
    //public void OpenJavaScriptPage_ClickStart_WaitMessage()
    //{
    //    var jsPage = Page();

    //    jsPage
    //        .StartRocket();
    //    string actual = jsPage.WaitMessageText();

    //    Assert.That(actual, Is.EqualTo("Liftoff!"));
    //}
}
