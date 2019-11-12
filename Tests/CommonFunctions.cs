using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using ConsoleApp.Pages;

namespace ConsoleApp.Tests
{
    class CommonFunctions
    {
        IWebDriver driver;
        public CommonFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void loginToApplication()
        {

            LoginPage loginP = new LoginPage(driver);
            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();
            }
        }
    }
}
