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
    class DeleteSimManagement_MaintenanceTest
    {

        [Test]
        public void TC2004976_DeletesimManagement_MaintenanceTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            CommonFunctions comFunc = new CommonFunctions(driver);
            MaintenancePage maintenance = new MaintenancePage(driver);
            globals.expRpt.CreateTest("Add Payment Terminal to Company pool");

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();


                // click Maintenance
                Thread.Sleep(1000);
                maintenance.clickMaintenance();

                //click Sim Management
                Thread.Sleep(1000);
                maintenance.clickSimManagement();

                // click company dropdown
                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clck Company drop down");
                maintenance.clickadmCompanyDropdowninsim();

                // select company name
                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company");
                maintenance.setAdmCompanysim(data["setupCompany_Name2"].ToString());

                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Company details");
                maintenance.selAdminCompanysim();


                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Serial No");
                maintenance.setAdmSimNo(data["SimNumber"].ToString());

                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Sim Number");
                maintenance.clickdeleteSimNo();

                Assert.AreEqual("Successfully deleted sim 9550555550", maintenance.getSucessfullyaddedText());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Sim No has deleted from the Company Sucessfully");
                globals.expRpt.flushReport();
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        
    }
}
