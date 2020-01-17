using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;


namespace Non_Pocket_Pay.Tests
{
    class AddDPTRangeTest
    {
        [Test]

        public void TC2004980_AddDPTRangeTest()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Add DPT Range Test");
            DonationTapRangeFunctionsPage donationTapRangeFunctions = new DonationTapRangeFunctionsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Click on Maintainance
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Maintenance");
                donationTapRangeFunctions.ClickMaintenance();

                //Click on Donation Tap Range
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Donation Tap Range");
                donationTapRangeFunctions.ClickDonationTapRange();

                //Click on Add new DPT Range
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Add new DPT Range");
                donationTapRangeFunctions.ClickAddNewDPTrange();

                //Set from Range value
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set from Range value");
                donationTapRangeFunctions.SetFromRange(data["_Add_DPTRange_From"].ToString());


                //Set to Range Value
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set to Range Value");
                donationTapRangeFunctions.SetToRange(data["_Add_DPTRange_To"].ToString());

                //Click on Save Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Save Button");
                donationTapRangeFunctions.ClickAddSave();

                Assert.IsTrue(driver.FindElement(By.XPath("//h3[contains(text(),'Manage Donation Tap Range')]")).Displayed);
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Add DPT Range Test Passed");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
