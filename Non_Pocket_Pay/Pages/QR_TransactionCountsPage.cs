using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Non_Pocket_Pay.Pages
{
    class QR_TransactionCountsPage
    {
        //Create Driver
        IWebDriver driver;

        //create constructor
        public QR_TransactionCountsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By QuestReports = By.XPath("//a[contains(text(),'Quest Reports')]");
        By TransactionCounts = By.Id("transactionCountReport");
        By DateFrom = By.Id("from");
        By DateTo = By.Id("to");
        By Update = By.Id("reportsUpdateButton");
        By Export = By.XPath("//a[@class='btn btn-small btn-success']");

        By CompDropDown = By.XPath("//div[@id='CompanyID_chosen']//a[@class='chosen-single chosen-default']//div//b");
        By Company = By.XPath("/html/body/div[3]/section/div[1]/form/div/div[2]/div[1]/div/div/ul/li[1]");
        By ApprovedAndDeclinedExport = By.XPath("//body/div[@id='main']/section[@id='TransactionCountReport']/div[@class='row']/div[@class='span12']/div[@id='TxCountOverview']/div[@class='well']/div/div/a[1]");

        By ErroneousTransactionCountExport = By.XPath("//div[@id='ErrorneousTxCountList']//a[1]");



        public void ClickQuestReports()
        {
            driver.FindElement(QuestReports).Click();
        }

        public void ClickTransactionCounts()
        {
            driver.FindElement(TransactionCounts).Click();
        }

        public void SetDateFrom(string datefrom)
        {
            driver.FindElement(DateFrom).Clear();
            driver.FindElement(DateFrom).SendKeys(datefrom);
        }

        public void SetDateTo(string dateto)
        {
            driver.FindElement(DateTo).Clear();
            driver.FindElement(DateTo).SendKeys(dateto);
        }

        public void ClickUpdate()
        {
            driver.FindElement(Update).Click();
        }

        public void ClickExport()
        {
            driver.FindElement(Export).Click();
        }

       public void ClickCompDropDown()
        {
            driver.FindElement(CompDropDown).Click();
        }

        public void ClickCompany()
        {
            driver.FindElement(Company).Click();
        }

        public void ClickApprovedAndDeclinedExport()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,450)");
            driver.FindElement(ApprovedAndDeclinedExport).Click();
        }

        public void ClickErroneousTransactionCountExport()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,550)");
            driver.FindElement(ErroneousTransactionCountExport).Click();
        }
    }
}
