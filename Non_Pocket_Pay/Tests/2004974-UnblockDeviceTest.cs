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
    class UnblockDeviceTest
    {
        [Test]

        public void TC2004974_UnblockDeviceTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Unblock Device Test");            
            DevicesPage devices = new DevicesPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Search for company
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                devices.SetSearchByCompany(data["setupCompany_Name2"].ToString());


                //Click On Go Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on go button");
                devices.ClickGoButton();

                //Click On Visit Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Visit Button");
                devices.ClickVisitButton();

                //Click on devices
                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Devices");
                devices.ClickDevices();

                //Set search device
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set search device");
                devices.SetSearch(data["_Search_Device"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Go");
                devices.ClickGo();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Unblock");
                devices.ClickUnblock();

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Devices')]")).Displayed);
                
            }
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "New device Unblocked successfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }


    }
}
