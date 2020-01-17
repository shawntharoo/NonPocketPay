using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.JSONRead;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class TerminalCountReportTest
    {
        [Test]
        public void TC2005011_ReportTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            QR_TerminalCountsPage qR_TerminalCounts = new QR_TerminalCountsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            //globals.expRpt.CreateTest("User SignIn Test");

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);


                qR_TerminalCounts.ClickQuestReports();

                qR_TerminalCounts.ClickTerminalCounts();

                qR_TerminalCounts.ClickTCRExport();


            }

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
