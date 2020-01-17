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
    class EditUserTest
    {
        [Test]

        public void TC2004898_EditUserTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Edit User Test");
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
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Go Button");
                userFunc.ClickGoButton();


                //Click On Visit Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Visit Button");
                userFunc.ClickVisitButton();


                //Click On Users
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Users");
                userFunc.ClickOnUserButton();


                //Search User
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search User");
                userFunc.SetSearch(data["_Search_User"].ToString());

                //click go
                userFunc.ClickSearchGo();

                //Click On Edit Details
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click On Edit Details");
                userFunc.ClickEditDetails();


                //Enter Comment
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Comment");
                userFunc.SetComment(data["_Comment"].ToString());

                //Click Save
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Save");
                userFunc.ClickSave();

                // please define the xpath in Page class
                Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Users')]")).Displayed);
                
            }

            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The User Updated sucessfully");
            globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }

}