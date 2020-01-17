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
    class SurchargeConfigurationforCompanylevelTest
    {
         [Test]
        public void TC2004991_SurchargeConfigurationforCompanylevel()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            globals.expRpt.CreateTest("Configure Surcharge in Company Level");

            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
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


                //Assert.AreEqual("QUESTAutoComp01", editCompany.getcompanyDetailstoview());
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Configure Payment Terminals");
                configPT.clickconfigurePT();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Surcharge Configuration");
                configPT.clickSurchargeConfig();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "User should be in Surcharging");
                Assert.AreEqual("Surcharging", configPT.getsurchargingText());

                Thread.Sleep(500);
                configPT.cleardebitRate();
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Debit Rate");
                configPT.setdebitRate(data["DebitRate"].ToString());

                Thread.Sleep(500);
                configPT.clearvisaAmount();
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Debit Amount");
                configPT.setvisaAmount(data["VisaAmount"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Save Surcharge details");
                configPT.clickSaveSurcharge();

                
                Assert.AreEqual("Configure payment terminal options", configPT.getconfigurePToptionsText());

                if (configPT.getconfigurePToptionsText().Equals("Configure payment terminal options"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "User should be in Configure payment terminal options");
                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "User should is not in the correct page");
                }

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Surcharge details in company level  saved Sucessfully");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();


        }


    }
}
