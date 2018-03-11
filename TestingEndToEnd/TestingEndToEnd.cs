using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;

namespace TestingEndToEnd
{
    [TestFixture]
    public class CMS
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://sallinet.azurewebsites.net/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void CreateTestSuite()
        {
            //  LOGIN
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/");
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("LetMeIn");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("super-admin@sallinet.ie");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();

            //  CREATE EVENT CATEGORY
            driver.FindElement(By.LinkText("EventCategories")).Click();
            driver.FindElement(By.LinkText("New Event Category")).Click();
            driver.FindElement(By.Id("EventCategory_Name")).Click();
            driver.FindElement(By.Id("EventCategory_Name")).Clear();
            driver.FindElement(By.Id("EventCategory_Name")).SendKeys("TEST CATEGORY");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //  CREATE ORGANISER
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/Organisers");
            driver.FindElement(By.LinkText("Organsiers")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("Organiser_DisplayName")).Click();
            driver.FindElement(By.Id("Organiser_DisplayName")).Clear();
            driver.FindElement(By.Id("Organiser_DisplayName")).SendKeys("TEST ORGANISER NAME");
            driver.FindElement(By.Id("Organiser_ContactDetails")).Clear();
            driver.FindElement(By.Id("Organiser_ContactDetails")).SendKeys("TEST 12345678");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //  CREATE LOCATION
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/EventCategories");
            driver.FindElement(By.LinkText("Locations")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("Location_Name")).Click();
            driver.FindElement(By.Id("Location_Name")).Clear();
            driver.FindElement(By.Id("Location_Name")).SendKeys("TEST LOCATION");
            driver.FindElement(By.Id("Location_Town")).Clear();
            driver.FindElement(By.Id("Location_Town")).SendKeys("TEST TOWN");
            driver.FindElement(By.Id("Location_County")).Clear();
            driver.FindElement(By.Id("Location_County")).SendKeys("TEST COUNTY");
            driver.FindElement(By.Id("Location_Lat")).Clear();
            driver.FindElement(By.Id("Location_Lat")).SendKeys("1234567");
            driver.FindElement(By.Id("Location_Lng")).Clear();
            driver.FindElement(By.Id("Location_Lng")).SendKeys("1234567");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //  CREATE DEVICE
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/Devices");
            driver.FindElement(By.LinkText("New Device")).Click();
            driver.FindElement(By.Id("Device_Name")).Clear();
            driver.FindElement(By.Id("Device_Name")).SendKeys("TEST DEVICE");
            driver.FindElement(By.Id("Device_LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("Device_LocationId"))).SelectByText("TEST LOCATION");
            driver.FindElement(By.Id("Device_LocationId")).Click();
            driver.FindElement(By.Id("Device_Build")).Click();
            driver.FindElement(By.Id("Device_Build")).Clear();
            driver.FindElement(By.Id("Device_Build")).SendKeys("1");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Test]
        public void CreateTestEvent1()
        {
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/");
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("LetMeIn");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("super-admin@sallinet.ie");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.LinkText("Events")).Click();
            driver.FindElement(By.LinkText("New Event")).Click();
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("TEST EVENT NAME 1");
            driver.FindElement(By.Id("Details")).Click();
            driver.FindElement(By.Id("Details")).Clear();
            driver.FindElement(By.Id("Details")).SendKeys("TEST EVENT DETAILS 1");
            driver.FindElement(By.Id("Priority")).Click();
            driver.FindElement(By.Id("Priority")).Clear();
            driver.FindElement(By.Id("Priority")).SendKeys("1");
            driver.FindElement(By.Id("StartTime")).Clear();
            driver.FindElement(By.Id("StartTime")).SendKeys("01/04/2018 13:00");
            driver.FindElement(By.Id("EndTime")).Clear();
            driver.FindElement(By.Id("EndTime")).SendKeys("01/04/2018 15:00");
            driver.FindElement(By.Id("LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("LocationId"))).SelectByText("TEST LOCATION");
            driver.FindElement(By.Id("LocationId")).Click();
            driver.FindElement(By.Id("OrganiserId")).Click();
            new SelectElement(driver.FindElement(By.Id("OrganiserId"))).SelectByText("TEST ORGANISER NAME");
            driver.FindElement(By.Id("OrganiserId")).Click();
            driver.FindElement(By.Id("EventCategoryId")).Click();
            new SelectElement(driver.FindElement(By.Id("EventCategoryId"))).SelectByText("TEST CATEGORY");
            driver.FindElement(By.Id("EventCategoryId")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }


        [Test]
        public void CreateTestEvent2()
        {
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/");
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("LetMeIn");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("super-admin@sallinet.ie");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.LinkText("Events")).Click();
            driver.FindElement(By.LinkText("New Event")).Click();
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("EST EVENT NAME 2");
            driver.FindElement(By.Id("Details")).Click();
            driver.FindElement(By.Id("Details")).Clear();
            driver.FindElement(By.Id("Details")).SendKeys("EST EVENT DETAILS 2");
            driver.FindElement(By.Id("Priority")).Click();
            driver.FindElement(By.Id("Priority")).Clear();
            driver.FindElement(By.Id("Priority")).SendKeys("1");
            driver.FindElement(By.Id("StartTime")).Clear();
            driver.FindElement(By.Id("StartTime")).SendKeys("01/04/2018 13:00");
            driver.FindElement(By.Id("EndTime")).Clear();
            driver.FindElement(By.Id("EndTime")).SendKeys("01/04/2018 15:00");
            driver.FindElement(By.Id("LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("LocationId"))).SelectByText("TEST LOCATION");
            driver.FindElement(By.Id("LocationId")).Click();
            driver.FindElement(By.Id("OrganiserId")).Click();
            new SelectElement(driver.FindElement(By.Id("OrganiserId"))).SelectByText("TEST ORGANISER NAME");
            driver.FindElement(By.Id("OrganiserId")).Click();
            driver.FindElement(By.Id("EventCategoryId")).Click();
            new SelectElement(driver.FindElement(By.Id("EventCategoryId"))).SelectByText("TEST CATEGORY");
            driver.FindElement(By.Id("EventCategoryId")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Test]
        public void CreateTestEvent3()
        {
            driver.Navigate().GoToUrl("https://sallinet.azurewebsites.net/");
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("LetMeIn");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("super-admin@sallinet.ie");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.LinkText("Events")).Click();
            driver.FindElement(By.LinkText("New Event")).Click();
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("EST EVENT NAME 3");
            driver.FindElement(By.Id("Details")).Click();
            driver.FindElement(By.Id("Details")).Clear();
            driver.FindElement(By.Id("Details")).SendKeys("EST EVENT DETAILS 3");
            driver.FindElement(By.Id("Priority")).Click();
            driver.FindElement(By.Id("Priority")).Clear();
            driver.FindElement(By.Id("Priority")).SendKeys("1");
            driver.FindElement(By.Id("StartTime")).Clear();
            driver.FindElement(By.Id("StartTime")).SendKeys("01/04/2018 13:00");
            driver.FindElement(By.Id("EndTime")).Clear();
            driver.FindElement(By.Id("EndTime")).SendKeys("01/04/2018 15:00");
            driver.FindElement(By.Id("LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("LocationId"))).SelectByText("TEST LOCATION");
            driver.FindElement(By.Id("LocationId")).Click();
            driver.FindElement(By.Id("OrganiserId")).Click();
            new SelectElement(driver.FindElement(By.Id("OrganiserId"))).SelectByText("TEST ORGANISER NAME");
            driver.FindElement(By.Id("OrganiserId")).Click();
            driver.FindElement(By.Id("EventCategoryId")).Click();
            new SelectElement(driver.FindElement(By.Id("EventCategoryId"))).SelectByText("TEST CATEGORY");
            driver.FindElement(By.Id("EventCategoryId")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
