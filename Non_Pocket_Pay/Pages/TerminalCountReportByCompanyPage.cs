using OpenQA.Selenium;
using System.Threading;

namespace Non_Pocket_Pay.Pages
{
    class TerminalCountReportByCompanyPage
    {

        //Create Driver
        IWebDriver driver;

        //Constructor

        public TerminalCountReportByCompanyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By QuestReports = By.XPath("//a[contains(text(),'Quest Reports')]");
        By TerminalCounts = By.XPath("//div[@id='terminalCountReport']");
        By Bank = By.XPath("//select[@id='BankType']");
        By Export = By.XPath("//div[5]//div[1]//div[1]//div[1]//a[1]");
        By Search = By.XPath("//input[@id='search']");
        




        public void ClickQuestReports()
        {
            driver.FindElement(QuestReports).Click();
        }

        public void ClickTerminalCounts()
        {
            driver.FindElement(TerminalCounts).Click();
        }

        public void ClickExport()
        {
            driver.FindElement(Export).Click();
        }


        public void ClickBank()
        {
            Thread.Sleep(5000);
            //IWebElement element = driver.FindElement(Bank);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            //driver.FindElement(Bank).Click();
                
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}
