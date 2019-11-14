using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using Non_Pocket_Pay.Common;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Non_Pocket_Pay.Tests
{
    class DiagnosticinMaintenanceTest
    {
        [Test]
        public void serilNoinUsed()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            DiagnosticinMaintenancePage maintenance = new DiagnosticinMaintenancePage(driver);

            globals.expRpt.createTest("The Seril No in Used Test");
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Seril No in Used");
            globals.expRpt.flushReport();

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
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
            CommonFunctions comFunc = new CommonFunctions(driver);
            DiagnosticinMaintenancePage maintenance = new DiagnosticinMaintenancePage(driver);

            globals.expRpt.createTest("The Seril No is not in Used");
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Seril No is not in Used");
            globals.expRpt.flushReport();

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
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
                Assert.AreEqual("Description", maintenance.getnoPaymentTerminal());
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


    }
}
