using Autofac;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PetShopProject.Test.Helper;
using PetShopProject.Test.UITest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PetShopProject.Test.UITest
{
    [Parallelizable]
    public class UITest : IDisposable
    {
        private IContainer Container;
        IWebDriver webDriver;
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BrowserDriver>().As<IBrowserDriver>();
            Container = builder.Build();
            var driver = new DriverUtilities(Container, BrowserTypeEnum.Chrome);
            driver.GoToUrl(Urls.BaseUrlUI);
            webDriver = driver.GetWebDriver();
        }
        [Test]
        public void ProductPage_ShouldLoadAndNavigateToCreateProduct()
        {

            webDriver.FindElement(By.LinkText("Products")).Click();
            webDriver.FindElement(By.LinkText("Create New")).Click();
            webDriver.FindElement(By.Id("name")).SendKeys("net Product");
            webDriver.FindElement(By.Id("description")).SendKeys("description dcsc");
            webDriver.FindElement(By.Id("productType")).SendKeys("1");
            webDriver.FindElement(By.Id("price")).SendKeys("200");
            webDriver.FindElement(By.Id("Create")).Click();
        }

        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}
namespace PetShopProject.Test.UITest
{
    [Parallelizable]
    public class UITest2 : IDisposable
    {
        private IContainer Container;
        IWebDriver webDriver;
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BrowserDriver>().As<IBrowserDriver>();
            Container = builder.Build();
            var driver = new DriverUtilities(Container, BrowserTypeEnum.Chrome);
            driver.GoToUrl(Urls.BaseUrlUI);
            webDriver = driver.GetWebDriver();


        }
        [Test]
        public void ProductPage_ShouldLoadAndNavigateToCreateProduct()
        {

            webDriver.FindElement(By.LinkText("Products")).Click();
            webDriver.FindElement(By.LinkText("Create New")).Click();
            webDriver.FindElement(By.Id("name")).SendKeys("net Product");
            webDriver.FindElement(By.Id("description")).SendKeys("description dcsc");
            webDriver.FindElement(By.Id("productType")).SendKeys("1");
            webDriver.FindElement(By.Id("price")).SendKeys("200");
            webDriver.FindElement(By.Id("Create")).Click();
        }

        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}