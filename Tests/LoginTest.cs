using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ConsoleApp.Pages;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;

namespace ConsoleApp.Tests
{
    class LoginTest
    {
        [Test]
        public void loginSucessfully()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            CommonFunctions comFunc = new CommonFunctions(driver);

            globals.expRpt.createTest("My Login Test");

            comFunc.loginToApplication();

            if (home.getText().Equals("Manger Id : mngr184115"))
            {
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "I have logged in");
            }
            else
            {
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "I haven't logged in");
            }



            globals.expRpt.createTest("My Test");
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "This is test 2");
            globals.expRpt.flushReport();

            driver.Close();
            driver.Quit();
        }

        [Test]
        public void loginNotsucessfully()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();

            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);


                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName("invalid");
                loginP.setPassword("invalid");
                loginP.clickLogin();


                Assert.AreEqual("Login to your Cloud Eftpos account", home.getloginText2());

            }

            driver.Close();
            driver.Quit();
        }

    }
}