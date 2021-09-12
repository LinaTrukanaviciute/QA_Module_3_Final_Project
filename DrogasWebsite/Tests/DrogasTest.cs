using NUnit.Framework;
using System.Collections.Generic;

namespace DrogasWebsite.Tests
{
    public class DrogasTest : BaseTest
    {
        [Test]
        public static void CheckIfFirstDisplayedProductMatchesTheSearch()
        {
            string expectedProductName = "loreal";

            homePage.NavigateToPage();
            homePage.CloseCookies();
            homePage.SearchByText(expectedProductName);

            searchResultPage.ClickOnFirstProduct();

            string actualProductName = productPage.ReturnProductNameWithoutSymbols().ToLower();

            Assert.IsTrue(actualProductName.Contains(expectedProductName.ToLower()), "Product title does not contain the search phrase");
        }

        [Test]
        public static void CheckIfBreadCrumbsMatchesChosenCategories()
        {
            string expectedCategory = "Odai";
            string expectedSubCategoryHeading = "Prausimasis";
            string expectedSubCategory = "Dušo geliai, kremai";

            List<string> expectedBreadCrumbs = new List<string>() { "DROGAS", expectedCategory, expectedSubCategoryHeading, expectedSubCategory };

            homePage.NavigateToPage();
            homePage.CloseCookies();
            homePage.ClickCategoryOnNavBar(expectedCategory, expectedSubCategory);
            List<string> actualBreadCrumbs = searchResultPage.ReturnBreadCrumbs();
            //   0  >     1    >         2          >     3
            // Root > category > subCategoryHeading > subCategory

            Assert.AreEqual(expectedBreadCrumbs, actualBreadCrumbs, "Category breadcrumbs are incorrect");
        }

        [Test]
        public static void CheckAddedProductQuantityAgainstQuantityInBasket()
        {
            string productName = "pudra";
            int expectedQuantityInBasket = 2;

            homePage.NavigateToPage();
            homePage.CloseCookies();
            homePage.SearchByText(productName);

            searchResultPage.ClickOnFirstProduct();

            productPage.ClickOnBuyButton();
            productPage.AddProductToBasket(expectedQuantityInBasket); // check if limit is reached or not
            productPage.Checkout();

            proceedToCheckout.ContinueAsGuest();

            cartPage.ClickOnContinueButton();

            string actualQuantity = checkoutPage.ReturnProductQuantityFromBasket();

            Assert.AreEqual(expectedQuantityInBasket, 
                            int.Parse(actualQuantity), 
                            $"Incorrect product quantity in basket - Expected quantity: { expectedQuantityInBasket} Actual quantity: { actualQuantity }");
        }

        [Test]
        public static void CheckAddedProductPriceAgainstPriceInBasket()
        {
            // Only works when product quantity is 1
            string productName = "lupdazis";

            homePage.NavigateToPage();
            homePage.CloseCookies();
            homePage.SearchByText(productName);

            searchResultPage.ClickOnFirstProduct();

            string displayedProductPrice = productPage.ReturnProductPrice();
            productPage.ClickOnBuyButton();
            productPage.Checkout();

            proceedToCheckout.ContinueAsGuest();

            cartPage.ClickOnContinueButton();
            string displayedPriceInCart = checkoutPage.ReturnProductPriceFromBasket();

            Assert.AreEqual(displayedProductPrice,
                            displayedPriceInCart,
                     $"Product price from product page, does not match product price in cart - Expected price: { displayedProductPrice } Actual price: { displayedPriceInCart }");
        }

        [Test]
        public static void CheckIfFirstDisplayedProductMatchesSelectedProductBrand()
        {
            string expectedBrandName = "7 days";
            homePage.NavigateToPage();
            homePage.CloseCookies();
            homePage.ClickOnBrandBadge();
            brandListPage.ClickBrandName(expectedBrandName.ToUpper());
            searchResultPage.ClickOnFirstProduct();
            string actualProductName = productPage.ReturnProductNameWithoutSymbols().ToLower();

            Assert.IsTrue(actualProductName.Contains(expectedBrandName.ToLower()), 
                   $"Product title does not contain the brand name '{ expectedBrandName }'\nProduct title: { actualProductName }");
        }

    }
}

