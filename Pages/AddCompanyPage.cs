using OpenQA.Selenium;


namespace ConsoleApp.Pages
{
    class AddCompanyPage
    {   //create a driver
        IWebDriver driver;
       
        //constructor
        public AddCompanyPage(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        By loginInput = By.Id("UserName");
        By password = By.Id("Password");
        By loginButton = By.Id("LogOn");
        By addCompanyButton = By.XPath("//a[@class='btn pull-right span3 btn-primary']");
        By companyInfor = By.XPath("//legend[contains(text(),'Company Information')]");
        By companyName = By.Id("Name");
        By customerType = By.Id("CustomerType");
        By userName = By.Id("Username");
        By emailAddress = By.Id("Email");
        By confirmPassword = By.Id("ConfirmPassword");
        By companyType = By.Id("CompanyType");
        By reportingFrequency = By.Id("ReportingFrequency");
        By donationTappoint = By.Id("DonationTapAware");
        By bankSetting = By.Name("Banks");
        By pinpadFiles = By.XPath("//input[@class='default']");
        By createButton = By.Id("company-create");

     
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
        public void clickAddCompany()
        {
            driver.FindElement(addCompanyButton).Click();
        }
        public string getcompanyInfor()
        {

            return driver.FindElement(companyInfor).Text;

        }
        public void setCompanyName(string newcompanyname)
        {
            driver.FindElement(companyName).SendKeys(newcompanyname);

        }
        public void setCustomerType(string newcompanytype)
        {
            driver.FindElement(customerType).SendKeys(newcompanytype);

        }
        public void setadminUserName(string newadminusername)
        {
            driver.FindElement(userName).SendKeys(newadminusername);

        }
        public void setemailAddress(string email)
        {
            driver.FindElement(emailAddress).SendKeys(email);

        }
        public void setconfirmPassword(string varconfirmpassword)
        {
            driver.FindElement(confirmPassword).SendKeys(varconfirmpassword);
        }
        public void setcompanyType(string varcompanytype)
        {
            driver.FindElement(companyType).SendKeys(varcompanytype);
        }

        public void setreportingFrequency(string varreportingfrequency)
        {
            driver.FindElement(reportingFrequency).SendKeys(varreportingfrequency);
        }
        public void clickdonationTappoint()
        {
            driver.FindElement(donationTappoint).Click();
        }
        public void clickbankSetting()
        {
            driver.FindElement(bankSetting).Click();
        }
        
        // please check this
        public void setpinpadFile(string varpinpadfile)
        {
            driver.FindElement(pinpadFiles).SendKeys(varpinpadfile);
        }

        public void clickCreate()
        {
            driver.FindElement(createButton).Click();
        }



    }
}
