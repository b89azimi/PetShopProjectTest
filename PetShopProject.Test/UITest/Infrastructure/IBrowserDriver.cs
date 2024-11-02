using OpenQA.Selenium;

namespace PetShopProject.Test.UITest.Infrastructure
{
    public interface IBrowserDriver
    {
        IWebDriver GetChromeDriver();
        IWebDriver GetFirefoxDriver();
    }
}