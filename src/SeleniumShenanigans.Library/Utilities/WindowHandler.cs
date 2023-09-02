using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumShenanigans.Library.Utilities
{
    public class WindowHandler
    {
        private ChromeDriver _driver;
        private readonly string _mainWindowHandle;

        public WindowHandler(ChromeDriver driver) {
            _driver = driver;
            _mainWindowHandle = _driver.CurrentWindowHandle;
        }

        public WindowHandler NewTab()
        {
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            return this;
        }

        public WindowHandler CloseTab()
        {
            _driver.Close();
            return this;
        }

        public WindowHandler CloseTab(string handle)
        {
            var currentHandler = _driver.CurrentWindowHandle;

            if (currentHandler != handle)
                _driver.SwitchTo().Window(handle);

            if (currentHandler != handle)
                CloseTab(handle, currentHandler);
            else
                _driver.Close();

            return this;
        }

        private void CloseTab(string closeHandle, string returnHandle)
        {
            _driver.SwitchTo().Window(closeHandle);
            _driver.Close();
            _driver.SwitchTo().Window(returnHandle);
        }

        public WindowHandler OpenInTab(string url)
        {
            NewTab();
            _driver.Navigate().GoToUrl(url);
            return this;
        }

        public WindowHandler OpenInTab(IWebElement elm, Action<IWebElement> trigger)
            => OpenInTab(elm, trigger, out var _);

        public WindowHandler OpenInTab(IWebElement elm, Action<IWebElement> trigger, out string tabHandle)
        {
            var beforeHandles = _driver.WindowHandles;
            trigger(elm);

            var newHandles = _driver.WindowHandles.Except(beforeHandles);

            if (!newHandles.Any())
            {
                tabHandle = null;
                return this;
            }

            var handler = newHandles.First();
            _driver.SwitchTo().Window(handler);
            tabHandle = handler;

            return this;
        }

        public WindowHandler ActionInTab(IWebElement elm, Action<IWebElement> trigger, Action<ChromeDriver> action, bool closeAfterAction = true)
        {
            var currentHandler = _driver.CurrentWindowHandle;

            OpenInTab(elm, trigger, out var tabHandle);

            if (tabHandle == null)
                return this;

            action(_driver);

            if (closeAfterAction) {
                _driver.Close();
                _driver.SwitchTo().Window(currentHandler);
            }

            return this;
        }
    }
}
