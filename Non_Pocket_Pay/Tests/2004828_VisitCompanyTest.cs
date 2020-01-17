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
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class VisitCompanyTest
    {

        // View Payment Terminal Group details

        [Test]
        public void TC2004828_VisitCompany()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();            
            HomePage home = new HomePage(driver);            
            globals.expRpt.CreateTest("Create Payment Terminals Groups");
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            
            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                // compare the loaded screen with the expected screen
                Assert.AreEqual("Company List", home.getText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // search for the company.. update to "Company_Name" later 
                Thread.Sleep(500);
                editCompany.enterCompanyName(data["setupCompany_Name2"].ToString());

                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clcik Visit button");
                editCompany.clickVisittoEdit();
                Thread.Sleep(500);

                Assert.AreEqual("QUESTAutoComp01", editCompany.getcompanyDetailstoview());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The user visit the company Sucessfully");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
