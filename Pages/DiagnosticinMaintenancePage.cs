using OpenQA.Selenium;

namespace ConsoleApp.Pages
{
    class DiagnosticinMaintenancePage
    {
        //create a driver
        IWebDriver driver;

        //constructor
        public void serilNoinUsed(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");
        By maintenance = By.XPath("//a[contains(text(),'Maintenance')]");
        By welcomeMaintenance = By.XPath("/h2[contains(text(),'Welcome to Maintenance Administration')]");
        By serialNumber = By.XPath(" //input[@id='SerialNumberNoCompany']");
        By viewDetailsButton = By.XPath("//div[@class='form-actions']//input[1]");
        By serialDescription = By.XPath("//h3[contains(text(),'Company Details')]");
        By noPaymentTerminal = By.XPath("//h3[contains(text(),'No payment terminal found with given serial number')]");
        public DiagnosticinMaintenancePage(IWebDriver driver)
        {
            this.driver = driver;
        }
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
        public void clickMaintenance()
        {
            driver.FindElement(maintenance).Click();
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
    }
}
