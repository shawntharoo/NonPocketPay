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
    class ViewPaymentTerminalGroupTest
    {
        // View Payment Terminal Group details

        [Test]
        public void viewPaymentTerminalGroup()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPage loginP = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            JSONReader JSRead = new JSONReader();

            GlobalFunctions.expRpt.createTest("Payment Terminals Groups");
            GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Payment Terminals Groups");
            GlobalFunctions.expRpt.flushReport();

            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            // ViewPaymentTerminalGroupPage paymentterminalgroup = new ViewPaymentTerminalGroupPage(driver);
            ViewPaymentTerminalGroupPage paymentterminalgroup = new ViewPaymentTerminalGroupPage(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

               // compare the loaded screen with the expected screen
               Assert.AreEqual("Company List", home.getText());
               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // search for the company.. update to "Company_Name" later         
                paymentterminalgroup.enterCompanyName(data["setupCompany_Name2"].ToString());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);
                editCompany.clickGo();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);
                paymentterminalgroup.clickVisittoEdit();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);
                Assert.AreEqual("QUESTAutoComp01", paymentterminalgroup.getcompanyDetailstoview());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                paymentterminalgroup.clickPaymentTerminalsDropdown();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);
                paymentterminalgroup.clickPaymentTerminalGroups();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // compare the loaded screen with the expected screen
                Assert.AreEqual("Payment Terminal Groups", paymentterminalgroup.getPaymentTerminalGroupText());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);

                // click the view button
                // paymentterminalgroup.clickPaymentTerminalGroups();


            }
            driver.Close();
            driver.Quit();
        }
    }
}
