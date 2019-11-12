using OpenQA.Selenium;

namespace ConsoleApp.Pages
{
    class VisitCompanyPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public VisitCompanyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");
        By visitCompanyButton = By.XPath("//a[@href='/Admin/Company/Visit/6115d058-c0f4-e911-b62f-0050568b08ee']");
        By visitcompanyName = By.XPath("//h2[contains(text(),'QUESTComp0')]");
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");
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
        public void clickVisit()
        {
            driver.FindElement(visitCompanyButton).Click();
        }
        public string getcompanyDetails()
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

    }
}
