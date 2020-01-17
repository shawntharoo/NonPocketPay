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
    class BlockPaymentTerminalsTest
    {
        [Test]
        public void TC2004960_BlockPaymentTerminals()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);         
            globals.expRpt.CreateTest("Block Payment Terminals");
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
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Pinpad File details");
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());
                editCompany.clickGo();

                paymentterminalgroup.clickVisittoEdit();
                
               // Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());
                
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Payment Terminal option");
                paymentterminalgroup.clickPaymentTerminalsDropdown();


                paymentTerminals.clickallPaymentTerminals();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search Payment Terminal");
                paymentTerminals.enterPTs(data["BlockPaymentTerminal"].ToString());


                paymentTerminals.searchPT();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Block Payment Terminal");
                paymentTerminals.blockPTs();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Additional Information");
                paymentTerminals.enterAdditionalInformation(data["AdditionalInformation"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Confirm block Payament Terminal");
                paymentTerminals.blockConfirmationPT();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Re-Confirm block Payament Terminal");
                paymentTerminals.clickyesBlockbutton();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Blocked Payment Terminal");
                paymentTerminals.enterPTs(data["BlockPaymentTerminal"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search Blocked Payment Terminal");
                paymentTerminals.searchPT();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Compare the loaded screen");
                Assert.AreEqual("Blocked", paymentTerminals.getBlockText());

                if (paymentTerminals.getBlockText().Equals("Blocked"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The user should be in the All Payment terminals page");
                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The user should be in the wrong page");
                }

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Payment Terminals blocked sucessfully");
                globals.expRpt.flushReport();

            }

                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
        }
    }

