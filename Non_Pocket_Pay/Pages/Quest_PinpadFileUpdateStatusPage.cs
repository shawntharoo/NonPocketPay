using OpenQA.Selenium;
using System.Threading;

namespace Non_Pocket_Pay.Pages
{
    class Quest_PinpadFileUpdateStatusPage
    {
        //create driver
        IWebDriver driver;

        //constructor

        public Quest_PinpadFileUpdateStatusPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By QuestReports = By.XPath("//a[contains(text(),'Quest Reports')]");
        By PinpadUpdateStatus = By.XPath("//div[@id='firmwareUpdateStatusReport']");
        By SerialNumber = By.XPath("//input[@id='name']");
        By LoadRecords = By.XPath("//button[@id='LoadRecordsButton']");
        By ExportToExcel = By.XPath("/html/body/div[3]/div[3]/div/div[3]/div[2]/span[1]/span[2]");






        public void ClickOnQuestReports()
        {
            driver.FindElement(QuestReports).Click();
        }


        public void ClickOnPinpadUpdateStatus()
        {
            driver.FindElement(PinpadUpdateStatus).Click();
        }

        public void SetSerialNumber(string serialnumber)
        {
            driver.FindElement(SerialNumber).SendKeys(serialnumber);
        }

        public void ClickLoadRecords()
        {
            driver.FindElement(LoadRecords).Click();
        }

        public void ClickExportToExcel()
        {
            //driver.FindElement(ExportToExcel).Click();

            Thread.Sleep(2000);
            IWebElement element = driver.FindElement(ExportToExcel);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}
