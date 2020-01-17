// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using DataDriven.Utilities;


namespace Non_Pocket_Pay.Tests
{
    class SerilNoNotUsedTest
    {
        
        [Test]
        public void TC2004870_SerilNoNotUsed()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            MaintenancePage maintenance = new MaintenancePage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            globals.expRpt.CreateTest("The Seril No is not in Used");


            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                // click Maintenance
                maintenance.clickMaintenance();

                // compare the loaded screen with the expected screen
                // Assert.AreEqual("Welcome to Maintenance Administration", maintenance.getwelcomeMaintenance());
                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Serial Number");
                maintenance.setSerialNumber(data["Serial_NumberNotUsed"].ToString());

                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clcik View Details");
                maintenance.clickViewDetails();

                //compare the loaded page
                Assert.AreEqual("Description", maintenance.getnoPaymentTerminal());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Seril No is not in Used");
                globals.expRpt.flushReport();
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


    }
}
