using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using Utility.JSONRead;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class TerminalCountReportByCompanyTest
    {
        [Test]

        public void TC2005012_TerminalCountReportByCompany()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Get Terminal Count Report By Company");            
            TerminalCountReportByCompanyPage terminalCountReportByCompany = new TerminalCountReportByCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Click On Quest Reports
                terminalCountReportByCompany.ClickQuestReports();
             
                //Click Terminal Counts
                terminalCountReportByCompany.ClickTerminalCounts();

                //Click Exports
                
                terminalCountReportByCompany.ClickBank();

                terminalCountReportByCompany.ClickExport();
                


            }

        }
    }
}
