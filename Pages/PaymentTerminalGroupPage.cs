using OpenQA.Selenium;

namespace ConsoleApp.Pages
{
    class PaymentTerminalGroupPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public PaymentTerminalGroupPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");
        By companyInfor = By.XPath("//legend[contains(text(),'Company Information')]");
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");
        By visitCompanyButton = By.XPath("//tr[1]//td[4]//a[2]");
        By visitcompanyName = By.XPath("//h2[contains(text(),'Sams QA')]");
        By PaymentTerminalGroup = By.XPath("//a[contains(text(),'Payment Terminal Groups')]");
        By newpaymentterminalGroupButton = By.XPath("//a[@href=/Store");
        By storeName = By.Id("Store_Name");
        By postalLine1 = By.Id(" //input[@id='Store_PostalAddress_Line1']");
        By postalSuburb = By.Id("Store_PostalAddress_City");
        By postalZipCode = By.Id("Store_PostalAddress_PostCode");
        By postalCountry = By.Id("Store_PostalAddress_Country");
        By paymentterminalText = By.XPath(" //h2[contains(text(),'Payment Terminal Groups')]");
        By viewDetailsButton = By.XPath("//tr[2]//td[4]//div[1]//a[1]");
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
        public string getcompanyName()
        {
            return driver.FindElement(visitcompanyName).Text;

        }
        public void enterCompanyName(string varsearchcompany)
        {
            driver.FindElement(searchCompany).SendKeys(varsearchcompany);

        }
        public void clickGo()
        {
            driver.FindElement(goButton).Click();
        }
        public void clickVisit()
        {
            driver.FindElement(visitCompanyButton).Click();
        }
        public void clickPaymentTerminalGroup()
        {
            driver.FindElement(PaymentTerminalGroup).Click();
        }
        
        //click Payment Terminal Group
        public void clicknewpaymentterminalGroupButton()
        {
            driver.FindElement(newpaymentterminalGroupButton).Click();
        }

        // enter Payment Terminal Group details
        public void setpostalStoreName(string varstorename)
        {
            driver.FindElement(storeName).SendKeys(varstorename);

        }
        public void setpostalLine1(string varpostalline1)
        {
            driver.FindElement(postalLine1).SendKeys(varpostalline1);

        }
        public void setpostalSuburb(string varpostalsuburb)
        {
            driver.FindElement(postalSuburb).SendKeys(varpostalsuburb);

        }
        public void setpostalZipCode(string varpostalzipcode)
        {
            driver.FindElement(postalZipCode).SendKeys(varpostalzipcode);

        }
        public void setpostalCountry(string varpostalCountry)
        {
            driver.FindElement(postalCountry).SendKeys(varpostalCountry);

        }
        public string getpaymentterminalText()
        {
            return driver.FindElement(paymentterminalText).Text;

        }
        public void clickViewdetails()
        {
            driver.FindElement(viewDetailsButton).Click();
        }


    }
}
