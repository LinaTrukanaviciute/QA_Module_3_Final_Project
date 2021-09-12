using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace DrogasWebsite.Pages
{
    public class ProductPage : BasePage
    {
        private IWebElement _productTitle => Driver.FindElement(By.ClassName("pdp-details__name"));
        private IWebElement _buyButton => Driver.FindElement(By.XPath("/html/body/watson-product-details-page/main/div[1]/div[2]/div[1]/div/div[2]/div[2]/watson-buy-button"));
        private IWebElement _maxQuantityWarning => Driver.FindElement(By.CssSelector(".cart-product-quant-n-sum__warning-container"));
        private IWebElement _addProductToBasketButton => Driver.FindElement(By.CssSelector("button.quantity-btn:nth-child(4)"));
        private IWebElement _checkoutButton => Driver.FindElement(By.CssSelector("a.btn:nth-child(2)"));
        private IWebElement _productPrice => Driver.FindElement(By.ClassName("pdp-details__price"));

        public ProductPage(IWebDriver webDriver) : base(webDriver) { }

        public string ReturnProductName()
        {
            return _productTitle.Text;
        }

        public string ReturnProductNameWithoutSymbols()
        {
            string productNameWithSymbols = ReturnProductName();
            string actualProductNameWithtouSymbols = new string(productNameWithSymbols.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            
            return actualProductNameWithtouSymbols;
        }

        public string ReturnProductPrice()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.ClassName("pdp-details__price")));

            return _productPrice.Text;
        }

        public void ClickOnBuyButton()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/watson-product-details-page/main/div[1]/div[2]/div[1]/div/div[2]/div[2]/watson-buy-button")));
            _buyButton.Click();
        }

        public void AddProductToBasket(int quantityToAdd)
        {
            for (int i = 1; i < quantityToAdd; i++)
            {
                try
                {
                    if (_maxQuantityWarning.Displayed == true)
                    {
                        throw new Exception($"Maximum product quantity reached in basket. Message on website: { _maxQuantityWarning.Text }");
                    }
                }
                catch (NoSuchElementException)
                {

                }
                finally
                {
                    try
                    {
                        GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("button.quantity-btn:nth-child(4)")));
                        GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.quantity-btn:nth-child(4)")));
                        _addProductToBasketButton.Click();
                    }
                    catch (StaleElementReferenceException ex) // If element is stale, retry
                    {
                        GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("button.quantity-btn:nth-child(4)")));
                        GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.quantity-btn:nth-child(4)")));
                        _addProductToBasketButton.Click();
                    }
                }
            }
        }

        public void Checkout()
        {
            try
            {
                GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("a.btn:nth-child(2)")));
                GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.btn:nth-child(2)")));
                _checkoutButton.Click();
            }
            catch (StaleElementReferenceException ex) // If element is stale, retry
            {
                GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("a.btn:nth-child(2)")));
                GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.btn:nth-child(2)")));
                _checkoutButton.Click();
            }
        }
    }
}
