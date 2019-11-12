using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ConsoleApp.Pages;
using NUnit.Framework;
using Utility.JSONRead;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using Non_Pocket_Pay.Pages;

namespace ConsoleApp.Tests
{
    class AddCompanyTest
    {
        [Test]
        public void addCompany()
        {
            globals.expRpt.createTest("Add compay");
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Add company test");
            globals.expRpt.flushReport();

            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();
            AddCompanyPage addCompany = new AddCompanyPage(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            using (StreamReader file = File.OpenText(@"D:\Projects\ConsoleApp\Data_Source\Data_Set.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                JArray companies = (JArray)data["companies"];
                for (int i = 0; i < companies.Count; i++)
                {
                    // compare the loaded screen with the expected screen
                    Assert.AreEqual("Company List", home.getText());

                    // hit add a company button         
                    addCompany.clickAddCompany();

                    // compare the loaded screen with the expected screen
                    Assert.AreEqual("Company Information", addCompany.getcompanyInfor());
                    // enter comapny details     
                    addCompany.setCompanyName(companies[i]["Company_Name"].ToString());
                    addCompany.setCustomerType((string)companies[i]["Customer_Type"]);
                    addCompany.setadminUserName((string)companies[i]["Admin_Username"]);
                    //IF email is not there create the use ELSE check the validation "//li[contains(text(),'The email address poloS@yahoo.com is already taken')]"
                    addCompany.setemailAddress(companies[i]["Email"].ToString());
                    addCompany.setPassword((string)companies[i]["passwordcreate"]);
                    addCompany.setconfirmPassword((string)companies[i]["passwordcreate"]);
                    addCompany.setcompanyType((string)companies[i]["companyType"]);
                    addCompany.setreportingFrequency((string)companies[i]["reportingFrequency"]);
                    addCompany.clickdonationTappoint();
                    addCompany.clickbankSetting();
                    addCompany.setpinpadFile((string)companies[i]["pinpadFile"]);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
                    addCompany.clickCreate();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                    // compare the loaded screen with the expected screen
                    Assert.AreEqual("Company List", home.getText());
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                    // search for the created company 
                    //editCompany.enterCompanyName(JSRead.jsonReader("../ConsoleApp/Data_Source/data.json", "Company_Name"));
                    //editCompany.clickGo();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
                }
            }

            driver.Close();
            driver.Quit();
        }
    }
}