using Autofac;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Test.UITest.Infrastructure
{
    public class DriverUtilities : IDriverUtilities
    {
        private IContainer Container;

        IWebDriver webDriver;
        public DriverUtilities(IContainer container, BrowserTypeEnum browserType)
        {
            Container = container;

            webDriver = GetWebDriver(browserType);
        }
        public void GoToUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public IWebDriver GetWebDriver() => webDriver;
        private IWebDriver GetWebDriver(BrowserTypeEnum browserType)
        {
            var browserDriver = Container.Resolve<IBrowserDriver>();
            return browserType switch
            {
                BrowserTypeEnum.Chrome => browserDriver.GetChromeDriver(),
                BrowserTypeEnum.Firefox => browserDriver.GetFirefoxDriver(),
                _ => browserDriver.GetChromeDriver(),
            };
        }
    }
}
