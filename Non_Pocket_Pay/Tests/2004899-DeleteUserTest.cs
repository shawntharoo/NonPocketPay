using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class DeleteUserTest
    {
        [Test]

        public void TC2004899_DeleteUserTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Add Company Test");        
            UserFunctionsPage userFunc = new UserFunctionsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                Assert.AreEqual("Company List", home.getText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                //Search for company
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Comapny details");
                userFunc.SetSearchByCompany(data["setupCompany_Name2"].ToString());


                //Click On Go Button
                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Go Button");
                userFunc.ClickGoButton();
               

                //Click On Visit Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Visit Button");
                userFunc.ClickVisitButton();
                

                //Click On Users
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Users");
                userFunc.ClickOnUserButton();


                //Click On Delete
                //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Delete");
                userFunc.ClickOnDeteteButton();

                //Delete
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Delete");
                userFunc.ClickDelete();

                // please define the xpath in Page class
                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Users')]")).Displayed);

                
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The User Deleted sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }

}