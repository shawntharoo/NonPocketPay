using OpenQA.Selenium;


namespace Non_Pocket_Pay.Pages
{
    class UnblockDevicePage
    {
        //create a driver
        IWebDriver driver;

        //constructor
        public UnblockDevicePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By SearchByCompany = By.XPath("//input[@id='name']");
        By ClickGoBtn = By.Id("LoadRecordsButton");
        By ClickVisitBtn = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By Devices = By.XPath("//a[contains(text(),'Devices')]");
        By Search = By.Id("search");
        By Go = By.XPath("//button[@class='btn']");
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

        public void SetSearch(string search)
        {
            driver.FindElement(Search).SendKeys(search);
        }

        public void ClickGo()
        {
            driver.FindElement(Go).Click();
        }


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
