using OpenQA.Selenium;


namespace Non_Pocket_Pay.Pages
{
    class DevicesPage
    {
        //create a driver
        IWebDriver driver;

        //constructor

        public DevicesPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By SearchByCompany = By.XPath("//input[@id='name']");
        By ClickGoBtn = By.Id("LoadRecordsButton");
        By ClickVisitBtn = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By Devices = By.XPath("//a[contains(text(),'Devices')]");
        By NewDevice = By.XPath("//a[@class='btn btn-primary']");
        By Name = By.Id("Name");
        By Save = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");

        // Block Devices

        By Search = By.Id("search");
        By Go = By.XPath("//button[@class='btn']");
        By Block = By.XPath("//a[@class='btn btn-small btn-danger']");
        By CnfmBlock = By.Id("btnSubmit");
        By Yes = By.XPath("//input[@class='btn btn-danger span2 btn-footeraction']");

        // Unblock Devices
        By Unblock = By.XPath("//div[@class='btn-group']//a[1]");

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

        public void ClickDevices()
        {
            driver.FindElement(Devices).Click();
        }

        public void ClickNewDevice()
        {
            driver.FindElement(NewDevice).Click();
        }

        public void SetName(string name)
        {
            driver.FindElement(Name).SendKeys(name);
        }

        public void ClickSave()
        {
            driver.FindElement(Save).Click();
        }

        // Block Devices

        public void SetSearch(string search)
        {
            driver.FindElement(Search).SendKeys(search);
        }

        public void ClickGo()
        {
            driver.FindElement(Go).Click();
        }

        public void ClickBlock()
        {
            driver.FindElement(Block).Click();
        }

        public void ClickCnfmBlock()
        {
            driver.FindElement(CnfmBlock).Click();
        }

        public void ClickYes()
        {
            driver.FindElement(Yes).Click();
        }

        // Unblock Devices
        public void ClickUnblock()
        {
            driver.FindElement(Unblock).Click();
        }

        public void CloseDriver()
        {
            driver.Close();
        }

    }
}

