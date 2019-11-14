using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class ViewPaymentTerminalGroupPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public ViewPaymentTerminalGroupPage(IWebDriver driver)
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

    }
}
