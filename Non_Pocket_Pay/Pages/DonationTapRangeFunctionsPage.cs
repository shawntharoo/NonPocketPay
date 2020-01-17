using OpenQA.Selenium;


namespace Non_Pocket_Pay
{
    class DonationTapRangeFunctionsPage
    {
        //create driver
        IWebDriver driver;

        //constructor

        public DonationTapRangeFunctionsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By Maintenance = By.XPath("//a[contains(text(),'Maintenance')]");
        By DonationTapRange = By.XPath("//a[contains(text(),'Donation Tap Range')]");
        By AddNewDPTrange = By.XPath("//span[@class='jtable-toolbar-item-text'][contains(text(),'Add new DPT range')]");
        By FromRange = By.Id("Edit-From");
        By ToRange = By.Id("Edit-To");
        By AddSave = By.XPath("//div[10]//button[2]//span[1]");

        By ClearFromRange = By.Id("Edit-From");
        By ClearToRange = By.Id("Edit-To");
        By EditDPTRange = By.XPath("//tr[1]//td[3]//button[1]");
        By EditSave = By.XPath("//div[11]//button[2]//span[1]");

        By Delete = By.XPath("//div[@id='donationTapRange']//tr[1]//td[4]//button[1]");
        //By ConfirmDelete = By.XPath("//div[9]//button[2]//span[1]");




        public void ClickMaintenance()
        {
            driver.FindElement(Maintenance).Click();
        }

        public void ClickDonationTapRange()
        {
            driver.FindElement(DonationTapRange).Click();
        }

        public void ClickAddNewDPTrange()
        {
            driver.FindElement(AddNewDPTrange).Click();
        }

        public void SetFromRange(string addfrom)
        {
            driver.FindElement(FromRange).SendKeys(addfrom);
        }

        public void SetToRange(string addto)
        {
            driver.FindElement(ToRange).SendKeys(addto);
        }

        public void ClickAddSave()
        {
            driver.FindElement(AddSave).Click();
        }

        public void ClearDataFromRange()
        {
            driver.FindElement(ClearFromRange).Clear();
        }

        public void ClearDataToRange()
        {
            driver.FindElement(ClearToRange).Clear();
        }

        public void ClickEditDPTRange()
        {
            driver.FindElement(EditDPTRange).Click();
        }

        public void ClickEditSave()
        {
            driver.FindElement(EditSave).Click();
        }

        public void ClickDelete()
        {
            driver.FindElement(Delete).Click();
        }

        //public void ClickConfirmDelete()
        //{
        //    driver.FindElement(ConfirmDelete).Click();
        //}


    }
}
