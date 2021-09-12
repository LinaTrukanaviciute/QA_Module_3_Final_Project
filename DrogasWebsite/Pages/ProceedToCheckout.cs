using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DrogasWebsite.Pages
{
    public class ProceedToCheckout : BasePage
    {
        private IWebElement _checkoutAsGuestButton => Driver.FindElement(By.CssSelector(".cont-btn"));

        public ProceedToCheckout(IWebDriver webDriver) : base(webDriver) { }

        public void ContinueAsGuest()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cont-btn")));
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".cont-btn")));
            _checkoutAsGuestButton.Click();
        }
    }
}
