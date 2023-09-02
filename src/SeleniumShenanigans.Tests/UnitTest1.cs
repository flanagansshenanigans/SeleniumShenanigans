using SeleniumShenanigans.Library.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumShenanigans.Tests;

[TestClass]
public class UnitTest1
{
    private ChromeDriver driver;
    private WindowHandler handler;
    
    [TestInitialize]
    public void Setup()
    {
        driver = new ChromeDriver();
        handler = new WindowHandler(driver);
    }

    [TestCleanup]
    public void Cleanup()
    {
        driver.Quit();
    }

    [TestMethod]
    public void Can_Get_Articles_Titles_From_Article_Page()
    {
        driver.Navigate().GoToUrl("https://www.theregister.co.uk");
        var articles = driver.FindElements(By.TagName("article"));
        var actions = new Actions(driver);
        var titles = new List<string>();

        foreach (var article in articles.Where(o => o.Displayed))
            handler.ActionInTab(article, actions.CtrlClick, (driver) =>
            {
                if (!driver.Url.Contains("theregister.com"))
                    return;

                var title = driver.FindElements(By.TagName("h1"));
                titles.AddRange(title.Where(o => !string.IsNullOrEmpty(o.Text)).Select(o => o.Text));
            });

        Assert.IsTrue(titles.Count > 0);
    }
}