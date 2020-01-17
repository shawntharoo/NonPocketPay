using OpenQA.Selenium;
using System.Threading;

namespace Non_Pocket_Pay.Pages
{
    class UserFunctionsPage
    {
        //create a driver
        IWebDriver driver;


        //Constructor
        public UserFunctionsPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        By SearchByCompany = By.XPath("//input[@id='name']");
        By ClickGoBtn = By.Id("LoadRecordsButton");
        By ClickVisitBtn = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By ClickOnUsers = By.XPath("//a[contains(text(),'Users')]");
        By ClickOnAddUser = By.XPath("//a[@class='btn btn-primary']");
        By UserName = By.Id("Username");
        By Email = By.Id("Email");
        By Password = By.Id("Password");
        By ConfirmPassword = By.Id("Confirm");
        By Roles = By.XPath("//span[contains(text(),'Select an Option')]");
        By SetOption = By.XPath("//div[@class='chosen-search']//Input");
        By Option = By.XPath("//*[@id='main']/form/fieldset[4]/div[2]/div/div/div/ul/li[1]");
        By Save = By.XPath("//input[@id='btnSubmit']");

        By Search = By.XPath("//input[@id='search']");
        By SearchGo = By.XPath("//button[@class='btn']");
        By EditDetails = By.XPath("//a[@class='btn btn-small']");
        By Comment = By.XPath(" //textarea[@id='Comment']");

        By ClickOnDelete = By.XPath("//tr[1]//td[7]//div[1]//a[2]");
        By Delete = By.XPath("//input[@class='btn btn-danger span2 btn-footeraction']");
        
        public void SetSearchByCompany(string searchcompany)
        {
            driver.FindElement(SearchByCompany).SendKeys(searchcompany);
        }

        public void ClickGoButton()
        {
            driver.FindElement(ClickGoBtn).Click();
        }

        public void ClickVisitButton()
        {
            Thread.Sleep(2000);
            driver.FindElement(ClickVisitBtn).Click();
        }

        public void ClickOnUserButton()
        {
            driver.FindElement(ClickOnUsers).Click();
        }

        public void ClickOnAddUserButton()
        {
            driver.FindElement(ClickOnAddUser).Click();
        }


        public void SetUserName(string username)
        {
            driver.FindElement(UserName).SendKeys(username);
        }


        public void SetEmail(string email)
        {
            driver.FindElement(Email).SendKeys(email);
        }

        public void SetPassword(string password)
        {
            driver.FindElement(Password).SendKeys(password);
        }


        public void SetConfirmPassword(string confirmPassword)
        {
            driver.FindElement(ConfirmPassword).SendKeys(confirmPassword);
        }
               
        public void ClickRoles()
        {

            Thread.Sleep(2000);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,450)");


            driver.FindElement(Roles).Click();
        }

        public void ClickSetOption(string setrole)
        {
            driver.FindElement(SetOption).SendKeys(setrole);
        }

        public void ClickOption()
        {
            driver.FindElement(Option).Click();
        }

        public void ClickSave()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,450)");
            driver.FindElement(Save).Click();
        }

        public void SetSearch(string search)
        {
            driver.FindElement(Search).SendKeys(search);
        }


        public void ClickSearchGo()
        {
            driver.FindElement(SearchGo).Click();
        }

        public void ClickEditDetails()
        {
            driver.FindElement(EditDetails).Click();
        }

        public void SetComment(string comment)
        {
            driver.FindElement(Comment).SendKeys(comment);
        }

        public void ClickOnDeteteButton()
        {
            driver.FindElement(ClickOnDelete).Click();
        }

        public void ClickDelete()
        {
            driver.FindElement(Delete).Click();
        }

    }
}
