// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 10/12/2019
// Updated Date - 16/12/2019
// Version - 0.0.01

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
    class AddDelearCompanyTest
    {
        [Test]
        [Parallelizable]
        //[TestCaseSource(typeof(AddCompanyPage), "BrowserToRunWith")]
        //public void TC2004821_AddDealerCompany(String browserName)
        public void TC2004821_AddDealerCompany()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Add Company Test");            
            AddCompanyPage addCompany = new AddCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();                

                JArray dealercompanies = (JArray)data["dealercompanies"];
                for (int i = 0; i < dealercompanies.Count; i++)
                {
                    // compare the loaded screen with the expected screen
                    Assert.AreEqual("Company List", home.getText());
                    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3000);

                    // Click add a company button 

                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Company button");
                    addCompany.clickAddCompany();

                    // compare the loaded screen with the expected screen
                
                    Assert.AreEqual("Company Information", addCompany.getcompanyInfor());

                    // enter comapny details  
                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Comapny details");
                   
                 
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company Name");
                    addCompany.setCompanyName(dealercompanies[i]["Company_Name"].ToString());

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company Type");
                    addCompany.setCustomerType((string)dealercompanies[i]["dealerCustomer_Type"]);

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Admin User Name");
                    addCompany.setadminUserName((string)dealercompanies[i]["Admin_Username"]);

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Admin Email");
                    addCompany.setemailAddress(dealercompanies[i]["Email"].ToString());

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Admin Password");
                    addCompany.setPassword((string)dealercompanies[i]["passwordcreate"]);

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Confirm Admin Password");
                    addCompany.setconfirmPassword((string)dealercompanies[i]["passwordcreate"]);

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company Type");
                    addCompany.setcompanyType((string)dealercompanies[i]["dealercompanyType"]);

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Reporting Frequency");
                    addCompany.setreportingFrequency((string)dealercompanies[i]["reportingFrequency"]);

                    
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Tick Donation tap point");
                    addCompany.clickdonationTappoint();

                    Thread.Sleep(500);
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Tick Bank setting");
                    editCompany.clickNAB();

                    Thread.Sleep(500);
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Pinpad File details");
                    addCompany.setpinpadFile((string)dealercompanies[i]["pinpadFile"]);

                    Thread.Sleep(500);
                    addCompany.clickpinpad();

                    Thread.Sleep(500);
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Create button");
                    addCompany.clickCreate();
                                      
                    // compare the loaded screen with the expected screen
                    Thread.Sleep(500);
                    Assert.AreEqual("Company List", home.getText());
                    Thread.Sleep(500);
                    
                    // search for the created company 
                    editCompany.enterCompanyName(dealercompanies[i]["Company_Name"].ToString());
                    Thread.Sleep(500);
                    editCompany.clickGo();

                    //Thread.Sleep(500);
                    ////addCompany.clickEdit();
                    //addCompany.clickEdit1();

                    //Assert.AreEqual("Edit a company", editCompany.geteditcompanyBanner());
                    //Thread.Sleep(500);

                    //if (editCompany.geteditcompanyBanner().Equals("Edit a company"))
                    //{
                    //    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The company created sucessfully");
                    //}
                    //else
                    //{
                    //    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The company is not in the system");
                    //}

                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Company created sucessfully");
                    globals.expRpt.flushReport();
                }
            }

            
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}