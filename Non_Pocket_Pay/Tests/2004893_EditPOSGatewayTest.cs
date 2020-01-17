using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class EditPOSGatewayTest
    {
        [Test]

        public void TC2004893_EditPOSGatewayTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            POSGatewayPage pOSGateway = new POSGatewayPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            globals.expRpt.CreateTest("Edit POS Gateway Test");

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Search by company");
                pOSGateway.SetSearchByCompany(data["setupCompany_Name2"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Go Button");
                pOSGateway.ClickGoButton();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Report Statement");
                pOSGateway.ClickVisitButton();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Go Button");
                pOSGateway.ClickManagaPOSGateways();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Edit Record");
                pOSGateway.ClickEditRecord();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clear data in the field");
                pOSGateway.ClearRecord();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Add new record");
                pOSGateway.EditedNewRecord(data["_Edit_POS_Record"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Save");
                pOSGateway.ClickEditSave();

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Manage POS Gateways')]")).Displayed);

            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "POS Gateway Updated sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
