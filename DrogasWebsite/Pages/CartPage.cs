using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DrogasWebsite.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement _continueButton => Driver.FindElement(By.CssSelector(".btn--xl"));
        
        public void ClickOnContinueButton()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".btn--xl")));
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn--xl")));
            _continueButton.Click();
        }
    }
}
