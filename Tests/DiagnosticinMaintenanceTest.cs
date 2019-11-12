using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ConsoleApp.Pages;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.Tests
{
    class DiagnosticinMaintenanceTest
    {
        [Test]
        public void serilNoinUsed()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            VisitCompanyPage visitcompany = new VisitCompanyPage(driver);
            DiagnosticinMaintenancePage maintenance = new DiagnosticinMaintenancePage(driver);

            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);


                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();

                // click Maintenance
                maintenance.clickMaintenance();

                // compare the loaded screen with the expected screen
                // Assert.AreEqual("Welcome to Maintenance Administration", maintenance.getwelcomeMaintenance());

                maintenance.setSerialNumber(data["Serial_Number"].ToString());
                maintenance.clickViewDetails();

                //compare the loaded page
                Assert.AreEqual("Company Details", maintenance.getserialDescription());
            }
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void serilNoNotUsed()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            VisitCompanyPage visitcompany = new VisitCompanyPage(driver);
            DiagnosticinMaintenancePage maintenance = new DiagnosticinMaintenancePage(driver);

            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);


                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();

                // click Maintenance
                maintenance.clickMaintenance();

                // compare the loaded screen with the expected screen
                // Assert.AreEqual("Welcome to Maintenance Administration", maintenance.getwelcomeMaintenance());

                maintenance.setSerialNumber(data["Serial_NumberNotUsed"].ToString());
                maintenance.clickViewDetails();

                //compare the loaded page
                Assert.AreEqual("No payment terminal found with given serial number", maintenance.getnoPaymentTerminal());
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


    }
}
