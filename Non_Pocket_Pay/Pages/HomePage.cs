// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using System;
using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver drivertemp)
        {
            driver = drivertemp;
        }

        By companyList = By.XPath("//h2[contains(text(),'Company List')]");
        By loginText = By.XPath("//p[contains(text(),'Login to your Cloud Eftpos account')]");


        public string getText()
        {

            return driver.FindElement(companyList).Text;

        }

        public string getloginText2()
        {

            return driver.FindElement(loginText).Text;

        }

    }
}