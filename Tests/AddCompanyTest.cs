using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using Non_Pocket_Pay.Common;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using DataDriven.Utilities;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace Non_Pocket_Pay.Tests
{
    class AddCompanyTest
    {
        [Test]
        public void addCompany()
        {
            
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
             ExtentReporter expRpt = new ExtentReporter();
        expRpt.createTest("Add Company Test");


            AddCompanyPage addCompany = new AddCompanyPage(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            EditCompanyPage searchCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
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

                    GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Comapny details");

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
                    //addCompany.clickbankSetting();
                    addCompany.setpinpadFile((string)companies[i]["pinpadFile"]);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
                    addCompany.clickCreate();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

                    // compare the loaded screen with the expected screen
                    Assert.AreEqual("Company List", home.getText());
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);


                    // search for the created company 
                    searchCompany.enterCompanyName(companies[i]["Company_Name"].ToString());
                    editCompany.clickGo();





                
                    string comp = addCompany.GetSearchedCompany();

                    if(comp == companies[i]["Company_Name"].ToString())
                    {
                        GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The company created sucessfully");
                    }
                    else
                    {
                        GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The company is not in the system");
                    }

                    GlobalFunctions.expRpt.flushReport();
                }
            }

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}