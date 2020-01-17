using OpenQA.Selenium;
using System.Threading;

namespace Non_Pocket_Pay.Pages
{
    class MAdminUserPage
    {
        //create driver
        IWebDriver driver;

        //construcctor
        public MAdminUserPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By Maintenance = By.XPath("//a[contains(text(),'Maintenance')]");
        By UserManagement = By.XPath("//a[contains(text(),'User Management')]");
        By CreateAdminUser = By.XPath("//span[@class='jtable-toolbar-item-text'][contains(text(),'Create Admin User')]");
        By FirstName = By.Id("Edit-FirstName");
        By LastName = By.Id("Edit-LastName");
        By Email = By.Id("Edit-Email");
        By Phone = By.Id("Edit-PhoneNumber");
        By UserName = By.Id("Edit-UserName");
        By Password = By.Id("Edit-Password");
        By Role = By.XPath("//option[contains(text(),'Manager')]");
        By Save = By.XPath("//div[6]//button[2]//span[1]");

        // Edit Admin User

        By Search = By.Id("name");
        By LoadRecords = By.Id("LoadRecordsButton");
        By EditRecord = By.XPath("//div[@id='ManageUserAccountsTableContainer']//tr[@class='jtable-data-row']//button[@class='jtable-command-button jtable-edit-command-button']");
        By EditFirstName = By.Id("Edit-FirstName");
        By EditSave = By.XPath("//div[7]//button[2]//span[1]");

        // Delete Admin User 
        By Delete = By.XPath("//div[@id='ManageUserAccountsTableContainer']//button[@class='jtable-command-button jtable-delete-command-button']");
        By RemoveUser = By.XPath("//span[@class='ui-button-text'][contains(text(),'Remove User')]");

        public void ClickMaintenance()
        {
            driver.FindElement(Maintenance).Click();
        }

        public void ClickUserManagement()
        {
            driver.FindElement(UserManagement).Click();
        }

        public void ClickCreateAdminUser()
        {
            driver.FindElement(CreateAdminUser).Click();
        }

        public void SetFirstName(string firstname)
        {
            driver.FindElement(FirstName).SendKeys(firstname);
        }


        public void SetLastName(string lastname)
        {
            driver.FindElement(LastName).SendKeys(lastname);
        }

        public void SetEmail(string email)
        {
            driver.FindElement(Email).SendKeys(email);
        }

        public void SetPhone(string phone)
        {
            driver.FindElement(Phone).SendKeys(phone);
        }

        public void SetUserName(string username)
        {
            driver.FindElement(UserName).SendKeys(username);
        }


        public void SetPassword(string password)
        {
            driver.FindElement(Password).SendKeys(password);
        }

        public void SetRole()
        {
            driver.FindElement(Role).Click();
        }

        public void ClickSave()
        {
            driver.FindElement(Save).Click();
        }

        // Edit Admin User
        public void SetSearch(string search)
        {
            driver.FindElement(Search).SendKeys(search);
        }

        public void ClickLoadRecords()
        {
            driver.FindElement(LoadRecords).Click();
        }

        public void ClickEditRecord()
        {
            Thread.Sleep(2000);
            driver.FindElement(EditRecord).Click();
        }

        public void SetEditFirstName(string seteditfirstname)
        {
            driver.FindElement(EditFirstName).SendKeys(seteditfirstname);
        }

        public void ClickSaveEdit()
        {
            driver.FindElement(EditSave).Click();
        }

        // Delete Admin User
        
        public void ClickDelete()
        {
            driver.FindElement(Delete).Click();
        }

        public void ClickRemoveUser()
        {
            driver.FindElement(RemoveUser).Click();
        }
    }
}
