// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class MaintenancePage
    {
        //create a driver
        IWebDriver driver;

        //constructor
        public void serilNoinUsed(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        By maintenance = By.XPath("//a[contains(text(),'Maintenance')]");
        By welcomeMaintenance = By.XPath("/h2[contains(text(),'Welcome to Maintenance Administration')]");
        By serialNumber = By.XPath("//input[@id='SerialNumberNoCompany']");
        By viewDetailsButton = By.XPath("//div[@class='form-actions']//input[1]");
        By serialDescription = By.XPath("//h3[contains(text(),'Company Details')]");
        By noPaymentTerminal = By.XPath("//h2[contains(text(),'Description')]");
        By simmanagement = By.XPath("//a[contains(text(),'Sim Management')]");
        By admCompanysim = By.XPath("//form[@id='frmSimImport']//span[contains(text(),'Select a Company')]");
        By admEnterCompanysim = By.XPath("//div[@class='chosen-container chosen-container-single chosenImage-container chosen-with-drop chosen-container-active']//input");
        By seladmCompanysim = By.ClassName("active-result");
        By enterSimNo = By.Id("SimNumber");
        By addSimNo = By.XPath("//div[@id='simImport']//div[1]//p[1]//input[1]");
        By deleteSimNo = By.XPath("//div[@id='simImport']//p[2]//input[1]");
        By sucessfullyaddedText = By.XPath("//div[@class='alert alert-success']");
        By sucessfullydeletedText = By.XPath("//div[@class='alert alert-success']");
        By uploadbutton = By.XPath("//input[@name='simfile']");
        By disassociatePT = By.XPath("//p[contains(text(),'Leave a payment terminal in the company pool but n')]//input[@name='submitButton']");
        By administration = By.XPath("//a[contains(text(),'Administration')]");
        By deviceType = By.Id("CT400Devicetype");

        By admCompany = By.XPath("//div[@id='companyIdGuid_chosen']//span[contains(text(),'Select a Company')]");
        By seladmCompany = By.ClassName("active-result");
        By admEnterCompany = By.XPath("//div[@id='companyIdGuid_chosen']//input");
        By admSerialNo = By.Id("SerialNumber");
        By addPTs = By.Name("submitButton");
        By deletePTs = By.XPath("//p[contains(text(),'Disassociate the payment terminal from a lane and')]//input[@name='submitButton']");
        public MaintenancePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickMaintenance()
        {
            driver.FindElement(maintenance).Click();
        }

        public void clickAdministration()
        {
            driver.FindElement(administration).Click();
        }
        public void setSerialNumber(string varserialnumber)
        {
            driver.FindElement(serialNumber).SendKeys(varserialnumber);
        }
        public void clickViewDetails()
        {
            driver.FindElement(viewDetailsButton).Click();
        }
        public string getserialDescription()
        {
            return driver.FindElement(serialDescription).Text;
        }
        public string getnoPaymentTerminal()
        {
            return driver.FindElement(noPaymentTerminal).Text;
        }               
        
        public void clickSimManagement()
        {
            driver.FindElement(simmanagement).Click();
        }
        public void clickadmCompanyDropdown()
        {
            driver.FindElement(admCompany).Click();
        }

        public void clickadmCompanyDropdowninsim()
        {
            driver.FindElement(admCompanysim).Click();
        }


        public void setAdmCompany(string varadmentercompany)
        {
            driver.FindElement(admEnterCompany).SendKeys(varadmentercompany);
        }

        public void setAdmCompanysim(string varadmentercompany)
        {
            driver.FindElement(admEnterCompanysim).SendKeys(varadmentercompany);
        }

        public void selAdminCompany()
        {
            driver.FindElement(seladmCompany).Click();
        }
        public void selAdminCompanysim()
        {
            driver.FindElement(seladmCompanysim).Click();
        }
        public void setAdmSerialNo(string varadmserialno)
        {
            driver.FindElement(admSerialNo).SendKeys(varadmserialno);
        }

        public void setAdmSimNo(string varadmsimno)
        {
            driver.FindElement(enterSimNo).SendKeys(varadmsimno);
        }
        public void clickaddSimNo()
        {
            driver.FindElement(addSimNo).Click();
        }

        public void clickdeleteSimNo()
        {
            driver.FindElement(deleteSimNo).Click();
        }


        public string getSucessfullyaddedText()
        {

            return driver.FindElement(sucessfullyaddedText).Text;

        }

        public string getSucessfullydeletedText()
        {

            return driver.FindElement(sucessfullydeletedText).Text;

        }

        public void uploadfile(string varuploadfile)
        {
            driver.FindElement(uploadbutton).SendKeys(varuploadfile);
        }

        public void clickdisassociatePT()
        {
            driver.FindElement(disassociatePT).Click();
        }

        public void clickdeviceType()
        {
            driver.FindElement(deviceType).Click();
        }

        public void clickaddPT()
        {
            driver.FindElement(addPTs).Click();
        }

        public void clickdeletePT()
        {
            driver.FindElement(deletePTs).Click();
        }

    }
}
