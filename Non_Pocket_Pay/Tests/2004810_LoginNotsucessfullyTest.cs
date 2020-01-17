// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class LoginNotsucessfullyTest
    {

        [Test]
        public void TC2004810_LoginNotsucessfully()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            globals.expRpt.CreateTest("Login Not Sucessfully Test");

            comFunc.NotloginToApplication();

            if (home.getloginText2().Equals("Login to your Cloud Eftpos account"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "I haven't logged in");

                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The User logged into the system");
                }

            globals.expRpt.flushReport();

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


        

    }
}