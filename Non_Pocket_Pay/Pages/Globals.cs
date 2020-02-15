// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01


using DataDriven.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System;

namespace Non_Pocket_Pay.Pages
{
    static class globals
    {
        public static ExtentReporter expRpt = new ExtentReporter();

        public static IWebDriver selectBrowser(string browserName)
        {
            IWebDriver driver;

            if (browserName.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
            else if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }

            return driver;
        }

        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = { "chrome", "firefox" };
            foreach (String b in browsers)
            {
                yield return b;
            }
        }


    }
}
