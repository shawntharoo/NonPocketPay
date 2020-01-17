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
using Utility.JSONRead;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class AddSimNumberDetailsTest
    {
        [Test]

        public void TC2004963_AddSimNumberDetailsTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);            
            globals.expRpt.CreateTest("Add Sim Number Details");    
            SimNumberDetailsPage simNumberDetails = new SimNumberDetailsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                Assert.AreEqual("Company List", home.getText());
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

                JArray _Sim_Numbers = (JArray)data["_Sim_Numbers"];
                for (int i = 0; i < _Sim_Numbers.Count; i++)
                {

                    //click add sim number button
                    //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Sim Number Button");
                    Thread.Sleep(2000);
                    simNumberDetails.ClickAddSimNumbers();

                    //set sim number
                    //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Set Sim Number");
                    simNumberDetails.SetSimNumber((string)_Sim_Numbers[i]);

                    //click save button
                    //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Save Button");
                    simNumberDetails.ClickSave();                    
                }

                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Manage Sim Numbers')]")).Displayed);
            }
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Sim Number Details Added sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();

        }
    }
}
