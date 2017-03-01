using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Selenium;
using System.Text;
using System.Globalization;
using Gudrunsjoden.PageObjects;
using Gudrunsjoden.HomePage;
using GudrunsjodenConfig;
using Gudrunsjoden.Product;
using Gudrunsjoden.Registration;
using System.Reflection;
using Gudrunsjoden.Reports;

namespace GudrunsjodenConfig.SourceCode
{
    /// <summary>
    /// Contains the reusable object actions, whcih we are used to design the page actions.
    /// </summary>

    public class Main
    {


        public IWebDriver driver;
        public Actions bulider;
        public Process _process;
        public static IWebDriver Driver;
        public static ISelenium Selenium;
        public static string CurrentClassName;
        public WebDriverWait wait;
        public SelectElement Select;
        public SelectElement SelectPaidWith;
        public SelectElement SelectCountry;
        public SelectElement SearchOrderBy;
        public Screenshot ScreenshotDriver;
        public Screenshot ss;
        public IWebElement myDynamicElement;
        public IMouse mouse;
        public ICoordinates cordinates;
        public Constants Constants = new Constants();
        public FrontEnd FrontEnd = new FrontEnd();
        string ObjectDescription;





        //UesrLogin        
        public IWebElement LoginLink;
        public IWebElement UserNameField;
        public IWebElement PasswordField;
        public IWebElement LoginButton;

        public IWebElement ContentTabInPages;
        public IWebElement SearchIcons;

        public IWebElement MainMenu;
        public IWebElement SubMenu1;


        //IWebElement sourceElement = 
        //IWebElement targetElement = 


        public SelectElement selectRevenuestream;
        public SelectElement SelectUnitPrice;
        public SelectElement SelectCurrencyDropdown;
        public SelectElement SelectCountryDropDown;

        #region ObjectReference

        public HomePageBase homepage;
        public ProductBase products;
        public RegistrationBase registration;

        //public Constants Constants;


        #endregion

        public string Förnamn = "Demo";
        public string Efternamn = "User";
        public string adress = "Block B2, Stockholm, Sweden";
        public string postnummer = "11223";
        public string stad = "Stockholm";
        public string telefon = "9526011441";
        public string epost = "demouser_" + DateTime.Now.ToString("hh_mm_ss_ffff") + "@demomail.com";
        public string heardfrom = "Elle";
        
        public string Server = ConfigManager.GetConfigValue("ServerName");
        public double TIMEOUT = 80000;

        public string ProductName;
        public string Color = "black";
        public string Size = "L/XL";
        public string NoOfItem = "30";

        public static string ImageName;




        public string TestDataPath = Directory.GetCurrentDirectory().Replace("Gudrunsjoden\\bin\\Debug", "uploads");
        public string XmlPath = "D:\\Gudrunsjoden-SourceCode\\Gudrunsjoden\\GudrunsjodenConfig\\TestData\\Common";

        public Stopwatch sw;
        DateTime _startTime;


        [TestFixtureSetUp]

        public void setup()
        {

            #region For Normal Use

            ChooseBrowser(ConfigManager.GetConfigValue("Browser"));
            bulider = new Actions(driver);
            FirefoxProfile profile = new FirefoxProfile();
            profile.EnableNativeEvents = true;

            #endregion

            driver.Navigate().GoToUrl(Server);
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(9));
            //string s=driver.CurrentWindowHandle;
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();

        }


        [TestFixtureTearDown]
        public void stepdown()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        public static OpenQA.Selenium.Interactions.Actions GetSeleniumActions()
        {
            return new OpenQA.Selenium.Interactions.Actions(GudrunsjodenConfig.SourceCode.Main.Driver);
        }

        public static string HTMLResultDirectory
        {

            get { return BaseDirectory.Replace(Path.GetFileName(Environment.CurrentDirectory) + "$", "TestResult\\HTMLPage"); }
        }
        public static string BaseDirectory
        {
            get { return Directory.GetCurrentDirectory().Replace("Gudrunsjoden\\bin\\Debug", "") + "$"; }
        }



        public static string XMLDir
        {
            get { return BaseDirectory.Replace(Path.GetFileName(Environment.CurrentDirectory) + "$", "TestResult\\XML\\"); }
        }

        public static string ExcelDir
        {
            get { return BaseDirectory.Replace(Path.GetFileName(Environment.CurrentDirectory) + "$", "TestResult\\Excel\\"); }
        }

        public static string ScreeShotsDirectory
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\Gudrunsjoden\\bin\\Debug", "\\TestReports\\" + DateTime.Now.ToString("dd-MMM-yyyy")) + "\\"; }
        }

        public static string ReportsDirectory
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\Gudrunsjoden\\bin\\Debug", "\\TestReports\\"); }
        }




        public void ChooseBrowser(string browserName)
        {
            switch (browserName)
            {
                case "chrome":

                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--test-type");
                    string driverpath = Directory.GetCurrentDirectory().Replace("\\Gudrunsjoden\\bin\\Debug", "\\Chromedriver");
                    driver = new ChromeDriver(driverpath);

                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":

                    DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                    capabilities.SetCapability(CapabilityType.HasNativeEvents, "");
                    driver = new InternetExplorerDriver("C:\\Selenium");
                    break;
            }
        }


        public static void WaitFor(int Seconds)
        {
            Thread.Sleep(Seconds * 1000);
        }

        public static class Step
        {
            public static StringBuilder Message = new StringBuilder();
            public static int StepID;
            public static string Description;

            public static void Create()
            {
                Message = new StringBuilder();
            }

            public static void Log(string Description)
            {
                //StepID++;
                Message.Append("<br>" + Description);
            }

            public static void Clear()
            {
                StepID = 0;
                if (Message != null)
                    Message.Remove(0, Message.Length);
            }
        }

        public string GetSelectedLabel(string locator, string locatedBy)
        {
            string xpath;
            xpath = "//select[@" + locatedBy + "='" + locator + "']";
            var text = driver.FindElement(By.XPath(xpath + "/option[@selected]")).Text;
            return text;

        }

        public void WaitForUpdatePanel(int seconds)
        {
            try
            {
                for (int sec = 0; sec < seconds; sec++)
                {
                    driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromMilliseconds(4000));
                    IWebElement bodyTag = driver.FindElement(By.TagName("body"));
                    if (bodyTag.Text.Contains("Loading..."))
                    {
                        wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(4000));
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(4000));
                        break;
                    }

                    break;
                }
                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(4000));
                driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromMilliseconds(8000));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void WaitForTextPresent(String text)
        {
            try
            {
                for (int sec = 0; sec < 100; sec++)
                {
                    if (IsTextPresent(text))
                        break;
                    Thread.Sleep(1000);
                }
                if (!IsTextPresent(text))
                    throw new Exception(text + "  Not Found");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ERROR: Couldn't access document.body.  Is this HTML page fully loaded?"))
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1));

                }
                else
                    throw new Exception(ex.Message);
            }

        }


        public int GetRandomNo()
        {

            Random number = new Random();
            int random = number.Next(1000, 100000000);
            return random;

        }

        public void WaitForElementPresent(string locator, string locatedBy)
        {
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0));

            switch (locatedBy)
            {
                case "ClassName":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator)));
                    break;
                case "CssSelector":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
                    break;
                case "Id":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
                    break;
                case "LinkText":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator)));
                    break;
                case "Name":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator)));
                    break;
                case "PartialLinkText":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator)));
                    break;
                case "TagName":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator)));
                    break;
                case "XPath":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                    break;
            }
        }


        public void ForceClick(string locator, string locatedBy)
        {
            switch (locatedBy)
            {
                case "ClassName":
                    IWebElement Element1 = driver.FindElement(By.ClassName(locator));
                    IJavaScriptExecutor Js1 = ((IJavaScriptExecutor)driver);
                    Js1.ExecuteScript("arguments[0].click();", Element1);
                    Thread.Sleep(2000);
                    break;
                case "CssSelector":
                    IWebElement Element2 = driver.FindElement(By.CssSelector(locator));
                    IJavaScriptExecutor Js2 = ((IJavaScriptExecutor)driver);
                    Js2.ExecuteScript("arguments[0].click();", Element2);
                    Thread.Sleep(2000);
                    break;
                case "Id":
                    IWebElement Element3 = driver.FindElement(By.Id(locator));
                    IJavaScriptExecutor Js3 = ((IJavaScriptExecutor)driver);
                    Js3.ExecuteScript("arguments[0].click();", Element3);
                    Thread.Sleep(2000);
                    break;
                case "LinkText":
                    IWebElement Element4 = driver.FindElement(By.LinkText(locator));
                    IJavaScriptExecutor Js4 = ((IJavaScriptExecutor)driver);
                    Js4.ExecuteScript("arguments[0].click();", Element4);
                    Thread.Sleep(2000);
                    break;
                case "Name":
                    IWebElement Element5 = driver.FindElement(By.Name(locator));
                    IJavaScriptExecutor Js5 = ((IJavaScriptExecutor)driver);
                    Js5.ExecuteScript("arguments[0].click();", Element5);
                    Thread.Sleep(2000);
                    break;
                case "PartialLinkText":
                    IWebElement Element6 = driver.FindElement(By.PartialLinkText(locator));
                    IJavaScriptExecutor Js6 = ((IJavaScriptExecutor)driver);
                    Js6.ExecuteScript("arguments[0].click();", Element6);
                    Thread.Sleep(2000);
                    break;
                case "TagName":
                    IWebElement Element7 = driver.FindElement(By.TagName(locator));
                    IJavaScriptExecutor Js7 = ((IJavaScriptExecutor)driver);
                    Js7.ExecuteScript("arguments[0].click();", Element7);
                    Thread.Sleep(2000);
                    break;
                case "XPath":
                    IWebElement Element8 = driver.FindElement(By.XPath(locator));
                    IJavaScriptExecutor Js8 = ((IJavaScriptExecutor)driver);
                    Js8.ExecuteScript("arguments[0].click();", Element8);
                    Thread.Sleep(2000);
                    break;
            }
        }

        public void WaitforElementNotPresent(string locator, string locatedBy)//it is not yet used,need to Re-implement it.
        {
            int notPresent = 0;
            for (int i = 0; i < 1000; i++)
            {

                if (IsElementPresent(locator, locatedBy))
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
                    //isPresent = true;

                }

                else
                {
                    notPresent = 1;
                    break;
                }
            }
            if (notPresent == 0)
            {
                throw new Exception(locator + "still present in the current context");
            }

        }

        public Boolean IsTextPresent(String text)
        {
            bool present = false;
            for (int seconds = 0; seconds <= 100; seconds++)
            {
                if (driver.PageSource.Contains(text).Equals(true))
                {
                    return true;
                    break;
                }
                else
                {
                    return false;
                }
                break;
            }
            if (present == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEditable(string xpath)
        {
            bool state = false;
            if (driver.FindElement(By.XPath(xpath)).Enabled)
            {
                state = true;
            }
            return state;
        }

        public void LocateElement(string elementToLocate, string type)
        {
            if (type == "ClassName")
            {
                driver.FindElement(By.ClassName(elementToLocate));
            }
            else if (type == "Id")
            {
                driver.FindElement(By.Id(elementToLocate));

            }
            else if (type == "Cssselector")
            {
                driver.FindElement(By.CssSelector(elementToLocate));

            }
            else if (type == "LinkText")
            {
                driver.FindElement(By.LinkText(elementToLocate));

            }
            else if (type == "Name")
            {
                driver.FindElement(By.Name(elementToLocate));

            }
            else if (type == "TagName")
            {
                driver.FindElement(By.TagName(elementToLocate));

            }
            else if (type == "XPath")
            {
                driver.FindElement(By.XPath(elementToLocate));

            }

        }


        public Boolean IsElementPresent(string locator, string locatedBy)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            Boolean isPresent = false;
            switch (locatedBy)
            {
                case "XPath":
                    try
                    {
                        if (driver.FindElements(By.XPath(locator)).Count > 0)

                            isPresent = true;
                    }
                    catch (NoSuchElementException)
                    {

                        isPresent = false;

                    }
                    break;
                case "Id":
                    if (driver.FindElements(By.Id(locator)).Count > 0)
                    {
                        isPresent = true;
                    }
                    else
                    {
                        isPresent = false;
                    }
                    break;
                case "ClassName":
                    if (driver.FindElements(By.ClassName(locator)).Count > 0)
                    {
                        isPresent = true;
                    }
                    else
                    {
                        isPresent = false;
                    }
                    break;
                case "CssSelector":
                    if (driver.FindElements(By.CssSelector(locator)).Count > 0)
                    {
                        isPresent = true;
                    }
                    else
                    {
                        isPresent = false;
                    }
                    break;
                case "LinkText":
                    if (driver.FindElements(By.LinkText(locator)).Count > 0)
                    {
                        isPresent = true;
                    }
                    else
                    {
                        isPresent = false;
                    }
                    break;
                case "Name":
                    if (driver.FindElements(By.Name(locator)).Count > 0)
                    {
                        isPresent = true;
                    }
                    else
                    {
                        isPresent = false;
                    }
                    break;

            }
            if (isPresent == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ConvertXML(string XSLTFilePath, XsltArgumentList XSLTArgs)
        {
            StringWriter sw = new System.IO.StringWriter();
            XslCompiledTransform xslTrans = new XslCompiledTransform();
            //Loads the xml from path to transform
            xslTrans.Load(XSLTFilePath);

            XmlDocument InputXMLDocument = new XmlDocument();
            InputXMLDocument.Load(XSLTFilePath + "\\TestResult.xml");

            //Transforms xml to HTML
            xslTrans.Transform(InputXMLDocument.CreateNavigator(), XSLTArgs, sw);
            return sw.ToString();
        }

        public void WaitForPageToLoad(double timeOut)
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMilliseconds(timeOut));
        }

        public void WaitForPageLoad(double timeOut)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(timeOut));
        }

        public void LogMessage(string message)
        {
            var testName = TestContext.CurrentContext.Test.Name;
            try
            {
                var dir = @"C:\Log\" + DateTime.Now.ToShortDateString() + @"\" + ConfigManager.GetConfigValue("ServerName");  // folder location

                if (!Directory.Exists(dir))  // if it doesn't exist, create
                    Directory.CreateDirectory(dir);

                // use Path.Combine to combine 2 strings to a path
                File.AppendAllText(Path.Combine(dir, "Log.txt"), testName + " _ " + message + Environment.NewLine);
            }
            catch { }
        }


        public void NunitTextOutput(string message)
        {
            var TestName = TestContext.CurrentContext.Test.Name;
            Console.WriteLine(TestName + "_ _" + message);

        }

        public string GetDescription()
        {
            return ObjectDescription;
        }

        internal void DragCardFromColumnToColumn(int p0, int p1)
        {
            var columns = driver.FindElements(By.ClassName("column"));
            var cardHeader = driver.FindElement(By.ClassName("portlet-header"));

            Actions builder = new Actions(driver);

            IAction dragAndDrop = builder.ClickAndHold(cardHeader)
               .MoveToElement(columns[0])
               .Release(columns[1])
               .Build();

            dragAndDrop.Perform();
        }

        public void DragadnDropFromPages(IWebElement SourceElement, IWebElement TargetElement)
        {

        }

        public void ClearAndSetText(IWebElement element, string text)
        {
            Actions navigator = new Actions(driver);
            navigator.Click(element)
                .SendKeys(Keys.End)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Home)
                .KeyUp(Keys.Shift)
                .SendKeys(Keys.Backspace)
                .SendKeys(text)
                .Perform();
        }

        /// <summary>
        /// Gets the tomorrow date.
        /// </summary>
        /// <value>
        /// The tomorrow date.
        /// </value>
        public static string TomorrowDate
        {
            get
            {
                return DateTime.Now.AddDays(1).ToString("MM/dd/yyyy", CultureInfo.CurrentCulture);
            }
        }

        public static string NextWeekDate
        {
            get
            {
                return DateTime.Now.AddDays(7).ToString("MM/dd/yyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current time stamp.
        /// </summary>
        /// <value>
        /// The current time stamp.
        /// </value>
        public static string CurrentTimeStamp
        {
            get
            {
                return DateTime.Now.ToString("ddMMyyyyHHmmss", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        public static string CurrentDate
        {
            get
            {
                return DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the future date.
        /// </summary>
        /// <param name="numberDaysToAddToNow">The number days to add from current date.</param>
        /// <returns>Date in future depends on parameter: numberDaysToAddToNow</returns>
        public static string GetFutureDate(int numberDaysToAddToNow)
        {
            return DateTime.Now.AddDays(numberDaysToAddToNow).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
        }

        public void TakeScreenShots(string name = "")
        {
            try
            {
                var TestName = TestContext.CurrentContext.Test.Name;
                ImageName = name + DateTime.Now.ToString("_hh_mm_") + ".jpg";
                //string path = @"D:\POS-Sourcecode\POS_WebDriver\POSWebDriver\NUnit Reports\Screenshots\";
                if (!Directory.Exists(ScreeShotsDirectory))
                {
                    Directory.CreateDirectory(ScreeShotsDirectory);
                }

                Screenshot ScreenshotDriver = ((ITakesScreenshot)driver).GetScreenshot();
                ScreenshotDriver.SaveAsFile(ScreeShotsDirectory + ImageName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void MenuNavigation(string MegaMenuName, string submenu1)
        {
            if (submenu1 != "")
            {
                Actions action = new Actions(driver);
                IWebElement Menu = driver.FindElement(By.XPath("//a[contains(text(),'Kläder')]"));
                action.MoveToElement(Menu).Perform();
                wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(submenu1)));
                driver.FindElement(By.LinkText(submenu1)).Click();
                re.LogStatusReport("pass", "Successfully navigated to " + MegaMenuName + "> " + submenu1);
            }
            else
            {
                Actions action = new Actions(driver);
                IWebElement Menu = driver.FindElement(By.LinkText(MegaMenuName));
                action.MoveToElement(Menu).Click();
                re.LogStatusReport("pass", "Successfully navigated to " + MegaMenuName);
            }            
        }

        public void RegistrationFromCheckoutPage(string Förnamn, string Efternamn, string adress, string postnummer, string stad, string telefon, string epost, string heardfrom)
        {
            //IWebElement FirstNameFiled = driver.FindElement(By.XPath("//input[@name='search']"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);


            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxFirstName")).SendKeys(Förnamn);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxLastName")).SendKeys(Efternamn);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxAddress")).SendKeys(adress);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxAddress2"));
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxZip")).SendKeys(postnummer);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxCity")).SendKeys(stad);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxDaytimePhoneNumber")).SendKeys(telefon);
            driver.FindElement(By.Id("Content_Content_RegisterControl_c_textBoxEmail")).SendKeys(epost);

            SelectElement FoundBy = new SelectElement(driver.FindElement(By.Id("Content_Content_RegisterControl_m_dropDownListCodeOfOrigin")));
            FoundBy.SelectByText(heardfrom);
            WaitFor(2);

            re.LogStatusReport("pass", "Successfully registered with the following details: "
                + "FirstName = " + Förnamn + ", "
                + "LastName = " + Efternamn + ", "
                + "Address = " + adress + ", "
                + "Zip = " + postnummer + ", "
                + "City = " + stad + ", "
                + "PhoneNumber = " + telefon + ", "
                + "Email = " + epost + ", "
                + "HeardFrom = " + heardfrom);
        }













    }
}
