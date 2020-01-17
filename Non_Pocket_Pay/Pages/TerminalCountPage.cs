using OpenQA.Selenium;

namespace Non_Pocket_Pay.Pages
{
    class TerminalCountPage
    {

        //Create Driver
        IWebDriver driver;

        //Constructor

        public TerminalCountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By QuestReports = By.XPath("//a[contains(text(),'Quest Reports')]");
        By TerminalCounts = By.XPath("//div[@id='terminalCountReport']");
        By Export = By.XPath("//*[@class='btn btn-small btn-success']");
                       
        public void ClickQuestReports()
        {
            driver.FindElement(QuestReports).Click();
        }

        public void ClickTerminalCounts()
        {
            driver.FindElement(TerminalCounts).Click();
        }

        public void ClickExport()
        {
            driver.FindElement(Export).Click();
        }
    }
}
