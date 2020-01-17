using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class DeletePOSGatewayTest
    {
        [Test]

        public void TC2004894_DeletePOSGatewayTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Delete POS Gateway");
            POSGatewayPage pOSGateway = new POSGatewayPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                //Assert.AreEqual("Company List", home.getText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Search for company
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for Company");
                pOSGateway.SetSearchByCompany(data["setupCompany_Name2"].ToString());

                //Click On Go Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Go Button");
                pOSGateway.ClickGoButton();

                //Click On Visit Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Visit Button");
                pOSGateway.ClickVisitButton();

                //click on manage pos gateways
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Manage POS Gateways");
                pOSGateway.ClickManagaPOSGateways();

                //click on delete button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Delete Button");
                pOSGateway.ClickDelete();

                //click confirm delete
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Confirm Delete");
                pOSGateway.ClickConfirmDelete();

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Manage POS Gateways')]")).Displayed);

            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The POS Gateway Deleted sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
