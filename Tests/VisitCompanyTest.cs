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
    class VisitCompanyTest
    {
        [Test]
        public void vistCompany()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            VisitCompanyPage visitcompany = new VisitCompanyPage(driver);
            EditCompanyPage searchCompany = new EditCompanyPage(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);

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
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                // search for the company         
                searchCompany.enterCompanyName(data["searchtoEditCompany_Name"].ToString());
                editCompany.clickGo();

                visitcompany.clickVisit();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                Assert.AreEqual("QUESTComp0", visitcompany.getcompanyDetails());

            }

            driver.Close();
            driver.Quit();
        }
    }
}