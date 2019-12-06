using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using Non_Pocket_Pay.Common;

namespace Non_Pocket_Pay.Tests
{
    class LoginTest
    {
        [Test]
        public void loginSucessfully()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            GlobalFunctions.expRpt.createTest("Login Sucessfully Test");

            comFunc.loginToApplication();

            if (home.getText().Equals("Company List"))
            {
                GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "I have logged in");
            }
            else
            {
                GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "I haven't logged in");
            }


            //globals.expRpt.createTest("Login Not Sucessfully Test");
           // globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "Login Not Sucessfully Test");
            GlobalFunctions.expRpt.flushReport();

            driver.Close();
            driver.Quit();
        }

        [Test]
        public void loginNotsucessfully()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            GlobalFunctions.expRpt.createTest("Login Not Sucessfully Test");

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();

                loginP.setUserName(data["Incorrect_Password"].ToString());
                loginP.setPassword(data["Incorrect_UserName"].ToString());
                loginP.clickLogin();
            }

            if (home.getloginText2().Equals("Login to your Cloud Eftpos account"))
                {
                    GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "I haven't logged in");

                }
                else
                {
                    GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The User logged into the system");
                }

            GlobalFunctions.expRpt.flushReport();

            driver.Close();
            driver.Quit();
        }


        

    }
}