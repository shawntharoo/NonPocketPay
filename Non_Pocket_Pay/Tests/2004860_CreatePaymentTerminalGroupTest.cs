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
    class CreatePaymentTerminalGroupTest
    {
        
        // View Payment Terminal Group details

        [Test]
        public void TC2004860_CreatePaymentTerminalGroup()
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
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Enter Comapny Details");
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Go button");
                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Visit Comapny Details");
                paymentterminalgroup.clickVisittoEdit();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Compare the loaded Page");
                Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

               
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Payment Terminal Groups");
                paymentterminalgroup.clickPaymentTerminalsDropdown();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Load Payment Terminal Groups");
                paymentterminalgroup.clickPaymentTerminalGroups();

                // compare the loaded screen with the expected screen
                                          
                Assert.AreEqual("Payment Terminal Groups", paymentterminalgroup.getPaymentTerminalGroupText());

                // click the add Payment terminal Group button
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Add Payment Terminal Groups");
                paymentterminalgroup.clickaddPyamentTerminalGroup();

                Assert.AreEqual("Create Payment Terminal Group", paymentterminalgroup.getcreatePTGtext());

                // enter payment Terminal Group details     
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Enter Comapny Details");

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Store Name");
                paymentterminalgroup.setPaymentTerminalName(data["StoreName"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Address");
                paymentterminalgroup.setdeliveryLine(data["pt_deliveryLine"].ToString());
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Suburb");
                paymentterminalgroup.setSuburb(data["pt_postalSuburb"].ToString());
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal State");
                paymentterminalgroup.setState(data["pt_state"].ToString());
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Code");
                paymentterminalgroup.setpostalCode(data["pt_postalCode"].ToString());
                
              
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Country");
                paymentterminalgroup.setCountry(data["pt_country"].ToString());
                
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Delivery Address");
                paymentterminalgroup.setdeliveryAddresscheckbox();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Save Payment Terminal Group details");
                paymentterminalgroup.clickSavePaymentterminals();


                Assert.AreEqual("Payment Terminals", paymentTerminals.getpaymentTerminalsText());

                if (paymentTerminals.getpaymentTerminalsText().Equals("Payment Terminals"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The user should be in the Payment Group details");
                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The user should be in the wrong page");
                }

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Payment Terminals Group created Sucessfully");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
