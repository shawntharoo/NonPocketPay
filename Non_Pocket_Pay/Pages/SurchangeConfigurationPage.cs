// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 02/11/2019
// Updated Date - 02/11/2019
// Version - 0.0.01

using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
    {
        class SurchangeConfigurationPage
        {   //create a driver
            IWebDriver driver;

            //constructor
            public SurchangeConfigurationPage(IWebDriver driver)
            {
                this.driver = driver;
            }

        By configurePaymentTerminal = By.XPath("//a[contains(text(),'Configure Payment Terminal')]");
        By surchargeconfig = By.XPath("//a[contains(text(),'Surcharge Configuration')]");
        By debitRate = By.XPath("//input[@name='SurchargeBankEntries[0].Rate']");
        By visaAmount = By.Name("SurchargeBankEntries[1].Amount");
        By saveSurcharge = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By viewPTG = By.XPath("//a[@href='/Store/271423a9-b514-ea11-a5a7-0050568b08ee/Details']");
        By surchargeEnabled = By.Id("EnableSurcharging");
        By peymentTerminalConfig = By.XPath("//a[@href='/PinpadConfiguration/b708358b-040f-ea11-b62f-0050568b08ee/Options?type=3']");
        By mastercardAmount = By.Name("SurchargeBankEntries[2].Amount");
        By amexRate = By.Name("SurchargeBankEntries[3].Rate");
        By surchargingText = By.XPath("//h2[contains(text(),'Surcharging')]");
        By configurePToptionsText = By.XPath("//h2[contains(text(),'Configure payment terminal options')]");
        By paymentterminalsText = By.XPath("//h2[contains(text(),'Payment Terminals')]");
        By paymentterminalsgroupText = By.XPath("//h2[contains(text(),'Payment Terminal Groups')]");
        public void clickconfigurePT()
        {
            driver.FindElement(configurePaymentTerminal).Click();
        }

        public void clickSurchargeConfig()
        {
            driver.FindElement(surchargeconfig).Click();
        }

        public void clickviewPTG()
        {
            driver.FindElement(viewPTG).Click();
        }
               
        public void setdebitRate(string enterdebitrate)
        {
            driver.FindElement(debitRate).SendKeys(enterdebitrate);

        }

        public void setvisaAmount(string entervisaAmount)
        {
            driver.FindElement(visaAmount).SendKeys(entervisaAmount);

        }
        public void cleardebitRate() 
        {
            driver.FindElement(debitRate).Clear();
        }

        public void clearvisaAmount()
        {
            driver.FindElement(visaAmount).Clear();
        }

        public void setSurcharging(string enterenabled)
        {
            driver.FindElement(surchargeEnabled).SendKeys(enterenabled);
        }

        public void clickpeymentTerminalConfig()
        {
            driver.FindElement(peymentTerminalConfig).Click();
        }
        public void clickSaveSurcharge()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(saveSurcharge).Click();
        }

        public void setmastercardAmount(string varmastercardamount)
        {
            driver.FindElement(mastercardAmount).SendKeys(varmastercardamount);

        }

        public void setamexRate(string varamexrate)
        {
            driver.FindElement(amexRate).SendKeys(varamexrate);

        }
        public void clearmastercardAmount()
        {
            driver.FindElement(mastercardAmount).Clear();
        }

        public void clearamexRate()
        {
            driver.FindElement(amexRate).Clear();
        }

        public string getsurchargingText()
        {

            return driver.FindElement(surchargingText).Text;

        }

        public string getconfigurePToptionsText()
        {

            return driver.FindElement(configurePToptionsText).Text;

        }

        public string getpaymentterminalsText()
        {

            return driver.FindElement(paymentterminalsText).Text;

        }

        public string getpaymentterminalsgroupText()
        {
            return driver.FindElement(paymentterminalsgroupText).Text;

        }


    }
}
