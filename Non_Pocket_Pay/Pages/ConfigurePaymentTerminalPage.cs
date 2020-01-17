// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 02/11/2019
// Updated Date - 02/11/2019
// Version - 0.0.01

using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class ConfigurePaymentTerminalPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public ConfigurePaymentTerminalPage(IWebDriver driver)
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

        //Terminal Config
        By terminalconfig = By.XPath("//a[contains(text(),'Terminal Configuration')]");
        By saveTerminal = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By tippingIs = By.XPath("//select[@name='EnableTipping']");
        By configureTerminalText = By.XPath("//h2[contains(text(),'Terminal configuration')]");
        
        //Firmware Config
        By firmwareButton = By.XPath("//a[contains(text(),'Firmware Configuration')]");
        By firmwaredropdown = By.XPath("//a[@class='chosen-single chosen-single-with-deselect chosen-default']");
        By entFirmware = By.XPath("//div[@class='chosen-search']//input");
        By firmwarText = By.XPath("//h2[contains(text(),'Choose a firmware file')]");
        By firmwarevalue = By.XPath("//ul[@class='chosen-results']");
        By saveFirmware = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By firmware = By.XPath("//abbr[@class='search-choice-close']");

        //AirPay Config 
        By AirPayButton = By.XPath("//a[contains(text(),'AirPay Configuration')]");
        By AirPaydropdown = By.XPath("//a[@class='chosen-single chosen-single-with-deselect chosen-default']");
        By entAirPay = By.XPath("//div[@class='chosen-search']//input");
        By AirPayText = By.XPath("//h2[contains(text(),'Choose an airpay file')]");
        By AirPayvalue = By.XPath("//ul[@class='chosen-results']");
        By saveAirPay = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By airpay = By.XPath("//abbr[@class='search-choice-close']");
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

 
        // Terminal Config
        public void clickTerminalConfig()
        {
            driver.FindElement(terminalconfig).Click();
        }

        public void settippingIs(string vartippingis)
        {
            driver.FindElement(tippingIs).SendKeys(vartippingis);

        }
        public string getconfigureTerminalText()
        {

            return driver.FindElement(configureTerminalText).Text;

        }
        public void clickSaveTerminal()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
            driver.FindElement(saveTerminal).Click();
        }

        // Firmware Config
        public void clickFiremwarebutton()
        {

            driver.FindElement(firmwareButton).Click();
        }
        

        public void Clickfirmwaredropdown()
        {

            driver.FindElement(firmwaredropdown).Click();
        }         

        public void Clickfirmwarevalue()
        {

            driver.FindElement(firmwarevalue).Click();
        }

        public void enterFirmware(string varfirmeware)
        {
            driver.FindElement(entFirmware).SendKeys(varfirmeware);

        }

        public void clickSaveFirmware()
        {

            driver.FindElement(saveFirmware).Click();
        }

        public string getfirmwareText()
        {

            return driver.FindElement(firmwarText).Text;

        }

        public void clearFirmware()
        {
            driver.FindElement(firmware).Click();
        }
        // AirPay Config

        public void ClickAirPaybutton()
        {

            driver.FindElement(AirPayButton).Click();
        }


        public void ClickAirPaydropdown()
        {

            driver.FindElement(AirPaydropdown).Click();
        }

        public void ClickAirPayevalue()
        {

            driver.FindElement(AirPayvalue).Click();
        }

        public void enterAirPay(string varairpay)
        {
            driver.FindElement(entAirPay).SendKeys(varairpay);

        }

        public void clickSaveAirPay()
        {

            driver.FindElement(saveAirPay).Click();
        }

        public string getAirPayText()
        {

            return driver.FindElement(AirPayText).Text;

        }


        public void clearAirPay()
        {
            driver.FindElement(airpay).Click();
        }

    }
}
