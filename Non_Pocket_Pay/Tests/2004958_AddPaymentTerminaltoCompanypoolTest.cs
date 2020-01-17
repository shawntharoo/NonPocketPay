// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class AddPaymentTerminaltoCompanypoolTest
    {

        [Test]
        public void TC2004958_AddPaymentTerminaltoCompanypool()
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

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // click Maintenance
                Thread.Sleep(500);
                maintenance.clickMaintenance();

                //click Administration----------

                maintenance.clickAdministration();

                // click company dropdown

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clck Company drop down");
                maintenance.clickadmCompanyDropdown();

                // select company name
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company");
                maintenance.setAdmCompany(data["setupCompany_Name2"].ToString());


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Company details");
                maintenance.selAdminCompany();


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Device type");
                maintenance.clickdeviceType();


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Serial No");
                maintenance.setAdmSerialNo(data["AdminSerialNo"].ToString());


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clcik Add Payment Terminal");
                maintenance.clickaddPT();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Add Payment Terminala to Company pool Sucessfully");
                globals.expRpt.flushReport();
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        

    }


}
