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

namespace Non_Pocket_Pay.Tests
{
    class ReportsTest
    {
        [Test]
        public void TC2004870_PINpadHealthStatusReport()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();

            globals.expRpt.CreateTest("View PINpad Health Status Report");


            CommonFunctions comFunc = new CommonFunctions(driver);
            ReportsPage reports = new ReportsPage(driver);
         
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
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Pinpad File details");
                reports.enterCompanyName(data["setupCompany_Name2"].ToString());
                reports.clickGo();

                reports.clickVisittoEdit();

                //Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Reporting");
                reports.clickReport();

                Thread.Sleep(500);
                reports.clickPINPadReport();
                
                


            }

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}

