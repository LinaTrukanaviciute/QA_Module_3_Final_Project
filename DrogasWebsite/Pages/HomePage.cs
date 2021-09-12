using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DrogasWebsite.Pages
{
    public class HomePage : BasePage
    {
        // Index page
        private const string _pageAddress = "https://www.drogas.lt/";
        private IWebElement _cookieButton => Driver.FindElement(By.CssSelector("#onetrust-accept-btn-handler"));
        private IWebElement _searchField => Driver.FindElement(By.CssSelector("form.search-container__form:nth-child(2) > div:nth-child(1) > input:nth-child(2)"));
        private IWebElement _searchButton => Driver.FindElement(By.CssSelector(".search-container__form-icon"));
        private IWebElement _brandBadge => Driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div[1]/div[1]/ul/li[3]/a"));

        public HomePage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != _pageAddress)
                Driver.Url = _pageAddress;
        }

        public void CloseCookies()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#onetrust-accept-btn-handler")));
            _cookieButton.Click();
        }

        public void SearchByText(string textToSearch)
        {
            _searchField.Clear();
            _searchField.SendKeys(textToSearch);
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".search-container__form-icon")));
            _searchButton.Click();
        }

        public void ClickCategoryOnNavBar(string categoryToClick, string subCategoryToClick)
        {
            
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[@title='{categoryToClick}']")));
            IWebElement actualCategory = Driver.FindElement(By.XPath($"//a[@title='{categoryToClick}']"));

            Actions action = new Actions(Driver);
            action.MoveToElement(actualCategory).Perform();

            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[@title='{subCategoryToClick}']")));
            IWebElement actualSubCategory = Driver.FindElement(By.XPath($"//a[@title='{subCategoryToClick}']"));

            actualSubCategory.Click();
        }

        public void ClickOnBrandBadge()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/main/div[1]/div[1]/div[1]/ul/li[3]/a")));
            _brandBadge.Click();
        }
    }
}
