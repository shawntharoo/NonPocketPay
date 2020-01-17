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
    class DeleteDPTRangeTest
    {

        [Test]

        public void TC2004981_DeleteDPTRangeTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Delete DPT Range Test");
            DonationTapRangeFunctionsPage donationTapRangeFunctions = new DonationTapRangeFunctionsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();


                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Maintenance");
                donationTapRangeFunctions.ClickMaintenance();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Donation Tap Range");
                donationTapRangeFunctions.ClickDonationTapRange();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Delete");
                donationTapRangeFunctions.ClickDelete();

                Assert.IsTrue(driver.FindElement(By.XPath("//h3[contains(text(),'Manage Donation Tap Range')]")).Displayed);

            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Delete DPT Range Test Passed");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
