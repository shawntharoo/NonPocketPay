// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;


namespace Non_Pocket_Pay.Pages
{
    class LoginPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");

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
    }
}
