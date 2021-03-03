using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace calculatorTest
{
    class PageAfterLoginTest
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


            IWebElement loginfield = browser.FindElement(By.Id("login"));
            string name = "test";
            loginfield.SendKeys(name);
            IWebElement passwordfield = browser.FindElement(By.Id("password"));
            passwordfield.SendKeys("newyork1");
            browser.FindElement(By.Id("loginBtn")).Click();
        }

        [Test]

        public void Calculation_testing_365_days()
        {
            browser.FindElement(By.Id("amount")).SendKeys("100");
            browser.FindElement(By.Id("percent")).SendKeys("10");
            browser.FindElement(By.Id("term")).SendKeys("365");
            browser.FindElement(By.Id("d365")).Click();

            string income = browser.FindElement (By.Id("income")).GetAttribute("value");
            Assert.AreEqual("110.00", income);
            string earned = browser.FindElement(By.Id("interest")).GetAttribute("value");
            Assert.AreEqual("10.00", earned);

        }

        [Test]

        public void Valide_End_Date_In_Case_Wnen_365()
        {
          
            browser.FindElement(By.Id("term")).SendKeys("365");

            SelectElement day = new SelectElement( browser.FindElement(By.Id("day")));
            SelectElement month = new SelectElement(browser.FindElement(By.Id("month")));
            SelectElement year = new SelectElement(browser.FindElement(By.Id("year")));
            day.SelectByText("1");
            month.SelectByText("January");
            year.SelectByText("2010");

            browser.FindElement(By.Id("d365")).Click();

            string enddate = browser.FindElement(By.Id("endDate")).GetAttribute("value");
            Assert.AreEqual("31/12/2010", enddate);
       
        }
        [TearDown]
        public void AfterEachTest()
        {
            browser.Quit();
        }
    }
}
