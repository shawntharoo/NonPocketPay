using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Non_Pocket_Pay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Non_Pocket_Pay.Tests
{
    class AddKioskCompanyTest
    {
        [Test]
        public void TC_2005029_AddKioskCompany()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            //globals.expRpt.CreateTest("Add Company Test");

            AddCompanyPage addCompany = new AddCompanyPage(driver);
            CommonFunctions comFunc = new CommonFunctions(driver);
            EditCompanyPage editCompany = new EditCompanyPage(driver);

            string fullpath = comFunc.getDatasourcePath();
            using (StreamReader file = File.OpenText(fullpath))

            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                comFunc.loginToApplication();

                addCompany.clickAddCompany();

                addCompany.setCompanyName(data["_Kiosk_CompName"].ToString());

                addCompany.setadminUserName(data["_Kiosk_AdminUser"].ToString());

                addCompany.setemailAddress(data["_Kiosk_Email"].ToString());

                addCompany.setPassword(data["_Kiosk_Password"].ToString());

                addCompany.setconfirmPassword(data["_Kiosk_CnfmPassword"].ToString());

                addCompany.CheckDonationKioskAware();

                addCompany.clickCreate();
                // test comment                                

            }

            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}

