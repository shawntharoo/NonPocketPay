using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;     
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using DataDriven.Utilities;

namespace Non_Pocket_Pay.Tests
{
    class EditCompanyTest
    {
        [Test]
        public void TC2004859_EditCompany()
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.CreateTest("Edit company test");
            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);            

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                Assert.AreEqual("Company List", home.getText());

                // search for the company.. update "Company_Name" later   
                Thread.Sleep(500);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Search Company name");
                editCompany.enterCompanyName(data["searchtoEditCompany_Name"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Go Company");
                editCompany.clickGo();

                //searchCompany.enterCompanyName(data["searchtoEditCompany_Name"].ToString());
                //editCompany.clickGo();


                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Filter Row counts");
                editCompany.setrowCount(data["Row_Count"].ToString());

                //click edit
                Thread.Sleep(1000);
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Click Edit button");
                editCompany.clickEdit();
                Thread.Sleep(1000);

                //compare the loaded screen with the expected screen

                Assert.AreEqual("Edit a company", editCompany.geteditcompanyBanner());
               
                //enter comapny details
                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Update the Company name");
                editCompany.setCompanyName(data["editCompany_Name"].ToString());

                
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Update the Company type");
                editCompany.setCompanyType(data["editCustomer_Type"].ToString());

                //editCompany.clickcontactSurcharging();


                editCompany.clickNAB();

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Save Company details");
                editCompany.clickSave();

                             
                //IAlert simpleAlert = driver.SwitchTo().Alert();
                //simpleAlert.Accept();
                //editCompany.clickpopoverSurcharging();

                Assert.AreEqual("Company List", home.getText());

                if (home.getText().Equals("Company List"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The user is in the Company List");
                }
                else
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "The company is not in the system");
                }

                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Company details updated sucessfully");
                globals.expRpt.flushReport();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


    }
}