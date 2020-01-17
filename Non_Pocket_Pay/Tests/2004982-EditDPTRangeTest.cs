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
    class EditDPTRangeTest
    {
        [Test]

        public void TC2004982_EditDPTRangeTest()
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

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Edit DPT Range");
                donationTapRangeFunctions.ClickEditDPTRange();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set From Range");
                donationTapRangeFunctions.ClearDataFromRange();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clear data");
                donationTapRangeFunctions.ClearDataToRange();

                donationTapRangeFunctions.SetFromRange(data["_Edit_DPTRange_From"].ToString());

                donationTapRangeFunctions.SetToRange(data["_Edit_DPTRange_To"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Save");
                donationTapRangeFunctions.ClickEditSave();

                Assert.IsTrue(driver.FindElement(By.XPath("//h3[contains(text(),'Manage Donation Tap Range')]")).Displayed);

            }
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "DPT Range Updated Successfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
