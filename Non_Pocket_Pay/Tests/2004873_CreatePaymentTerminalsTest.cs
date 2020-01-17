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
    class CreatePaymentTerminalsTest
    {

        [Test]
        public void TC2004873_CreatePaymentTerminals()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Create Payment Terminals");
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            PaymentTerminalGroupPage paymentterminalgroup = new PaymentTerminalGroupPage(driver);
            PaymentTerminalsPage paymentTerminals = new PaymentTerminalsPage(driver);
            MaintenancePage maintenance = new MaintenancePage(driver);
            AddCompanyPage addCompany = new AddCompanyPage(driver);


            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                // click Maintenance--
                Thread.Sleep(500);
                maintenance.clickMaintenance();

                // click Maintenance
                Thread.Sleep(500);
                maintenance.clickMaintenance();

                //click Administration---

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
                maintenance.setAdmSerialNo(data["AddSerialNotoPT"].ToString());
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Payment Terminal");
                maintenance.clickaddPT();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Payment Terminal");
                addCompany.clickcompanyTab();

                // compare the loaded screen with the expected screen
                Assert.AreEqual("Company List", home.getText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // search for the company.. update to "Company_Name" later  
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company Name");
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());
                
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Go button");
                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Visit Company");
                paymentterminalgroup.clickVisittoEdit();
                Thread.Sleep(500);

                Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Payment Terminal Dropdown");
                paymentterminalgroup.clickPaymentTerminalsDropdown();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Payment Terminal Group");
                paymentterminalgroup.clickPaymentTerminalGroups();

                // compare the loaded screen with the expected screen
                                         
                Assert.AreEqual("Payment Terminal Groups", paymentTerminals.getPaymentTerminalGroupText());

                Thread.Sleep(500);
                paymentTerminals.searchPTgroup(data["AddStores"].ToString());

                paymentTerminals.clickPTGo();

                //view Payment Terminal details
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click view Payment Terminal Group");
                paymentTerminals.clickviewPaymentTerminal();

                // compare the loaded screen with the expected screen
                //Assert.AreEqual("Collins Street Store", createPaymentTerminals.getpaymentTerminalsText());
                //Thread.Sleep(1000);


                // create payment terminals
                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click add Payment Terminals button");
                paymentTerminals.clickaddPaymentTerminalbutton();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Serial No");
                paymentTerminals.clickselSerialnoDropdown();

                // select serial no   
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Serial No");
                paymentTerminals.setentSerialNo(data["AddSerialNotoPT"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Serial No");
                paymentTerminals.selectSerialNo();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Serial No");
                paymentTerminals.clickAddSerialno();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clcik Request Log Upload");
                paymentTerminals.clickReqLogUpload();

              
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Request Log Upload");
                paymentTerminals.setentReqLog(data["ReqLogUpload"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Select Request Log Upload");
                paymentTerminals.selectselReqLog();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Merchant Id");
                paymentTerminals.setmechantId(data["MerchantId"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Terminal Id");
                paymentTerminals.setterminalId(data["TerminalId"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Save Payment Terminal");
                paymentTerminals.ClickeditPTsave();

                
                Assert.AreEqual("Payment Terminals", paymentTerminals.getpaymentTerminalsText());

                if (paymentTerminals.getpaymentTerminalsText().Equals("Payment Terminals"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The user should be in the Payment Group details");
                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The user should be in the wrong page");
                }

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Create Payment Terminals");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();

        }
            
    }
}
