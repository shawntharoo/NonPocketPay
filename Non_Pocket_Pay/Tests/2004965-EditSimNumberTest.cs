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
using System.Threading;
using System.Threading.Tasks;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class EditSimNumberTest
    {
        [Test]

        public void TC2004965_EditSimNumberTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Update Sim Number");
            //EditSimNumberPage editSimNumber = new EditSimNumberPage(driver);
            SimNumberDetailsPage simNumberDetails = new SimNumberDetailsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                simNumberDetails.SetSearchByCompany(data["setupCompany_Name2"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click go button");
                simNumberDetails.ClickGoButton();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Visit Button");
                simNumberDetails.ClickVisitButton();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Manage SIM Number");
                simNumberDetails.ClickManageSimNumbers();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Edit SIM Number");
                simNumberDetails.ClickEditSim();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Clear Existing Data");
                simNumberDetails.DataClear();

                Thread.Sleep(2000);
                simNumberDetails.SetNewData(data["_New_Sim"].ToString());

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Save");
                simNumberDetails.ClickEditSave();

                
                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Manage Sim Numbers')]")).Displayed);
                


            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Sim Number Updated sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
