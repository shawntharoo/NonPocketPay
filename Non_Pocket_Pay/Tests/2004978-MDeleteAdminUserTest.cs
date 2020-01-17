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
    class MDeleteAdminUserTest
    {
        [Test]

        public void TC2004978_MDeleteAdminUserTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Maintainance add admin user test");
            //MAdminUserPage mAdminUser = new MAdminUserPage(driver);
            MAdminUserPage mAdminUser = new MAdminUserPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Maintainance");
                mAdminUser.ClickMaintenance();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on user management");
                mAdminUser.ClickUserManagement();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set Data");
                mAdminUser.SetSearch(data["_M_First_Name"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Load Records");
                mAdminUser.ClickLoadRecords();

                Thread.Sleep(2000);
                mAdminUser.ClickDelete();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on remove user");
                mAdminUser.ClickRemoveUser();

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Welcome to Maintenance Administration')]")).Displayed);
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, " User Deleted successfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();


        }
    }
}
