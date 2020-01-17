using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using Utility.JSONRead;
using System;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class MEditAdminUserTest
    {
        [Test]

        public void TC2004979_MEditAdminUserTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();

            globals.expRpt.CreateTest("Add User Test");
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

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Maintainance");
                mAdminUser.ClickMaintenance();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on User Management");
                mAdminUser.ClickUserManagement();

                mAdminUser.SetSearch(data["_Edit_Admin_User"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Load Records");
                mAdminUser.ClickLoadRecords();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Edit Record");
                mAdminUser.ClickEditRecord();

                mAdminUser.SetEditFirstName(data["_Edit_First_Name"].ToString());

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Welcome to Maintenance Administration')]")).Displayed);
               
            }
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Edit User Test Passed");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
