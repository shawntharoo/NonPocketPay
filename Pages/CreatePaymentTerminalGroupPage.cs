using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class CreatePaymentTerminalGroupPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public CreatePaymentTerminalGroupPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");

        By companyInfor = By.XPath("//legend[contains(text(),'Company Information')]");
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");

        By visitCompanyButtontoedit = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By visitcompanyNametoedit = By.XPath("//h2[contains(text(),'QUESTAutoComp01')]");

        By PaymentTerminalsDropdown = By.XPath("//a[@class='dropdown-toggle'][contains(text(),'Payment Terminals')]");
        By PaymentterminalGroups = By.XPath("//a[contains(text(),'Payment Terminal Groups')]");
        By paymentterminalText = By.XPath("//h2[contains(text(),'Payment Terminal Groups')]");
        By viewDetailsButton = By.XPath("//tr[2]//td[4]//div[1]//a[1]");

        By addPyamentTerminalGroup = By.XPath("//a[@class='btn btn-primary']");
        By paymentTerminalName = By.Id("Store_Name");
        By ptdeliveryLine = By.Id("Store_PostalAddress_Line1");        
        By ptSuburb = By.Id("Store_PostalAddress_City");
        By ptState = By.XPath("//select[@id='Store_PostalAddress_State']");
        By ptpostalCode = By.Id("Store_PostalAddress_PostCode");
        By ptCountry = By.XPath("//select[@id='Store_PostalAddress_Country']");
        By ptdeliveryAddresscheckbox = By.XPath("//input[@id='Store_DeliverySameAsPostal']");
        By savePaymentTerminal = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        public void setUserName(string username)
        {
            driver.FindElement(loginInput).SendKeys(username);
        }
        public void setPassword(string varpassword)
        {
            driver.FindElement(password).SendKeys(varpassword);
        }

        public void clickLogin()
        {
            driver.FindElement(loginButton).Click();
        }

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
            return driver.FindElement(paymentterminalText).Text;
        }
        public void clickaddPyamentTerminalGroup()
        {
            driver.FindElement(addPyamentTerminalGroup).Click();
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

        public void clickSavePaymentterminals()
        {
            driver.FindElement(savePaymentTerminal).Click();
        }
        public void setdeliveryAddresscheckbox()
        {
            driver.FindElement(ptdeliveryAddresscheckbox).Click();

        }



    }
}
