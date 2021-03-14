using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace calculatorTest
{
    public class LoginPageTest
    {

        const string BASEURL = "http://localhost:64177/";
        IWebDriver browser;

        [SetUp]
        public void Setup()
        {
            browser = new ChromeDriver();
            browser.Url = (BASEURL + "Login");

            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]

        public void Test_User_Login_And_Password_Invalid_Values()
        {
            
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "1234";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("@#$%");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("'" + name + "' user doesn't exist!", error.Text);
            

        }
        [Test]
        public void Test_User_Login_And_Password_Valide_Values()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "test";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("newyork1");
            browser.FindElement(By.Id("loginBtn")).Click();
            Assert.AreEqual(BASEURL + "Deposit", browser.Url);
        }
        [Test]
        public void Test_User_Login_And_Password_Both_Blanck()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = " ";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys(" ");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("User name and password cannot be empty!", error.Text);
        }
        [Test]
        public void Test_User_Login_And_Password_Admin_Admin()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "Admin";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("Admin");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("'" + name + "' user doesn't exist!", error.Text);
        }
        [Test]
        public void Test_User_Login_And_Password_Space_In_User_And_Password_Correct()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "_test";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("newyork1");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("Incorrect user name!", error.Text);
        }
        [Test]
        public void Test_User_Login_And_Password_Add_t_After_User_Password_Correct()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "testt";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("newyork1");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("Incorrect user name!", error.Text);
        }
        [Test]
        public void Test_User_Login_And_Password_User_Uppercase_And_Password_Correct()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "TEST";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("newyork1");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("Incorrect user name!", error.Text);
        }
        [Test]
        public void Test_User_Login_And_Password_Valid_User_And_Upper_Password()
        {
            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "test";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("NEWYOURK1");
            browser.FindElement(By.Id("loginBtn")).Click();
            IWebElement error = browser.FindElement(By.Id("errorMessage"));
            Assert.AreEqual("Incorrect password!", error.Text);
            
        }
        [Test]
        public void Test_User_Login_And_Password_Remained_Password_Availability()
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(10))
.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("remindBtn")));

            IWebElement Remind = browser.FindElement(By.Id("remindBtn"));
            Assert.IsTrue(Remind.Displayed);
        }

    [TearDown]
        public void AfterEachTest()
        {
            browser.Quit();
        }
    }
}
