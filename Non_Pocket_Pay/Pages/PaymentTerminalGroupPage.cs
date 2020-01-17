// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01


using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class PaymentTerminalGroupPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public PaymentTerminalGroupPage(IWebDriver driver)
        {
            this.driver = driver;
        }
                      
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");
        By visitCompanyButtontoedit = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By visitcompanyNametoedit = By.XPath("//h2[contains(text(),'QUESTAutoComp01')]");
        By PaymentTerminalsDropdown = By.XPath("//a[@class='dropdown-toggle'][contains(text(),'Payment Terminals')]");
        By PaymentterminalGroups = By.XPath("//a[contains(text(),'Payment Terminal Groups')]");
        By paymentterminalGroupsText = By.XPath("//h2[contains(text(),'Payment Terminal Groups')]");
        By addPyamentTerminalGroup = By.XPath("//a[@class='btn btn-primary']");
        By paymentTerminalName = By.Id("Store_Name");
        By ptdeliveryLine = By.Id("Store_PostalAddress_Line1");        
        By ptSuburb = By.Id("Store_PostalAddress_City");
        By ptState = By.XPath("//select[@id='Store_PostalAddress_State']");
        By ptpostalCode = By.Id("Store_PostalAddress_PostCode");
        By ptCountry = By.XPath("//select[@id='Store_PostalAddress_Country']");
        By ptdeliveryAddresscheckbox = By.XPath("//input[@id='Store_DeliverySameAsPostal']");
        By savePaymentTerminal = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By createPTGtext = By.XPath("//h2[contains(text(),'Create Payment Terminal Group')]");
        By searchPTgroup = By.Id("search");
        By clickGoPT = By.XPath("//button[@class='btn']");
        By deletePTbutton = By.XPath("//a[@class='btn btn-small btn-danger']");
        By deleteConfbutton = By.XPath("//input[@class='btn btn-danger span2 btn-footeraction']");
        
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
        public string getcompanyDetailstoview()
        {
            return driver.FindElement(visitcompanyNametoedit).Text;
        }

        public void clickPaymentTerminalsDropdown()
        {
            driver.FindElement(PaymentTerminalsDropdown).Click();
        }

        public void clickPaymentTerminalGroups()
        {
            driver.FindElement(PaymentterminalGroups).Click();
        }

        public string getPaymentTerminalGroupText()
        {
            return driver.FindElement(paymentterminalGroupsText).Text;
        }

        // create PTG
        public void clickaddPyamentTerminalGroup()
        {
            driver.FindElement(addPyamentTerminalGroup).Click();
        }

        public string getcreatePTGtext()
        {
            return driver.FindElement(createPTGtext).Text;
        }

        public void setPaymentTerminalName(string newpaymentterminalname)
        {
            driver.FindElement(paymentTerminalName).SendKeys(newpaymentterminalname);

        }

        public void setdeliveryLine(string ptdeliveryline)
        {
            driver.FindElement(ptdeliveryLine).SendKeys(ptdeliveryline);

        }
        public void setSuburb(string ptsuburb)
        {
            driver.FindElement(ptSuburb).SendKeys(ptsuburb);

        }
        public void setState(string ptstate)
        {
            driver.FindElement(ptState).SendKeys(ptstate);

        }
        public void setpostalCode(string ptpostalcode)
        {
            driver.FindElement(ptpostalCode).SendKeys(ptpostalcode);

        }

        public void setCountry(string ptcountry)
        {
            driver.FindElement(ptCountry).SendKeys(ptcountry);

        }

        public void setdeliveryAddresscheckbox()
        {
            driver.FindElement(ptdeliveryAddresscheckbox).Click();

        }

        public void clickSavePaymentterminals()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,650)");
            driver.FindElement(savePaymentTerminal).Click();
        }


        //  delete PTG   
        
        public void enterPTgroup(string varsearchptgroup)
        {
            driver.FindElement(searchPTgroup).SendKeys(varsearchptgroup);

        }
        public void searchPT()
        {
            driver.FindElement(clickGoPT).Click();
        }

        public void deletePT()
        {
            driver.FindElement(deletePTbutton).Click();
        }

        public void deleteConfirmationPT()
        {
            driver.FindElement(deleteConfbutton).Click();
        }

        //public string getpaymentTerminalText()
        //{
        //    return driver.FindElement(paymentterminalText).Text;
        //}
    }
}
