// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01


using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using DataDriven.Utilities;


namespace Non_Pocket_Pay.Tests
{
    class CommonFunctions
    {
        IWebDriver driver;
        public CommonFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string getDatasourcePath()
        {
            string fileName = "Data_Set.json";
            //string dataSourcePath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
            //string fullPath = Path.Combine(dataSourcePath, @"Data_Source\", fileName);
            string fullPath = Path.GetFullPath("C:/Data_Source/Data_Set.json");
            return fullPath;

        }
        public void loginToApplication()
        {

            LoginPage loginP = new LoginPage(driver);
            
            string fullPath = getDatasourcePath();
            using (StreamReader file = File.OpenText(fullPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {

                JObject data = (JObject)JToken.ReadFrom(reader);
                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                // Enter Admin Login Details
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();
            }
        }
        public void NotloginToApplication()
        {

            LoginPage loginP = new LoginPage(driver);
            string fullPath = getDatasourcePath();
            using (StreamReader file = File.OpenText(fullPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                // Enter Admin Login Details
                loginP.setUserName(data["Incorrect_Password"].ToString());
                loginP.setPassword(data["Incorrect_UserName"].ToString());
                loginP.clickLogin();
            }
        }


    }
}
