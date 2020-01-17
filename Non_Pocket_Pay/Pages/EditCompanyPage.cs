// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Non_Pocket_Pay.Pages
{
    class EditCompanyPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public EditCompanyPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By editButton = By.XPath("//a[@href='/Admin/Company/Edit/6115d058-c0f4-e911-b62f-0050568b08ee']");
        By editcompanyBanner = By.XPath("//legend[contains(text(),'Edit a company')]");
        By companyName = By.Id("Name");
        By saveButton = By.XPath("//input[@class='btn btn-primary span3']"); 
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");
        By rowCount = By.XPath("//span[@class='jtable-page-size-change']//select");
        By contactSurcharging = By.Id("ContactlessSurcharingEnabled");
        By popoverSurcharge = By.Id("EnableContaclessSurcharingDivTip");
        By companyType = By.Id("CustomerType");

        By visitCompanyButtontoedit = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By visitcompanyNametoedit = By.XPath("//h2[contains(text(),'QUESTAutoComp01')]");
        By nab = By.XPath("//p[contains(text(),'NAB')]//input[@name='Banks']");
        public void setrowCount(string varrowcount)
        {
            driver.FindElement(rowCount).SendKeys(varrowcount);
        }

        public void clickEdit()
        {
            driver.FindElement(editButton).Click();
        }

        public string geteditcompanyBanner()
        {
            return driver.FindElement(editcompanyBanner).Text;
        }

        public void enterCompanyName(string varsearchcompany)
        {

            driver.FindElement(searchCompany).SendKeys(varsearchcompany);

        }
        public void clickGo()
        {
            driver.FindElement(goButton).Click();
        }

        public void setCompanyName(string newcompanyname)
        {
            driver.FindElement(companyName).SendKeys(newcompanyname);

        }
        public void setCompanyType(string newcompanytype)
        {
            driver.FindElement(companyType).SendKeys(newcompanytype);

        }
        public void clickSave()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(saveButton).Click();
        }

        public void clickVisittoEdit()
        {
            driver.FindElement(visitCompanyButtontoedit).Click();
        }

        public string getcompanyDetailstoview()
        {
            return driver.FindElement(visitcompanyNametoedit).Text;
        }

        public void clickcontactSurcharging()
        {
            driver.FindElement(contactSurcharging).Click();
        }

        public void clickpopoverSurcharging()
        {
            driver.FindElement(popoverSurcharge).Click();
        }

        public void clickNAB()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(nab).Click();
        }
    }
}
