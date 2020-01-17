using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using Utility.JSONRead;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class AddPOSGatewayTest
    {
        [Test]

        public void TC2004892_AddPOSGatewayTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Add POS Gateway Test");
            POSGatewayPage pOSGateway = new POSGatewayPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Search for company
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Comapny details");
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



                JArray _POS_Gateway_Name = (JArray)data["_POS_Gateway_Name"];
                for (int i = 0; i < _POS_Gateway_Name.Count; i++)
                {
                    // click on Add POS Gateway
                   
                    Thread.Sleep(2000);
                    pOSGateway.ClickAddPOSGateway();
                    //set pos gateway name                   
                    pOSGateway.SetPOSGatewayName((string)_POS_Gateway_Name[i]);

                    //check default checkbox
                    pOSGateway.CheckDefault();

                    //click save butoon
                    pOSGateway.ClickSave();

                    Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Manage POS Gateways')]")).Displayed);

                }
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "POS Gateway created sucessfully");
            globals.expRpt.flushReport();
            driver.Dispose();
        }
    }
}
