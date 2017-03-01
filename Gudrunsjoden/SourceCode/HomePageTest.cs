using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Gudrunsjoden.Product;

namespace Gudrunsjoden.HomePage
{
    [TestFixture]
    public class HomePageTest : HomePageBase
    {

        [SetUp]
        public void setup()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            homepage = new HomePageBase(driver);
            products = new ProductBase(driver);
        }

        [Test]
        public void VerifyHomePage()
        {
            VerifyAndCloseTheSubscriptionPopup();
            VerifyTopMenuLinks();

        }


    }
}
