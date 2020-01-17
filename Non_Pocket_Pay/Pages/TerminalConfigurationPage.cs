// Created By - Janani Samarawickrama
// Automation Framwork - Non Pocket Pay
// Created Date - 02/11/2019
// Updated Date - 02/11/2019
// Version - 0.0.01

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Non_Pocket_Pay.Pages
{
    class TerminalConfigurationPage
    {   //create a driver
        IWebDriver driver;

        //constructor
        public TerminalConfigurationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By configurePaymentTerminal = By.XPath("//a[contains(text(),'Configure Payment Terminal')]");
        By terminalconfig = By.XPath("//a[contains(text(),'Terminal Configuration')]");
        By saveTerminal = By.XPath("//input[@class='btn btn-primary span2 btn-footeraction']");
        By tippingIs = By.XPath("//select[@name='EnableTipping']");
        By configureTerminalText = By.XPath("//h2[contains(text(),'Terminal configuration')]");
        public void clickconfigurePT()
        {
            driver.FindElement(configurePaymentTerminal).Click();
        }

        public void clickTerminalConfig()
        {
            driver.FindElement(terminalconfig).Click();
        }

        public void settippingIs(string tippingis)
        {
            driver.FindElement(tippingIs).SendKeys(tippingis);

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
    }
}
