using Gudrunsjoden.HomePage;
using GudrunsjodenConfig.SourceCode;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudrunsjoden.Registration
{
    [TestFixture]
    public class RegistrationTest : RegistrationBase
    {

        [SetUp]
        public void setup()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            homepage = new HomePageBase(driver);
            registration = new RegistrationBase(driver);
        }

        
    }
}
