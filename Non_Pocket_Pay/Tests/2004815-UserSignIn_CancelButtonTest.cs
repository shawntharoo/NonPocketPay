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
    class UserSignIn_CancelButtonTest
    {
        [Test]

        public void TC2004815_UserSignIn_CancelButtonTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            UserLoginFunctionsPage userLoginFunctions = new UserLoginFunctionsPage(driver);
            globals.expRpt.CreateTest("Cancel Button Functionality Test");
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Navigate().GoToUrl(data["URL"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Reset Password");
                userLoginFunctions.ClickResetPassword();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click on Cancel Button");
                userLoginFunctions.ClickCancel();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter the User Name");
                userLoginFunctions.SetUserName(data["User_Name"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter the password");
                userLoginFunctions.SetPassword(data["password"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click SignIn");
                userLoginFunctions.ClickSignIn();

                //Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Generate Reports for:')]")).Displayed);
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Cancel Button Worked fine");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
