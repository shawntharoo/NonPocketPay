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
using Utility.JSONRead;

namespace Non_Pocket_Pay.Tests
{
    class DeleteSimNumberTest
    {
        [Test]

        public void TC2004964_DeleteSimNumberTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            globals.expRpt.CreateTest("Delete Sim Number");
            //DeleteSimNumberPage deleteSimNumber = new DeleteSimNumberPage(driver);
            SimNumberDetailsPage simNumberDetails = new SimNumberDetailsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

               
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Search for company
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                simNumberDetails.SetSearchByCompany(data["setupCompany_Name2"].ToString());

                //Click On Go Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Go Button");
                simNumberDetails.ClickGoButton();

                //Click On Visit Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Visit Button");
                simNumberDetails.ClickVisitButton();

                //click Manage Sim Numbers Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Manage Sim Numbers Button");
                simNumberDetails.ClickManageSimNumbers();

                //click delete
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Delete");
                simNumberDetails.ClickDelete();

                //confirm delete
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Confirm Delete");
                simNumberDetails.ClickConfirmDelete();


                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Manage Sim Numbers')]")).Displayed);
                
            }
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Sim Number Deleted sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
