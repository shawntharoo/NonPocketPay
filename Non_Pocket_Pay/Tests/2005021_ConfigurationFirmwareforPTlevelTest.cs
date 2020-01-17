// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 02/12/2019
// Updated Date - 
// Version - 0.0.01

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class ConfigurationFirmwareforPTlevelTest
    {

        [Test]
        public void TC2005021_ConfigurationFirmwareforPTlevel()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Configure Surcharge in Payment Terminal Level");
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            PaymentTerminalGroupPage paymentterminalgroup = new PaymentTerminalGroupPage(driver);
            PaymentTerminalsPage paymentTerminals = new PaymentTerminalsPage(driver);
            ConfigurePaymentTerminalPage configPT = new ConfigurePaymentTerminalPage(driver);

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
                
                editCompany.enterCompanyName(data["setupCompany_Name2"].ToString());

                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Visit button");
                editCompany.clickVisittoEdit();

                //Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Payment Terminal Dropdown");
                paymentterminalgroup.clickPaymentTerminalsDropdown();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click All Payment Terminals");
                paymentTerminals.clickallPaymentTerminals();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "User should be in Payment Terminals");
                Assert.AreEqual("Payment Terminals", configPT.getpaymentterminalsText());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "search Payment Terminal Group");
                paymentTerminals.searchPTgroup(data["EditPaymentTerminal"].ToString());
                paymentTerminals.clickPTGo();

                //view Payment Terminal details
                

                //Assert.AreEqual("QUESTAutoComp01", editCompany.getcompanyDetailstoview());
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Configure Payment Terminals");
                configPT.clickpeymentTerminalConfig();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Firmware Configuration");
                configPT.clickFiremwarebutton();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "User should be in Firmware page");
                Assert.AreEqual("Choose a firmware file", configPT.getfirmwareText());

                configPT.clearFirmware();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Firmware dropdown");
                configPT.Clickfirmwaredropdown();

                
                configPT.enterFirmware(data["firmware"].ToString());

                
                configPT.Clickfirmwarevalue();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Save Firmware details");
                configPT.clickSaveFirmware();


                Assert.AreEqual("Configure payment terminal options", configPT.getconfigurePToptionsText());

                if (configPT.getconfigurePToptionsText().Equals("Configure payment terminal options"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "User should be in Configure payment terminal options");
                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "User should is not in the correct page");
                }
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Surcharge details in PT level  saved Sucessfully");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();


        }

    }
}
