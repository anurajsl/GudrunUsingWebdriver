using Gudrunsjoden.HomePage;
using Gudrunsjoden.Product;
using Gudrunsjoden.Registration;
using Gudrunsjoden.Reports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gudrunsjoden.TestSuite
{
    [TestFixture]
    public class TestSuite : SuiteBase
    {

        [SetUp]
        public void setup()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            homepage = new HomePageBase(driver);
            products = new ProductBase(driver);
            registration = new RegistrationBase(driver);


        }


        [Test]
        [NUnit.Framework.Category("CheckoutByNonRegisteredUser")]
        public void A_Checkout_NonRegisteredUser()
        {
            re.StartTest("Non Registered User Checkout ", "This test is performed for verifying the checkout functionality of the application by a non-registered user weho registers as a new-user at the time of checkout.");
            homepage.VerifyAndCloseTheSubscriptionPopup();
            homepage.VerifyTopMenuLinks();
            MenuNavigation("Kläder", "Nyinkommet");
            products.VerifyTheProductListingPage();
            products.AddProductToTheCart();
            products.VerifyMiniCart();
            products.CheckOutTheProduct();
            re.EndTest();
        }
    }
}
