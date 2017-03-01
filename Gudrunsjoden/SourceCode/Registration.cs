using GudrunsjodenConfig.SourceCode;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Gudrunsjoden.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudrunsjoden.Registration
{
    public class RegistrationBase : Main
    {
        public RegistrationBase(IWebDriver Obj)
        {
            driver = Obj;
        }
        public RegistrationBase()
        {

        }
        public void RegistrationFromCheckoutPage(string Förnamn, string Efternamn, string adress, string postnummer, string stad, string telefon, string epost, string heardfrom)
        {
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxFirstName]")).SendKeys(Förnamn);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxLastName]")).SendKeys(Efternamn);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxAddress]")).SendKeys(adress);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxAddress2]"));
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxZip]")).SendKeys(postnummer);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxCity]")).SendKeys(stad);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxDaytimePhoneNumber]")).SendKeys(telefon);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxEmail]")).SendKeys(epost);

            SelectElement FoundBy = new SelectElement(driver.FindElement(By.Id("Content_Content_RegisterControl_m_dropDownListCodeOfOrigin")));
            FoundBy.SelectByText(heardfrom);
            WaitFor(2);
        }
    }
}
