using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class EditCompanyPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public EditCompanyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");
        By editButton = By.XPath("//a[@href='/Admin/Company/Edit/6115d058-c0f4-e911-b62f-0050568b08ee']");
        By editcompanyBanner = By.XPath("//legend[contains(text(),'Edit a company')]");
        By companyName = By.Id("Name");
        By saveButton = By.XPath("//input[@class='btn btn-primary span3']");
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");
        By noCompany = By.XPath("//td[contains(text(),'No data available!')]");
        By rowCount = By.XPath("//span[@class='jtable-page-size-change']//select");
        By contactSurcharging = By.Id("ContactlessSurcharingEnabled");
        By companyType = By.Id("CustomerType");

        public void setrowCount(string varrowcount)
        {
            driver.FindElement(rowCount).SendKeys(varrowcount);
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

        public void clickEdit()
        {
            driver.FindElement(editButton).Click();
        }

        public string geteditcompanyBanner()
        {
            return driver.FindElement(editcompanyBanner).Text;
        }

        public void enterCompanyName(string varsearchcompany)
        {

            driver.FindElement(searchCompany).SendKeys(varsearchcompany);

        }
        public void clickGo()
        {
            driver.FindElement(goButton).Click();
        }

        public void setCompanyName(string newcompanyname)
        {
            driver.FindElement(companyName).SendKeys(newcompanyname);

        }
        public void setCompanyType(string newcompanytype)
        {
            driver.FindElement(companyType).SendKeys(newcompanytype);

        }
        public void clickSave()
        {
            driver.FindElement(saveButton).Click();
        }




    }
}
