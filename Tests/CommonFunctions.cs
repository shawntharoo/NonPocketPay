using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Non_Pocket_Pay.Pages;

namespace Non_Pocket_Pay.Common
{
    class CommonFunctions
    {
        IWebDriver driver;
        public CommonFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void loginToApplication()
        {

            LoginPage loginP = new LoginPage(driver);
            string fullPath = getDatasourcePath();
            using (StreamReader file = File.OpenText(fullPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                driver.Navigate().GoToUrl(data["URL"].ToString());
                driver.Manage().Window.Maximize();
                loginP.setUserName(data["User_Name"].ToString());
                loginP.setPassword(data["password"].ToString());
                loginP.clickLogin();
            }
        }

        public string getDatasourcePath()
        {
            string fullPath = Path.GetFullPath("Data_Source\\Data_Set.json");
            return fullPath;
        }
    }
}
