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
    class MAddAdminUserTest
    {
        [Test]

        public void TC2004977_MAddAdminUserTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Maintainance add admin user test");
            MAdminUserPage mAdminUser = new MAdminUserPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Log report statement");
                mAdminUser.ClickMaintenance();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on user management");
                mAdminUser.ClickUserManagement();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on create admin user");
                mAdminUser.ClickCreateAdminUser();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set details");
                mAdminUser.SetFirstName(data["_M_First_Name"].ToString());

                mAdminUser.SetLastName(data["_M_Last_Name"].ToString());

                mAdminUser.SetEmail(data["_M_Email"].ToString());

                mAdminUser.SetPhone(data["_M_Phone"].ToString());

                mAdminUser.SetUserName(data["_M_User_Name"].ToString());

                mAdminUser.SetPassword(data["_M_Password"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set the role");
                mAdminUser.SetRole();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on save");
                mAdminUser.ClickSave();

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Welcome to Maintenance Administration')]")).Displayed);
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Maintainance Admin User Added successfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }    
    }
}
