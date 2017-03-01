using System;
using System.Net;




namespace Gudrunsjoden.PageObjects
{
    public class Constants
    {

        #region Selectors in webdriver

        public string ClassName = "ClassName";
        public string CssSelector = "CssSelector";
        public string Id = "Id";
        public string LinkText = "LinkText";
        public string Name = "Name";
        public string PartialLinkText = "PartialLinkText";
        public string TagName = "TagName";
        public string XPath = "XPath";


        #endregion



        #region HomePage

        //Login Objects
        public string SubscriptionFiled = "ctl11_popupmail"; 
        public string PopUpContainer = "ctl11_popupContainer";
        public string SubscriptionCloseBtn = "div.popup-close > img";
        public string MenuLink_BytLand  = "a[title=\"Byt land\"]";
        public string MenuLink_Kundservice = "//a[@href='/se/kundservice/kundservice']";
        public string MenuLink_MinaSidor = "Mina sidor";
        public string MenuLink_Nyhetsbrev = "Nyhetsbrev";
        public string MenuLink_Butiker = "Butiker";
        public string MenuLink_BeställKatalog = "Beställ katalog";


        public string LoginLink = "#login > a";
        public string UserNameDisplayField = "//li[@class='top-bar-link user-profile-page-link']";
        public string UserNameField = "User_UserName";
        public string PasswordField = "User_Password";
        public string LoginButton = "span.padding-half-half";
        public string LogOutLink = "//li[@class='top-bar-link user-log-out-link']";
        public string CreateAccountLink = "Skapa konto";
        public string ForgotPwdLink = "Jag har glömt mitt lösenord";


        #endregion



    }
}
