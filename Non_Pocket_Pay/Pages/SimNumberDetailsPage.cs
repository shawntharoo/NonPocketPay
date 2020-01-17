using OpenQA.Selenium;
using System.Threading;

namespace Non_Pocket_Pay.Pages
{
    class SimNumberDetailsPage
    {
        //create driver
        IWebDriver driver;

        //constructor

        public SimNumberDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By SearchByCompany = By.XPath("//input[@id='name']");
        By ClickGoBtn = By.Id("LoadRecordsButton");
        By ClickVisitBtn = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By ManageSimNumbers = By.XPath("//a[contains(text(),'Manage Sim Numbers')]");
        By AddSimNumbers = By.XPath("//span[@class='jtable-toolbar-item-icon']");
        By SimNumber = By.XPath("//input[@id='Edit-SimNumber']");
        By Save = By.XPath("//button[@id='AddRecordDialogSaveButton']//span[@class='ui-button-text'][contains(text(),'Save')]");

        // Edit Sim Number
        By EditSim = By.XPath("//tr[1]//td[2]//button[1]");
        By ClearSim = By.Id("Edit-SimNumber");
        By Newsim = By.Id("Edit-SimNumber");
        By editSave = By.XPath("//button[@id='EditDialogSaveButton']//span[@class='ui-button-text'][contains(text(),'Save')]");

        // Delete Sim Number 
        By Delete = By.XPath("//tr[@class='jtable-data-row']//button[@class='jtable-command-button jtable-delete-command-button']");
        By ConfirmDelete = By.XPath("//span[@class='ui-button-text'][contains(text(),'Delete')]");

        
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
            driver.FindElement(ClickVisitBtn).Click();
        }

        public void ClickManageSimNumbers()
        {
            driver.FindElement(ManageSimNumbers).Click();
        }

        public void ClickAddSimNumbers()
        {
            driver.FindElement(AddSimNumbers).Click();
        }

        public void SetSimNumber(string setsimnumber)
        {
            driver.FindElement(SimNumber).SendKeys(setsimnumber);
        }

        public void ClickSave()
        {
            driver.FindElement(Save).Click();
        }

        // Edit Sim Number

        public void ClickEditSim()
        {
            driver.FindElement(EditSim).Click();
        }

        public void DataClear()
        {
            driver.FindElement(ClearSim).Clear();
        }

        public void SetNewData(string newsim)
        {
            driver.FindElement(Newsim).SendKeys(newsim);
        }

        public void ClickEditSave()
        {
            driver.FindElement(editSave).Click();
        }
        // Delete Sim Number 
        public void ClickDelete()
        {
            driver.FindElement(Delete).Click();
        }

        public void ClickConfirmDelete()
        {
            driver.FindElement(ConfirmDelete).Click();
        }

    }
}
