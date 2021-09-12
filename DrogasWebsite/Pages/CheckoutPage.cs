using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DrogasWebsite.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement _checkoutQuantity => Driver.FindElement(By.CssSelector("div.cart-item:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > p:nth-child(1) > span:nth-child(1)"));
        private IWebElement _productPriceInCart => Driver.FindElement(By.CssSelector(".cart-item-summary > ul:nth-child(1) > li:nth-child(1) > em:nth-child(2)"));

        public string ReturnProductQuantityFromBasket()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.cart-item:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > p:nth-child(1) > span:nth-child(1)")));
            
            return _checkoutQuantity.Text;
        }

        public string ReturnProductPriceFromBasket()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-item-summary > ul:nth-child(1) > li:nth-child(1) > em:nth-child(2)")));

            return _productPriceInCart.Text;
        }
    }
}
