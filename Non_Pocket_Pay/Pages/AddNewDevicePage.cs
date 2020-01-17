using OpenQA.Selenium;


namespace Non_Pocket_Pay.Pages
{
    class AddNewDevicePage
    {
        //create a driver
        IWebDriver driver;

        //constructor

        public AddNewDevicePage(IWebDriver driver)
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
    }
}

