using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Non_Pocket_Pay.Pages;
using Utility.JSONRead;



namespace Non_Pocket_Pay.Tests
{
    class Quest_PinpadFileUpdateStatusTest
    {
        [Test]

        public void TC2005023_Quest_PinpadFileUpdateStatus()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();


            //globals.expRpt.createTest("Add User Test");
            //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The User created sucessfully");
            //globals.expRpt.flushReport();

            Quest_PinpadFileUpdateStatusPage quest_PinpadFileUpdateStatusPage = new Quest_PinpadFileUpdateStatusPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                Assert.AreEqual("Company List", home.getText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                //Click On Quest Reports
                quest_PinpadFileUpdateStatusPage.ClickOnQuestReports();


                //Click on Pinpad Update Status
                quest_PinpadFileUpdateStatusPage.ClickOnPinpadUpdateStatus();


                //Set Serial Number
                quest_PinpadFileUpdateStatusPage.SetSerialNumber(data["_Serial_Number"].ToString());


                //Click On Load Records
                quest_PinpadFileUpdateStatusPage.ClickLoadRecords();


                //Click On Export To Excel
                quest_PinpadFileUpdateStatusPage.ClickExportToExcel();

            }

        }
    }
}