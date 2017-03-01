using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GudrunsjodenConfig.SourceCode;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Gudrunsjoden.Reports;
using System.Drawing;

namespace Gudrunsjoden.Product
{
    public class ProductBase : Main
    {
        public ProductBase(IWebDriver Obj)
        {
            driver = Obj;
        }
        public ProductBase()
        {

        }

        public void VerifyTheProductListingPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='articlemiddle']/div/div/p/img")));
            int ProductCount = Convert.ToInt32(driver.FindElements(By.XPath("//li[@class='slide-page page-nr-1']/ul/li")).Count);
            re.LogStatusReport("pass", "Successfully verified the product listing page and the number of items listed on the first page is " + ProductCount);
            ResolutionsTestForPLP();

        }
        public void ResolutionsTestForPLP()
        {
            driver.Manage().Window.Size = new Size(320, 568);
            //Console.WriteLine(driver.Manage().Window.Size);
            //driver.Navigate().Refresh();


            //WaitFor(3);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,600)");

            driver.Manage().Window.Size = new Size(568, 320);
            //Console.WriteLine(driver.Manage().Window.Size);
            //driver.Navigate().Refresh();

            //WaitFor(3);
            IJavaScriptExecutor js3 = (IJavaScriptExecutor)driver;
            js3.ExecuteScript("scroll(0,600)");

            driver.Manage().Window.Size = new Size(320, 480);
            //Console.WriteLine(driver.Manage().Window.Size);
            //driver.Navigate().Refresh();
            //WaitFor(3);
            
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("scroll(0,600)");

            driver.Manage().Window.Size = new Size(1024, 768);
            //Console.WriteLine(driver.Manage().Window.Size);
            //driver.Navigate().Refresh();
            //WaitFor(3);

            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            js2.ExecuteScript("scroll(0,600)");

           

            driver.Manage().Window.Maximize();
            driver.Navigate().Refresh();
            WaitForPageLoad(6000);

            driver.Navigate().GoToUrl("http://design.google.com/resizer");
            WaitForPageLoad(6000);
            driver.FindElement(By.Id("url-input")).SendKeys("http://test.gudrunsjoden.com/se/klader/sommar-2016/nyinkommet-sommar");
            driver.FindElement(By.Id("url-input")).SendKeys(Keys.Enter);
            WaitForPageLoad(6000);
            TakeScreenShots("Final2_");
            re.LogStatusReport("pass", "The different browser resolutions can be viewed here . Snapshot below: " + re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));

            driver.FindElement(By.XPath("//div[@id='toolbar-container']/div/iron-selector/div[3]/iron-icon")).Click();
            WaitFor(2);
            driver.FindElement(By.CssSelector("div[name=\"720\"]")).Click();
            WaitFor(2);
            TakeScreenShots("Final1_");
            re.LogStatusReport("pass", "The different browser resolutions can be viewed here . Snapshot below: " + re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));
            driver.FindElement(By.CssSelector("div[name=\"600\"]")).Click();
            WaitFor(2);
            TakeScreenShots("Final2_");
            re.LogStatusReport("pass", "The different browser resolutions can be viewed here . Snapshot below: " + re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));
            driver.FindElement(By.CssSelector("div[name=\"360\"]")).Click();
            WaitFor(2);
            TakeScreenShots("Final3_");
            re.LogStatusReport("pass", "The different browser resolutions can be viewed here . Snapshot below: " + re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));
            driver.FindElement(By.CssSelector("div[name=\"600\"]")).Click();
            WaitFor(2);
            TakeScreenShots("Final4_");
            re.LogStatusReport("pass", "The different browser resolutions can be viewed here . Snapshot below: " + re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));
            driver.FindElement(By.CssSelector("div[name=\"1024\"]")).Click();
            WaitFor(2);
            TakeScreenShots("Final5_");
            re.LogStatusReport("pass", "The different browser resolutions can be viewed here . Snapshot below: " + re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));

            driver.Navigate().GoToUrl("http://test.gudrunsjoden.com/se/klader/sommar-2016/nyinkommet-sommar");
            WaitForPageLoad(6000);
        }
        public void ClickOnThProduct(string itemCount)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.FindElement(By.XPath("//li[@id='Content_Content_ctl03_m_currentPageContainer']/ul/li[" + itemCount + "]/a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("modalProduct")));
            string ProductName = driver.FindElement(By.Id("ProductTitle")).Text;
            re.LogStatusReport("pass", "Successfully clicked on the first product");
        }
        public void VerifyProductDetailPopup()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("modalProduct")));
            driver.FindElement(By.Id("ProductTitle"));
            driver.FindElement(By.Id("product-topholder"));
            driver.FindElement(By.Id("ProductImageList"));
            driver.FindElement(By.Id("ProductMainImage"));
            driver.FindElement(By.Id("ProductLeft"));
            driver.FindElement(By.Id("ProductDetailImage"));
            driver.FindElement(By.Id("ProductColourAndPatterns"));
            driver.FindElement(By.Id("ProductOrderInfoSize"));
            driver.FindElement(By.Id("ProductOrderInfoQuantity"));
            driver.FindElement(By.Id("ProductOrderInfoButton"));
            driver.FindElement(By.XPath("//div[@class='facebook-like']"));
            driver.FindElement(By.XPath("//div[@class='pin_it_iframe_widget']"));
            driver.FindElement(By.XPath("//a[contains(text(),'Vilken storlek har jag?')]"));
            re.LogStatusReport("pass", "Verified that the product detail pop-up contains all the required items.");
        }
        public void SelectTheColor(string color)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            if (color == "red")
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@id='product-colors']/li/div")));
                driver.FindElement(By.XPath("//ul[@id='product-colors']/li/div")).Click();
                WaitFor(1);
            }
            else if (color == "blue")
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@id='product-colors']/li[2]/div")));
                driver.FindElement(By.XPath("//ul[@id='product-colors']/li[2]/div")).Click();
                WaitFor(1);
            }
            else if (color == "black")
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@id='product-colors']/li[3]/div")));
                driver.FindElement(By.XPath("//ul[@id='product-colors']/li[3]/div")).Click();
                WaitFor(1);
            }
            re.LogStatusReport("pass", "We have sucessfully selected the " + color + "black color");

        }
        public void SelectTheSize(string size)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Size")));
            SelectElement selectSize = new SelectElement(driver.FindElement(By.Id("Size")));
            selectSize.SelectByText(size);
            WaitFor(1);
            re.LogStatusReport("pass", "We have selected the size as " + size);
        }
        public void ProductQuantity(string prodQty)
        {
            driver.FindElement(By.Id("Quantity")).Clear();
            re.LogStatusReport("pass", "In the product quantity field, we have cleared the default quantitiy");
            WaitFor(1);
            driver.FindElement(By.Id("Quantity")).SendKeys(prodQty);
            re.LogStatusReport("pass", "Enetred the no of quantity as " + prodQty);
        }
        public void AddProductToTheCart()
        {
            try
            {
                ClickOnThProduct("1");
                VerifyProductDetailPopup();
                //driver.FindElement(By.XPath("//div[@id='ProductImageList']/div/div/div[2]/img")).Click();
                SelectTheColor(Color);
                SelectTheSize(Size);
                ProductQuantity(NoOfItem);
                driver.FindElement(By.Id("product-topholder")).Click();
                driver.FindElement(By.Id("AddToCart")).Click();
                WaitForTextPresent("Produkten har lagts i varukorgen");
                driver.FindElement(By.Id("modalClose")).Click();
                WaitFor(2);
            }
            catch (Exception e)
            {
                re.LogStatusReport("fail", "There is some issue with AddProductToTheCart. Kindly trouble shoot with following details: <br>" + e.ToString());
            }            
        }
        public void VerifyMiniCart()
        {
            Assert.AreEqual(NoOfItem, driver.FindElement(By.Id("minishoppingcartquantity")).Text);
            re.LogStatusReport("pass", "Successfully verified that the minicart contains the product that have been selected for purchase");
        }
        public void CheckOutTheProduct()
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl(Server + "/checkout");
                re.LogStatusReport("pass", "Successfully navigated to the checkout page");
                WaitForPageLoad(6000);
                //VerifyCheckOutPageValidation();
                RegistrationFromCheckoutPage(Förnamn, Efternamn, adress, postnummer, stad, telefon, epost, heardfrom);

                driver.FindElement(By.Id("Content_Content_c_checkBoxTerms")).Click();
                driver.FindElement(By.Id("Content_Content_cbBecomeMember")).Click();               

                driver.FindElement(By.Id("Content_Content_m_linkButtonConfirmOrder")).Click();
                re.LogStatusReport("pass", "Sucessfully checked the Terms and Become Members checkboxes and clicked the Confirm Order button");
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Order Completed Sucessfully")));
                
            }
            catch (Exception e)
            {
                TakeScreenShots("FinalError_");
                re.LogStatusReport("fail", "There is some issue with CheckOutTheProduct. Kindly trouble shoot with following details: <br>" + e.ToString() + " Snapshot below: " +
                                re.test.AddScreenCapture(ScreeShotsDirectory + ImageName));
            }           
        }
        public void VerifyCheckOutPageValidation()
        {
            try
            {
                driver.FindElement(By.Id("Content_Content_m_linkButtonConfirmOrder")).Click();
                WaitForTextPresent("Förnamn saknas");
                WaitForTextPresent("Efternamn saknas");
                WaitForTextPresent("Adress saknas");
                WaitForTextPresent("Välj från listan hur du kom i kontakt med Gudrun Sjödén");
                WaitForTextPresent("Du måste godkänna köpinformationen för att bekräfta ordern.");
                re.LogStatusReport("pass", "Sucessfully verified the field validations in checkout page");
            }
            catch (Exception e)
            {
                re.LogStatusReport("fail", "There is some issue with VerifyCheckOutPageValidation. Kindly trouble shoot with following details: <br>" + e.ToString());
            }


        }
    }
}
