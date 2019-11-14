using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using Non_Pocket_Pay.Common;
using NUnit.Framework;
using Utility.JSONRead;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Non_Pocket_Pay.Tests
{
    class EditCompanyTest
    {
        [Test]
        public void editCompany()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            globals.expRpt.createTest("Edit company test");
            globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "The Company updated sucessfully");
            globals.expRpt.flushReport();

            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                Assert.AreEqual("Company List", home.getText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // search for the company.. update "Company_Name" later         
                editCompany.enterCompanyName(data["searchtoEditCompany_Name"].ToString());
                editCompany.clickGo();
                //searchCompany.enterCompanyName(data["searchtoEditCompany_Name"].ToString());
                //editCompany.clickGo();

                editCompany.setrowCount(data["Row_Count"].ToString());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                //click edit
                editCompany.clickEdit();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                //compare the loaded screen with the expected screen
                Assert.AreEqual("Edit a company", editCompany.geteditcompanyBanner());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
                //enter comapny details
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Update the Company name");
                editCompany.setCompanyName(data["editCompany_Name"].ToString());
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Update the Company type");
                editCompany.setCompanyName(data["editCustomer_Type"].ToString());
                globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Save Company details");
                //editCompany.clickcontactSurcharging();
                editCompany.clickSave();

                //Assert.AreEqual("No data available!", editCompany.getnoCompany());

                if (home.getText().Equals("Company List"))
                {
                    globals.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Company details updated sucessfully");
                }
                else
                {
                    globals. expRpt.logReportStatement(AventStack.ExtentReports.Status.Fail, "Company is not in the system to edit");
                }


            }
            driver.Close();
            driver.Quit();
        }
    }
}