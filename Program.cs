using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Tests;
using DataDriven.Utilities;
using Non_Pocket_Pay.Pages;

namespace Non_Pocket_Pay
{
    class Program
    {
        static void Main(string[] args)
        {
            globals.expRpt = new ExtentReporter();
            globals.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");
            LoginTest logint = new LoginTest();
            logint.loginSucessfully();
            AddCompanyTest addComp = new AddCompanyTest();
            addComp.addCompany();
        }
    }
}
