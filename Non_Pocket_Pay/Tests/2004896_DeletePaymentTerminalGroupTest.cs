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
    class DeletePaymentTerminalGroupTest
    {

        [Test]
        public void TC2004896_DeletePaymentTerminalGroup()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Delete Payment Terminals Groups");
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
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Search Company name");
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Go button");
                editCompany.clickGo();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Edit Payment Terminal button");
                paymentterminalgroup.clickVisittoEdit();

                //Thread.Sleep(500);
                //Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Payment Terminals");
                paymentterminalgroup.clickPaymentTerminalsDropdown();
   
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Load Payment Terminal Groups");
                paymentterminalgroup.clickPaymentTerminalGroups();

                // compare the loaded screen with the expected screen
             
                Assert.AreEqual("Payment Terminal Groups", paymentterminalgroup.getPaymentTerminalGroupText());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Delete Payment Terminal Group");
                paymentterminalgroup.enterPTgroup(data["DeletePTgroup"].ToString());

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Search Payment Terminal Group");
                paymentterminalgroup.searchPT();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Delete Payment Terminal Group");
                paymentterminalgroup.deletePT();

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Delete Confirmation");
                paymentterminalgroup.deleteConfirmationPT();

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Payment Terminals Group deleted Sucessfully");
                globals.expRpt.flushReport();

            }


            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
