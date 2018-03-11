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
            baseURL = "https://www.katalon.com/";
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


        //        Create Test Event
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
            driver.FindElement(By.Id("Name")).SendKeys("TEST1");
            driver.FindElement(By.Id("Details")).Click();
            driver.FindElement(By.Id("Details")).Clear();
            driver.FindElement(By.Id("Details")).SendKeys("TEST1");
            driver.FindElement(By.Id("Priority")).Click();
            driver.FindElement(By.Id("Priority")).Clear();
            driver.FindElement(By.Id("Priority")).SendKeys("1");
            driver.FindElement(By.Id("StartTime")).Clear();
            driver.FindElement(By.Id("StartTime")).SendKeys("01/04/2018 13:00");
            driver.FindElement(By.Id("EndTime")).Clear();
            driver.FindElement(By.Id("EndTime")).SendKeys("01/04/2018 15:00");
            driver.FindElement(By.Id("LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("LocationId"))).SelectByText("IT Sligo");
            driver.FindElement(By.Id("LocationId")).Click();
            driver.FindElement(By.Id("OrganiserId")).Click();
            new SelectElement(driver.FindElement(By.Id("OrganiserId"))).SelectByText("Mr Organiser");
            driver.FindElement(By.Id("OrganiserId")).Click();
            driver.FindElement(By.Id("EventCategoryId")).Click();
            new SelectElement(driver.FindElement(By.Id("EventCategoryId"))).SelectByText("TEST");
            driver.FindElement(By.Id("EventCategoryId")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            //
            //
            //            driver.FindElement(By.XPath("//table[@id='events']/tbody/tr[5]/td[7]/button")).Click();
            //            driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            //            driver.FindElement(By.LinkText("Log off")).Click();
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
            driver.FindElement(By.Id("Name")).SendKeys("TEST2");
            driver.FindElement(By.Id("Details")).Click();
            driver.FindElement(By.Id("Details")).Clear();
            driver.FindElement(By.Id("Details")).SendKeys("TEST2");
            driver.FindElement(By.Id("Priority")).Click();
            driver.FindElement(By.Id("Priority")).Clear();
            driver.FindElement(By.Id("Priority")).SendKeys("1");
            driver.FindElement(By.Id("StartTime")).Clear();
            driver.FindElement(By.Id("StartTime")).SendKeys("01/04/2018 13:00");
            driver.FindElement(By.Id("EndTime")).Clear();
            driver.FindElement(By.Id("EndTime")).SendKeys("01/04/2018 15:00");
            driver.FindElement(By.Id("LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("LocationId"))).SelectByText("IT Sligo");
            driver.FindElement(By.Id("LocationId")).Click();
            driver.FindElement(By.Id("OrganiserId")).Click();
            new SelectElement(driver.FindElement(By.Id("OrganiserId"))).SelectByText("Mr Organiser");
            driver.FindElement(By.Id("OrganiserId")).Click();
            driver.FindElement(By.Id("EventCategoryId")).Click();
            new SelectElement(driver.FindElement(By.Id("EventCategoryId"))).SelectByText("TEST");
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
            driver.FindElement(By.Id("Name")).SendKeys("TEST3");
            driver.FindElement(By.Id("Details")).Click();
            driver.FindElement(By.Id("Details")).Clear();
            driver.FindElement(By.Id("Details")).SendKeys("TEST3");
            driver.FindElement(By.Id("Priority")).Click();
            driver.FindElement(By.Id("Priority")).Clear();
            driver.FindElement(By.Id("Priority")).SendKeys("1");
            driver.FindElement(By.Id("StartTime")).Clear();
            driver.FindElement(By.Id("StartTime")).SendKeys("01/04/2018 13:00");
            driver.FindElement(By.Id("EndTime")).Clear();
            driver.FindElement(By.Id("EndTime")).SendKeys("01/04/2018 15:00");
            driver.FindElement(By.Id("LocationId")).Click();
            new SelectElement(driver.FindElement(By.Id("LocationId"))).SelectByText("IT Sligo");
            driver.FindElement(By.Id("LocationId")).Click();
            driver.FindElement(By.Id("OrganiserId")).Click();
            new SelectElement(driver.FindElement(By.Id("OrganiserId"))).SelectByText("Mr Organiser");
            driver.FindElement(By.Id("OrganiserId")).Click();
            driver.FindElement(By.Id("EventCategoryId")).Click();
            new SelectElement(driver.FindElement(By.Id("EventCategoryId"))).SelectByText("TEST");
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
