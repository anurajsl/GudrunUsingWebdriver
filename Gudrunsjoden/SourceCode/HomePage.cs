using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using GudrunsjodenConfig.SourceCode;
using Gudrunsjoden.Reports;

namespace Gudrunsjoden.HomePage
{
    public class HomePageBase : Main
    {
        public HomePageBase(IWebDriver Obj)
        {
            driver = Obj;
        }
        public HomePageBase()
        {

        }

        public void VerifyAndCloseTheSubscriptionPopup()
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.FindElement(By.Id(Constants.PopUpContainer));
                driver.FindElement(By.Id(Constants.SubscriptionFiled));
                driver.FindElement(By.CssSelector(Constants.SubscriptionCloseBtn)).Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(Constants.SubscriptionFiled)));
                re.LogStatusReport("pass", "Successfully navigated to home page and closed the Subscription pop-up which was displayed.");
            }
            catch (Exception e)
            {
                re.LogStatusReport("fail", "There is some issue with VerifyAndCloseTheSubscriptionPopup. Kindly trouble shoot with following details: <br>" + e.ToString());
            }

        }
        public void VerifyTopMenuLinks()
        {
            try
            {
                driver.FindElement(By.Id("marketname"));
                driver.FindElement(By.CssSelector(Constants.MenuLink_BytLand));
                driver.FindElement(By.XPath(Constants.MenuLink_Kundservice));
                driver.FindElement(By.LinkText(Constants.MenuLink_MinaSidor));
                driver.FindElement(By.LinkText(Constants.MenuLink_Nyhetsbrev));
                driver.FindElement(By.LinkText(Constants.MenuLink_Butiker));
                driver.FindElement(By.LinkText(Constants.MenuLink_BeställKatalog));
                driver.FindElement(By.CssSelector(Constants.LoginLink));
                re.LogStatusReport("pass", "Verified that the top menu links are all present");
            }
            catch (Exception e)
            {
                re.LogStatusReport("fail", "There is some issue with VerifyTopMenuLinks. Kindly trouble shoot with following details: <br>" + e.ToString());
            }



        }




















    }

}


