using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;
using Non_Pocket_Pay.Common;
using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Non_Pocket_Pay.Tests
{
    class CreatePaymentTerminalGroupTest
    {
        
        // View Payment Terminal Group details

        [Test]
        public void createPaymentTerminalGroup()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            GlobalFunctions.expRpt.createTest("Create Payment Terminals Groups");
            GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Create Payment Terminals Groups");
            GlobalFunctions.expRpt.flushReport();

            EditCompanyPage editCompany = new EditCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);

            ViewPaymentTerminalGroupPage paymentterminalgroup = new ViewPaymentTerminalGroupPage(driver);
            CreatePaymentTerminalGroupPage addPyamentTerminalGroup = new CreatePaymentTerminalGroupPage(driver);


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

                // click the add Payment terminal Group button
                addPyamentTerminalGroup.clickaddPyamentTerminalGroup();

                // enter payment Terminal Group details     
                GlobalFunctions.expRpt.logReportStatement(AventStack.ExtentReports.Status.Info, "Enter Comapny Details");
                
                addPyamentTerminalGroup.setPaymentTerminalName(data["StoreName"].ToString());
                addPyamentTerminalGroup.setdeliveryLine(data["pt_deliveryLine"].ToString());                
                addPyamentTerminalGroup.setSuburb(data["pt_postalSuburb"].ToString());
                addPyamentTerminalGroup.setState(data["pt_state"].ToString());
                addPyamentTerminalGroup.setpostalCode(data["pt_postalCode"].ToString());
                addPyamentTerminalGroup.setCountry(data["pt_country"].ToString());
                addPyamentTerminalGroup.setdeliveryAddresscheckbox();
                addPyamentTerminalGroup.clickSavePaymentterminals();

            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
