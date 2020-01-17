using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class UserLoginFunctionsPage
    {

        //create  driver
        IWebDriver driver;

        //constructor

        public UserLoginFunctionsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By UserName = By.Id("UserName");
        By Password = By.Id("Password");
        By RememberMe = By.Id("RememberMe");
        By SignIn = By.Id("LogOn");
        By ResetPassword = By.XPath("//a[@class='reset-password']");
        By ResetEmail = By.Id("Email");
        By ResetSendRequest = By.Id("sendRequest");
        By Cancel = By.XPath("//a[@class='btn']");
        By IncorrectUserOrPassword = By.XPath("//li[contains(text(),'The user name and/or password is incorrect.')]");

        
        public void SetUserName(string username)
        {
            driver.FindElement(UserName).SendKeys(username);
        }

        public void SetPassword(string password)
        {
            driver.FindElement(Password).SendKeys(password);
        }


        public void CheckRememberMe()
        {
            driver.FindElement(RememberMe).Click();
        }

        public void ClickSignIn()
        {
            driver.FindElement(SignIn).Click();
        }

        public void ClickResetPassword()
        {
            driver.FindElement(ResetPassword).Click();
        }

        public void SetResetEmail(string resetemail)
        {
            driver.FindElement(ResetEmail).SendKeys(resetemail);
        }

        public void ClickResetSendRequest()
        {
            driver.FindElement(ResetSendRequest).Click();
        }

        public void MessageIncorrectUserOrPassword()
        {
            driver.FindElement(IncorrectUserOrPassword);
        }

        public void ClickCancel()
        {
            driver.FindElement(Cancel).Click();
        }

       public string WarningText()
        {
            return driver.FindElement(IncorrectUserOrPassword).Text;
        }
    }
}
