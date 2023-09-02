using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumShenanigans.Library.Utilities
{
/*    public class Tabs
    {
        private WebDriver _driver;

        public Tabs(WebDriver driver)
            => _driver = driver;

        public void ExecuteInTab(this IWebElement element, Action<IWebDriver> action)
        {
            var tab = _driver.SwitchTo().NewWindow(WindowType.Tab);

            var currentWindow = _driver.CurrentWindowHandle;
            var allWindows = _driver.WindowHandles;

            foreach (var window in allWindows)
            {
                if (window != currentWindow)
                {
                    _driver.SwitchTo().Window(window);
                    action(_driver);
                }
            }

            _driver.SwitchTo().Window(currentWindow);
        }
    }*/
}
