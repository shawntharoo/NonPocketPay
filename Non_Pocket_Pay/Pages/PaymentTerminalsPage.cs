// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 25/10/2019
// Updated Date - 26/11/2019
// Version - 0.0.01

using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class PaymentTerminalsPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public PaymentTerminalsPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By companyInfor = By.XPath("//legend[contains(text(),'Company Information')]");
        By searchCompany = By.XPath("//input[@id='name']");
        By goButton = By.XPath("//button[@id='LoadRecordsButton']");

        By visitCompanyButtontoedit = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By visitcompanyNametoedit = By.XPath("//h2[contains(text(),'QUESTAutoComp01')]");

        By PaymentTerminalsDropdown = By.XPath("//a[@class='dropdown-toggle'][contains(text(),'Payment Terminals')]");
        By PaymentterminalGroups = By.XPath("//a[contains(text(),'Payment Terminal Groups')]");
        By paymentterminalText = By.XPath("//h2[contains(text(),'Payment Terminal Groups')]");
        By searchPTGroup = By.XPath("//input[@id='search']");

        By viewPaymentTerminal = By.XPath("//a[@href='/Store/acf166a2-9906-ea11-b62f-0050568b08ee/Details']");
        By addPaymentTerminalbutton = By.XPath("//a[@href='/Store/acf166a2-9906-ea11-b62f-0050568b08ee/CreatePaymentTerminalModal']");
        By clickSerialnodropDown = By.XPath("//span[contains(text(),'Select Serial Number')]");
        By entSerialNo = By.XPath("//div[@class='chosen-search']//input");
        By selSerialNo = By.ClassName("active-result");
        By addSerialNobutton = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By goPTGButton = By.XPath("//button[@class='btn']");
        By clickReqLog = By.XPath("//span[contains(text(),'Disabled')]");
        By entReqLog = By.XPath("//div[@class='chosen-search']//input");
        //By selReqLog = By.ClassName("active-result result-selected");
        By selReqLog = By.XPath("//ul[@class='chosen-results']");
        By merchantId = By.XPath("//input[@id='EftSettings_0__CAID']");
        By terminalId = By.XPath("//input[@id='EftSettings_0__CATID']");
        By editPTsave = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        //
        By Paymentterminals = By.XPath("//a[contains(text(),'All Payment Terminals')]");
        By paymentterminalsText = By.XPath("//h2[contains(text(),'Payment Terminals')]");
        By searchPTs = By.XPath("//input[@id='search']");
        By clickGoPTs = By.XPath("//button[@class='btn']");
        By editPT = By.XPath("//a[@class='btn btn-small']");
        By editPOSId = By.Id("PosID");
        
        By geteditPT = By.XPath("//h2[contains(text(),'Edit Payment Terminal')]");
        By blockPTbutton = By.XPath("//a[@class='btn btn-small btn-danger']");
        By additionalInformation = By.Id("BlackListDescription");
        By blockConfbutton = By.XPath("//input[@class='btn btn-danger span2 btn-footeraction']");
        By yesBlockbutton = By.XPath("//input[contains(@class,'btn btn-danger span2 btn-footeraction')]");
        By blockText = By.XPath("//p[contains(text(),'Blocked')]");


        public void enterCompanyName(string varsearchcompany)
        {
            driver.FindElement(searchCompany).SendKeys(varsearchcompany);

        }
        public void clickGo()
        {
            driver.FindElement(goButton).Click();
        }
        public void clickVisittoEdit()
        {
            driver.FindElement(visitCompanyButtontoedit).Click();
        }
        public string getcompanyDetailstoview()
        {
            return driver.FindElement(visitcompanyNametoedit).Text;
        }

        public void clickPaymentTerminalsDropdown()
        {
            driver.FindElement(PaymentTerminalsDropdown).Click();
        }

        public void clickPaymentTerminalGroups()
        {
            driver.FindElement(PaymentterminalGroups).Click();
        }

        public string getPaymentTerminalGroupText()
        {
            return driver.FindElement(paymentterminalText).Text;
        }

        public void searchPTgroup(string varsearchptgroup)
        {
            driver.FindElement(searchPTGroup).SendKeys(varsearchptgroup);

        }

        public void clickPTGo()
        {
            driver.FindElement(goPTGButton).Click();
        }
        public void clickviewPaymentTerminal()
        {
            driver.FindElement(viewPaymentTerminal).Click();
        }

        public string getpaymentTerminalsText()
        {
            return driver.FindElement(paymentterminalsText).Text;
        }

        public void clickaddPaymentTerminalbutton()
        {
            driver.FindElement(addPaymentTerminalbutton).Click();
        }

        public void clickselSerialnoDropdown()
        {
            driver.FindElement(clickSerialnodropDown).Click();
        }

        public void setentSerialNo(string varentserialno)
        {
            driver.FindElement(entSerialNo).SendKeys(varentserialno);
        }

        public void selectSerialNo()
        {
            driver.FindElement(selSerialNo).Click();
        }

        public void clickAddSerialno()
        {
            driver.FindElement(addSerialNobutton).Click();
        }

        public void clickReqLogUpload()
        {
            driver.FindElement(clickReqLog).Click();
        }

        public void setentReqLog(string varentreqlog)
        {
            driver.FindElement(entReqLog).SendKeys(varentreqlog);
        }

        public void selectselReqLog()
        {
            driver.FindElement(selReqLog).Click();
        }

        public void setmechantId(string varmechantid)
        {
            driver.FindElement(merchantId).SendKeys(varmechantid);
        }

        public void setterminalId(string varterminalid)
        {
            driver.FindElement(terminalId).SendKeys(varterminalid);
        }

        //public void ClickeditPTsave()
        //{
        //    driver.FindElement(editPTsave).Click();
        //}


        // Edit PT

        

        public void clickallPaymentTerminals()
        {
            driver.FindElement(Paymentterminals).Click();
        }

        public void enterPTs(string varsearchpts)
        {
            driver.FindElement(searchPTs).SendKeys(varsearchpts);

        }

        public void searchPT()
        {
            driver.FindElement(clickGoPTs).Click();
        }

        public void clickeditPT()
        {
            driver.FindElement(editPT).Click();
        }

        public void enterPosId(string varenterposid)
        {
            driver.FindElement(editPOSId).SendKeys(varenterposid);

        }

        public string geteditPTText()
        {
            return driver.FindElement(geteditPT).Text;
        }

        public void ClickeditPTsave()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(editPTsave).Click();
        }


        // block PT

        public void blockPTs()
        {
            driver.FindElement(blockPTbutton).Click();
        }

        public void blockConfirmationPT()
        {
            driver.FindElement(blockConfbutton).Click();
        }

        public void enterAdditionalInformation(string varaddinfor)
        {
            driver.FindElement(additionalInformation).SendKeys(varaddinfor);

        }

        public void clickyesBlockbutton()
        {
            driver.FindElement(yesBlockbutton).Click();
        }

        public string getBlockText()
        {

            return driver.FindElement(blockText).Text;

        }


    }
}
