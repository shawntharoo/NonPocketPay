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
    class ConfigurationFirmwareforPTGlevelTest
    {
        

        [Test]
        public void TC2005019_ConfigurationFirmwareforPTGlevel()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Configure Surcharge in Payment Terminal Group Level");
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
                Thread.Sleep(500);
                editCompany.enterCompanyName(data["setupCompany_Name2"].ToString());

                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Visit button");
                editCompany.clickVisittoEdit();

                //Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Payment Terminal Dropdown");
                paymentterminalgroup.clickPaymentTerminalsDropdown();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Payment Terminal Group");
                paymentterminalgroup.clickPaymentTerminalGroups();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "User should be in Payment Terminals");
                Assert.AreEqual("Payment Terminal Groups", configPT.getpaymentterminalsgroupText());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "search Payment Terminal Group");
                paymentTerminals.searchPTgroup(data["editPTG"].ToString());

                paymentTerminals.clickPTGo();

                //view Payment Terminal details
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click view Payment Terminal Group");
                configPT.clickviewPTG();
               
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Configure Payment Terminals");
                configPT.clickconfigurePT();

                
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

               
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Surcharge details in PTG level  saved Sucessfully");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();


        }



    }
}
