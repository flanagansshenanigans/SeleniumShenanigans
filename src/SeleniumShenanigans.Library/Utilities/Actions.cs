using OpenQA.Selenium;

namespace SeleniumShenanigans.Library.Utilities
{
    public class Actions : OpenQA.Selenium.Interactions.Actions
    {
        public Actions(IWebDriver driver) : base(driver) {}

        public void CtrlClick(IWebElement elm)
            => KeyDown(Keys.Control)
                .Click(elm)
                .Perform();
    }
}
