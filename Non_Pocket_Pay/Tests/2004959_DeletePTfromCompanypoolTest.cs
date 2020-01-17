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
    class DeletePaymentTerminaltoCompanypoolTest
    {

        
        [Test]
        public void TC2004959_DeletePaymentTerminaltoCompanypool()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            CommonFunctions comFunc = new CommonFunctions(driver);
            MaintenancePage maintenance = new MaintenancePage(driver);
            globals.expRpt.CreateTest("Delete Payment Terminal to Company pool");

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();
               
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
                //driver.Navigate().GoToUrl(data["URL"].ToString());
                //driver.Manage().Window.Maximize();

                //loginP.setUserName(data["User_Name"].ToString());

                //loginP.setPassword(data["password"].ToString());

                //loginP.clickLogin();

                // click Maintenance
                Thread.Sleep(1000);
                maintenance.clickMaintenance();
                //click Administration---

                Thread.Sleep(1000);
                maintenance.clickAdministration();
                // click company dropdown

                Thread.Sleep(1000);
                maintenance.clickadmCompanyDropdown();
                // select company name

                Thread.Sleep(1000);
                maintenance.setAdmCompany(data["setupCompany_Name2"].ToString());
                maintenance.selAdminCompany();


                maintenance.clickdeviceType();

                maintenance.setAdmSerialNo(data["AdminSerialNo"].ToString());

                maintenance.clickdeletePT();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Add Payment Terminal to Company pool");
                globals.expRpt.flushReport();
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

    }


}
