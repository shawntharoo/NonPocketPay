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
    class ViewPaymentTerminalGroupTest
    {

        [Test]
        public void TC2004961_ViewPaymentTerminalGroup()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);            
            globals.expRpt.CreateTest("View Payment Terminals Groups");            
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            PaymentTerminalGroupPage paymentterminalgroup = new PaymentTerminalGroupPage(driver);


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
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search Company");
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());

                          
                editCompany.clickGo();
                
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Visit Company");
                paymentterminalgroup.clickVisittoEdit();

                
                Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "View Payment terminal Groups");
                paymentterminalgroup.clickPaymentTerminalsDropdown();
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Payment Terminal Group");
                paymentterminalgroup.clickPaymentTerminalGroups();
                

                // compare the loaded screen with the expected screen
               // Assert.AreEqual("Payment Terminal Groups", paymentterminalgroup.getpaymentTerminalText());
                
                // click the view button
                // paymentterminalgroup.clickPaymentTerminalGroups();
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "View Payment Terminals Groups");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
        }
    }
}
