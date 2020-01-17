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
    class EditPaymentTerminalsTest
    {
        [Test]
        public void TC2004962_EditPaymentTerminals()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);            
            globals.expRpt.CreateTest("Create Payment Terminals Groups");            
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            PaymentTerminalGroupPage paymentterminalgroup = new PaymentTerminalGroupPage(driver);
            PaymentTerminalsPage paymentTerminals = new PaymentTerminalsPage(driver);

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

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Enter Company Details");
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Go button");
                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Visit button");
                paymentterminalgroup.clickVisittoEdit();
                
                // Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Load Payment Terminal Drop Down");
                paymentterminalgroup.clickPaymentTerminalsDropdown();
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click All Payment Terminals");
                paymentTerminals.clickallPaymentTerminals();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Edit Payment Terminal button");
                paymentTerminals.enterPTs(data["EditPaymentTerminal"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Search Payment Terminals");
                paymentTerminals.searchPT();
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Edit Payment Terminal button");
                paymentTerminals.clickeditPT();

                Assert.AreEqual("Edit Payment Terminal", paymentTerminals.geteditPTText());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Edit POSId");
                paymentTerminals.enterPosId(data["POSId"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Clcik Save button");
                paymentTerminals.ClickeditPTsave();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Create Payment Terminals Groups");
                globals.expRpt.flushReport();

                

                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
