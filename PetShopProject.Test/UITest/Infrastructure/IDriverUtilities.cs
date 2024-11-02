using OpenQA.Selenium;

namespace PetShopProject.Test.UITest.Infrastructure
{
    public interface IDriverUtilities
    {
        IWebDriver GetWebDriver();
        void GoToUrl(string url);
    }
}