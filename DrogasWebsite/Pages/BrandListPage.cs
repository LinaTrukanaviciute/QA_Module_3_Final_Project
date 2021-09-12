using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DrogasWebsite.Pages
{
    public class BrandListPage : BasePage
    {
        public BrandListPage(IWebDriver webDriver) : base(webDriver) { }

        public void ClickBrandName(string brandName)
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[.='{brandName}']")));
            IWebElement BrandNameElement = Driver.FindElement(By.XPath($"//a[.='{brandName}']"));
            BrandNameElement.Click();
        }
    }
}
