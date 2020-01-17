// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Non_Pocket_Pay.Pages;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class LoginSucessfullyTest
    {
        [Test]
        public void TC2004809_LoginSucessfully()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            globals.expRpt.CreateTest("Login Sucessfully Test");

            comFunc.loginToApplication();

            if (home.getText().Equals("Company List"))
            {
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "I have logged in");
            }
            else
            {
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "I haven't logged in");
            }

            globals.expRpt.flushReport();

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
        

    }
}