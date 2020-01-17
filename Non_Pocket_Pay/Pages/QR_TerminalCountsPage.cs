using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Pocket_Pay.Pages
{
    class QR_TerminalCountsPage
    {
        //Create Driver
        IWebDriver driver;

        //Constructor
        public QR_TerminalCountsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By QuestReports = By.XPath("//a[contains(text(),'Quest Reports')]");
        By TerminalCounts = By.Id("terminalCountReport");
        By TCRExport = By.XPath("//div[2]//div[1]//div[1]//div[1]//a[1]");
        By Search = By.Id("search");
        By Go = By.XPath("//button[@class='btn']");
        By TCRCExport = By.XPath("//div[5]//div[1]//div[1]//div[1]//a[1]");



        public void ClickQuestReports()
        {
            driver.FindElement(QuestReports).Click();
        }

        public void ClickTerminalCounts()
        {
            driver.FindElement(TerminalCounts).Click();
        }

        public void ClickTCRExport()
        {
            driver.FindElement(TCRExport).Click();
        }

        public void SetSearch(string setsearch)
        {
            //Syntax to scroll page to the element
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(Search).SendKeys(setsearch);
        }

        public void ClickGo()
        {
            driver.FindElement(Go).Click();
        }

        public void ClickTCRCExport()
        {
            //Syntax to scroll page to the element
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(TCRCExport).Click();
        }


    }
}
