using DrogasWebsite.Pages;
using DrogasWebsite.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DrogasWebsite.Tests
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static HomePage homePage;
        public static SearchResultPage searchResultPage;
        public static ProductPage productPage;
        public static ProceedToCheckout proceedToCheckout;
        public static CartPage cartPage;
        public static CheckoutPage checkoutPage;
        public static BrandListPage brandListPage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();

            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            searchResultPage = new SearchResultPage(driver);
            productPage = new ProductPage(driver);
            proceedToCheckout = new ProceedToCheckout(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            brandListPage = new BrandListPage(driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
           driver.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                FailureScreenshot.TakeScreenshot(driver);
            }
        }
    }
}
