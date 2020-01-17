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

namespace Non_Pocket_Pay.Tests
{
    class ErroneousTransactionCountTest
    {
        [Test]

        public void TC2005018_ErroneousTransactionCount()
        {
            IWebDriver driver = new ChromeDriver();
            QR_TransactionCountsPage qR_TransactionCounts = new QR_TransactionCountsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
           
            //globals.expRpt.CreateTest("Transaction Count For All Companies Test");
            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Quest Reports");
                qR_TransactionCounts.ClickQuestReports();

                 //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Transaction Counts");
                qR_TransactionCounts.ClickTransactionCounts();

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set From date");
                qR_TransactionCounts.SetDateFrom(data["_Trans_Count_DateFrom"].ToString());

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set to date");
                qR_TransactionCounts.SetDateTo(data["_Trans_Count_DateTo"].ToString());

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Company DropDown");
                qR_TransactionCounts.ClickCompDropDown();

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Selcet Company");
                qR_TransactionCounts.ClickCompany();

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Update");
                qR_TransactionCounts.ClickUpdate();

                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Update");
                qR_TransactionCounts.ClickErroneousTransactionCountExport();

            }

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
