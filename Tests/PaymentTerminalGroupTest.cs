using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ConsoleApp.Pages;
using NUnit.Framework;
using Utility.JSONRead;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.Tests
{
   class PaymentTerminalGroupTest
    {
        [Test]
        public void createPaymentTerminalGroup()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            EditCompanyPage companyInfor = new EditCompanyPage(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            EditCompanyPage searchCompany = new EditCompanyPage(driver);
            EditCompanyPage companyTable = new EditCompanyPage(driver);
            EditCompanyPage companyColumn = new EditCompanyPage(driver);
            VisitCompanyPage visitcompany = new VisitCompanyPage(driver);
            PaymentTerminalGroupPage visitcompanyName = new PaymentTerminalGroupPage(driver);
            PaymentTerminalGroupPage paymentTerminalGroup = new PaymentTerminalGroupPage(driver);


            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);


                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();



                // compare the loaded screen with the expected screen
                Assert.AreEqual("Company List", home.getText());

                // search for the company         
                //searchCompany.enterCompanyName(JSRead.jsonReader("../ConsoleApp/Data_Source/data.json", "searchCompany_Name"));
                //editCompany.clickGo();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //visit comapny details
                visitcompany.clickVisit();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                // compare the loaded screen with the expected screen
                Assert.AreEqual("Sams QA", visitcompanyName.getcompanyName());

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                paymentTerminalGroup.clickPaymentTerminalGroup();
                //paymentTerminalGroup.se
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                // click new Payment Terminal Groups button
                paymentTerminalGroup.clicknewpaymentterminalGroupButton();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                // enter payment terminal groups details
                paymentTerminalGroup.setpostalStoreName(data["StoreName"].ToString());
                paymentTerminalGroup.setpostalLine1(data["PostalLine1"].ToString());
                paymentTerminalGroup.setpostalSuburb(data["PostalSuburb"].ToString());
                paymentTerminalGroup.setpostalZipCode(data["PostalZipCode"].ToString());
                paymentTerminalGroup.setpostalCountry(data["PostalCountry"].ToString());
            }
            driver.Close();
            driver.Quit();
        }


        // View Payment Terminal Group details

        [Test]
        public void viewPaymentTerminalGroup()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            EditCompanyPage companyInfor = new EditCompanyPage(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            EditCompanyPage searchCompany = new EditCompanyPage(driver);
            EditCompanyPage companyTable = new EditCompanyPage(driver);
            EditCompanyPage companyColumn = new EditCompanyPage(driver);
            VisitCompanyPage visitcompany = new VisitCompanyPage(driver);
            PaymentTerminalGroupPage visitcompanyName = new PaymentTerminalGroupPage(driver);
            PaymentTerminalGroupPage paymentTerminalGroup = new PaymentTerminalGroupPage(driver);


            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);


                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();


                // compare the loaded screen with the expected screen
                Assert.AreEqual("Company List", home.getText());

                // search for the company         
                //searchCompany.enterCompanyName(JSRead.jsonReader("../ConsoleApp/Data_Source/data.json", "searchCompany_Name"));
                //editCompany.clickGo();

                //visit comapny details
                visitcompany.clickVisit();

                // compare the loaded screen with the expected screen
                Assert.AreEqual("Sams QA", visitcompanyName.getcompanyName());

                paymentTerminalGroup.clickPaymentTerminalGroup();

                // compare the loaded screen with the expected screen
                Assert.AreEqual("Payment Terminal Groups", paymentTerminalGroup.getpaymentterminalText());

                // click the view button

            }

            driver.Close();
            driver.Quit();
        }
    }
}
