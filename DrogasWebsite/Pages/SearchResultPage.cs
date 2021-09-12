using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace DrogasWebsite.Pages
{
    public class SearchResultPage : BasePage
    {
        private IWebElement _firstProduct => Driver.FindElement(By.Id("Product1"));

        public SearchResultPage(IWebDriver webDriver) : base(webDriver) { }

        public void ClickOnFirstProduct()
        {
            GetWait().Until(ExpectedConditions.ElementExists(By.Id("Product1")));
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.Id("Product1")));
            _firstProduct.Click();
        }

        public List<string> ReturnBreadCrumbs()
        {
            List<string> breadCrumbs = new List<string>();

            string breadCrumbRoot = Driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/div[1]/ul/li[1]/a/p")).Text.Trim();
            string breadCumbBranch1 = Driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/div[1]/ul/li[2]/a/p")).Text.Trim();
            string breadCumbBranch2 = Driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/div[1]/ul/li[3]/a/p")).Text.Trim();
            string breadCumbBranch3 = Driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/div[1]/ul/li[4]/a/p")).Text.Trim();

            breadCrumbs.Add(breadCrumbRoot); // 0
            breadCrumbs.Add(breadCumbBranch1); // 1
            breadCrumbs.Add(breadCumbBranch2); // 2
            breadCrumbs.Add(breadCumbBranch3); // 3

            return breadCrumbs;
        }
    }
}
