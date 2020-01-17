﻿using OpenQA.Selenium;


namespace Non_Pocket_Pay.Pages
{
    class AddPOSGatewayPage
    {
        //create driver
        IWebDriver driver;

        //constructor

            public AddPOSGatewayPage(IWebDriver driver)
            {
                this.driver = driver;
            }



        By SearchByCompany = By.XPath("//input[@id='name']");
        By ClickGoBtn = By.Id("LoadRecordsButton");
        By ClickVisitBtn = By.XPath("//a[@href='/Admin/Company/Visit/708aca2a-8c06-ea11-b62f-0050568b08ee']");
        By ManagaPOSGateways = By.XPath("//a[contains(text(),'Manage POS Gateways')]");
        By AddPOSGateway = By.XPath("//span[@class='jtable-toolbar-item-icon']");
        By POSGatewayName = By.XPath("//input[@id='Edit-Name']");
        By Default = By.XPath("//input[@id='Edit-IsDefault']");
        By Save = By.XPath("//button[@id='AddRecordDialogSaveButton']//span[@class='ui-button-text'][contains(text(),'Save')]");




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

        public void ClickManagaPOSGateways()
        {
            driver.FindElement(ManagaPOSGateways).Click();
        }

        public void ClickAddPOSGateway()
        {
            driver.FindElement(AddPOSGateway).Click();
            //Thread.Sleep(2000);
            //IWebElement element = driver.FindElement(AddPOSGateway);
            //IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void SetPOSGatewayName(string posgatewayname)
        {
            driver.FindElement(POSGatewayName).SendKeys(posgatewayname);
        }


        public void CheckDefault()
        {
            driver.FindElement(Default).Click();
        }

        public void ClickSave()
        {
            driver.FindElement(Save).Click();
        }

    }
}
