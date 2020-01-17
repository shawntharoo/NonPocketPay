using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using Utility.JSONRead;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class UserSignIn_ResetPasswordTest
    {
        [Test]

        public void TC2004816_UserSignIn_ResetPasswordTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            UserLoginFunctionsPage userLoginFunctions = new UserLoginFunctionsPage(driver);
            globals.expRpt.CreateTest("Add User Test");
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Navigate().GoToUrl(data["URL"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on reset Password.");
                userLoginFunctions.ClickResetPassword();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set Email Address");
                userLoginFunctions.SetResetEmail("_Reset_Email");

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click send request");
                userLoginFunctions.ClickResetSendRequest();

                Assert.IsTrue(driver.FindElement(By.Id("info-message")).Displayed);
                
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Reset Email Sent");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}

