// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
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


namespace Non_Pocket_Pay.Tests
{
    class CreateCompanyunderDealerTest
    {
        [Test]
        [Parallelizable]
        //[TestCaseSource(typeof(AddCompanyPage), "BrowserToRunWith")]
        //public void TC2004821_AddDealerCompany(String browserName)
        public void TC2004821_CreateCompanyunderDealer()
        {

            IWebDriver driver = new ChromeDriver();

            HomePage home = new HomePage(driver);

            globals.expRpt.CreateTest("Add Company Test");

            AddCompanyPage addCompany = new AddCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);

            //addCompany.SetupBrowser(browserName);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                // search for the created company 
                
                Thread.Sleep(500);
                editCompany.enterCompanyName(data["DealerCompany_Name"].ToString());

                Thread.Sleep(500);
                editCompany.clickGo();


                Thread.Sleep(500);

                addCompany.clickvisitbutton();

                // Add company under Dealer company 

                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Company button");
                addCompany.clickAddCompany();


                JArray companies = (JArray)data["companies"];
                for (int n = 0; n < companies.Count; n++)
                {
                    // enter comapny details  

                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Comapny details");


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company Name");
                    addCompany.setCompanyName(companies[n]["Company_Name"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Admin User Name");
                    addCompany.setadminUserName((string)companies[n]["Admin_Username"]);


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Admin Email");
                    addCompany.setemailAddress(companies[n]["Email"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Admin Password");
                    addCompany.setPassword((string)companies[n]["passwordcreate"]);


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Confirm Admin Password");
                    addCompany.setconfirmPassword((string)companies[n]["passwordcreate"]);


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Company Type");
                    addCompany.setcompanyType((string)companies[n]["companyType"]);


                    //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Reporting Frequency");
                    //addCompany.setreportingFrequency((string)companies[n]["reportingFrequency"]);


                    //globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Tick Donation tap point");
                    //addCompany.clickdonationTappoint();

                    Thread.Sleep(500);
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Tick Bank setting");
                    addCompany.clickbankSetting();

                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Address");
                    addCompany.SetbillingLine(data["pt_deliveryLine"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Suburb");
                    addCompany.SetbillingSuburb(data["pt_postalSuburb"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal State");
                    addCompany.SetbillingState(data["pt_state"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Code");
                    addCompany.SetbillingPostcode(data["pt_postalCode"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Postal Country");
                    addCompany.setbillingCountry(data["pt_country"].ToString());


                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Delivery Address");
                    addCompany.setdeliveryAddresscheckbox();

                    Thread.Sleep(500);
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Enter Pinpad File details");
                    addCompany.setpinpadFile((string)companies[n]["pinpadFile"]);

                    Thread.Sleep(500);
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Click Add Company button");
                    addCompany.clickAddCompany();
                }

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Company created sucessfully");
                globals.expRpt.flushReport();
            }
        
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
}
}