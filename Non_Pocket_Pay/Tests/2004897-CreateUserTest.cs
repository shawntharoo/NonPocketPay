using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using Utility.JSONRead;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class CreateUserTest
    {
        [Test]

        public void TC2004897_CreateUserTest()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            LoginPage loginp = new LoginPage(driver);
            JSONReader JSRead = new JSONReader();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Add User Test");
            UserFunctionsPage userFunc = new UserFunctionsPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                //Search for company
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                userFunc.SetSearchByCompany(data["setupCompany_Name2"].ToString());


                //Click On Go Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                userFunc.ClickGoButton();


                //Click On Visit Button
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                userFunc.ClickVisitButton();


                //Click On Users
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Search for company");
                userFunc.ClickOnUserButton();



                JArray users = (JArray)data["users"];
                for (int i = 0; i < users.Count; i++)
                {

                    //Click On Add User
                    userFunc.ClickOnAddUserButton();


                    //Enter UserName
                    userFunc.SetUserName(users[i]["_User_Name"].ToString());


                    //Enter Email
                    userFunc.SetEmail(users[i]["_Email"].ToString());


                    //Enter Password
                    userFunc.SetPassword(users[i]["_Password"].ToString());


                    //Enter Confirm Password
                    userFunc.SetConfirmPassword(users[i]["_ConfirmPassword"].ToString());


                    //Click Roles
                    userFunc.ClickRoles();


                    //Select Option from Dropdon
                    userFunc.ClickSetOption(users[i]["_Set_Role"].ToString());

                    //select Option
                    userFunc.ClickOption();

                    //Click Save Button
                    userFunc.ClickSave();

                    // Please define the xpath in Page class
                    Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Users')]")).Displayed);

                }
               
            }

              globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The User created sucessfully");
              globals.expRpt.flushReport();

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}



