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
    class AddSimManagement_MaintenanceTest
    {

        [Test]
        public void TC2004975_AddsimManagement_MaintenanceTest()
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
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Load Maintenance tab");
                maintenance.clickMaintenance();

                //click Sim Management

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Load Sim Management");
                maintenance.clickSimManagement();

                // click company dropdown

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clck Company drop down");
                maintenance.clickadmCompanyDropdowninsim();

                // select company name

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company");
                maintenance.setAdmCompanysim(data["setupCompany_Name2"].ToString());


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Company details");
                maintenance.selAdminCompanysim();

                //Thread.Sleep(1000);
                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Device type");
                //addsimManagement.clickdeviceType();
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Sim No");
                maintenance.setAdmSimNo(data["SimNumber"].ToString());
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Sim Number button");
                maintenance.clickaddSimNo();

                Assert.AreEqual("Successfully added sim number 9550555550 with company QUESTAutoComp01", maintenance.getSucessfullyaddedText());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Sim Number has added to Company Sucessfully");
                globals.expRpt.flushReport();
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


      
    }
}
