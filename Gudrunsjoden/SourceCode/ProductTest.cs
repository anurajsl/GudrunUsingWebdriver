using Gudrunsjoden.HomePage;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using Gudrunsjoden.Reports;
using GudrunsjodenConfig.SourceCode;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gudrunsjoden.Product
{
    [TestFixture]
    public class ProductTest : ProductBase
    {

        [SetUp]
        public void setup()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            homepage = new HomePageBase(driver);
        }

        [Test]
        public void AddaProductToTheCartAndCheckOut()
        {
            homepage.VerifyAndCloseTheSubscriptionPopup();
            MenuNavigation("Kläder", "Nyinkommet");
            VerifyTheProductListingPage();
            AddProductToTheCart();
            VerifyMiniCart();
            CheckOutTheProduct();
        }








    }
}
