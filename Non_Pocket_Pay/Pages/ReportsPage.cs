// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class ReportsPage
    {

        //create a driver
        IWebDriver driver;

        //constructor
        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By companyInfor = By.XPath("//legend[contains(text(),'Company Information')]");
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");

        By visitCompanyButtontoedit = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By visitcompanyNametoedit = By.XPath("//h2[contains(text(),'QUESTAutoComp01')]");
        By reporting = By.XPath("//a[@class='left-nav'][contains(text(),'Reporting')]");
        By pinPadHealthStatus = By.XPath("//div[@id='pinpadHealthStatusIcon']");
     
        
        public void enterCompanyName(string varsearchcompany)
        {
            driver.FindElement(searchCompany).SendKeys(varsearchcompany);

        }
        public void clickGo()
        {
            driver.FindElement(goButton).Click();
        }
        public void clickVisittoEdit()
        {
            driver.FindElement(visitCompanyButtontoedit).Click();
        }
        public void clickReport()
        {
            driver.FindElement(reporting).Click();
        }

        public void clickPINPadReport()
        {
            driver.FindElement(pinPadHealthStatus).Click();
        }
    }


}
