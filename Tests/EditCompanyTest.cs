using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ConsoleApp.Pages;
using NUnit.Framework;
using Utility.JSONRead;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.Tests
{
    class EditCompanyTest
    {
        [Test]
        public void editCompany()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();

            EditCompanyPage editCompany = new EditCompanyPage(driver);
            EditCompanyPage companyInfor = new EditCompanyPage(driver);
            EditCompanyPage searchCompany = new EditCompanyPage(driver);


            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);


                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();


                Assert.AreEqual("Company List", home.getText());

                // search for the company.. update to "Company_Name" later         
                searchCompany.enterCompanyName(data["searchToEditCompany_Name"].ToString());
                editCompany.clickGo();

                editCompany.setrowCount(data["Row_Count"].ToString());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                //click edit
                editCompany.clickEdit();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                //compare the loaded screen with the expected screen
                Assert.AreEqual("Edit a company", editCompany.geteditcompanyBanner());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                //enter comapny details
                editCompany.setCompanyName("testname");
                //editCompany.clickcontactSurcharging();
                editCompany.clickSave();

                //Assert.AreEqual("No data available!", editCompany.getnoCompany());

            }
            driver.Close();
            driver.Quit();
        }
    }
}