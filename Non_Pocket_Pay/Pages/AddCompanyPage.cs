// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;
using System.Threading;

namespace Non_Pocket_Pay.Pages
{
    class AddCompanyPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public AddCompanyPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        //public void SetupBrowser(string browserName)
        //{
        //    if (browserName.Equals("ie"))
        //        driver = new InternetExplorerDriver();
        //    else if (browserName.Equals("chrome"))
        //        driver = new ChromeDriver();
        //    else
        //        driver = new FirefoxDriver();
        //}

        By password = By.Id("Password");
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
        By companyTab = By.XPath("//a[contains(text(),'Companies')]");
        By selpinpad = By.ClassName("chosen-results");
        By visitdealerComp = By.XPath("//a[@href='/Admin/Company/Visit/5e17bae2-991c-ea11-a5a7-0050568b08ee']");
        By billingLine1 = By.Id("BillingAddress_Line1");
        By billingSuburb = By.Id("BillingAddress_City");
        By billingState = By.Id("BillingAddress_State");
        By billingpostcode = By.Id("BillingAddress_PostCode");
        By billingCountry = By.XPath("//select[@id='BillingAddress_Country']");
        By billingdelAddresscheckbox = By.Id("DeliverySameAsPostal");
        By clickvisitdealer = By.XPath("//a[@href='/Admin/Company/Visit/5e17bae2-991c-ea11-a5a7-0050568b08ee']");

        //Kiosk Fields
        By DonationKioskAware = By.Id("DonationKioskAware");
        public void setPassword(string varpassword)
        {
            driver.FindElement(password).SendKeys(varpassword);
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

        public void clickpinpad()
        {
            driver.FindElement(selpinpad).Click();
        }
        public void clickCreate()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(createButton).Click();
        }

        //public void clickEdit()
        //{
        //    driver.FindElement(createButton).Click();
        //}

        //public void clickEdit1()
        //{
        //    driver.FindElement(editbutton1).Click();
        //}
        public void clickcompanyTab()
        {
            driver.FindElement(companyTab).Click();
        }

        // visit Dealer Company
        public void clickvisitbutton()
        {
            driver.FindElement(visitdealerComp).Click();
            
        }

        public void clickvisitdealerbutton()
        {
            driver.FindElement(clickvisitdealer).Click();

        }

        // billing details 

        public void SetbillingLine(string varbillingline1)
        {
            driver.FindElement(billingLine1).SendKeys(varbillingline1);
        }
        public void SetbillingSuburb(string varbillingsuburb)
        {
            driver.FindElement(billingSuburb).SendKeys(varbillingsuburb);
        }

        public void SetbillingState(string varbillingstate)
        {
            driver.FindElement(billingState).SendKeys(varbillingstate);
        }

        public void SetbillingPostcode(string varbillingpostcode)
        {
            driver.FindElement(billingpostcode).SendKeys(varbillingpostcode);
        }

        public void setbillingCountry(string billingcountry)
        {
            driver.FindElement(billingCountry).SendKeys(billingcountry);

        }

        public void setdeliveryAddresscheckbox()
        {
            driver.FindElement(billingdelAddresscheckbox).Click();

        }



        //public static IEnumerable<string> BrowserToRunWith()
        //{
        //    string[] browser = { "chrome", "firefox", "ie" };

        //    foreach(string b in browser)
        //    {
        //        yield return b;

        //    }
        //}

        //Kiosk Company Method
        public void CheckDonationKioskAware()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(DonationKioskAware).Click();
        }



    }
}
