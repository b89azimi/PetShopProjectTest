using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopProject.Test.Helper;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PetShopProject.Test.UITest.Infrastructure
{
    public class BaseWebDriver : IDisposable
    {
        IWebDriver webDriver;
        [OneTimeTearDown]
        public void Dispose()
        {
            webDriver.Dispose();
        }

        public void quit() => webDriver.Quit();


    }
}
