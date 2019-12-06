using Non_Pocket_Pay.Tests;
using DataDriven.Utilities;
using Non_Pocket_Pay.Pages;

namespace Non_Pocket_Pay
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalFunctions.expRpt = new ExtentReporter();
            GlobalFunctions.expRpt.setupExtentReport("Automation Framework", "Non-Pocket framwork");

            //LoginTest logint = new LoginTest();
            //logint.loginSucessfully();
            //logint.loginNotsucessfully();

            AddCompanyTest addComp = new AddCompanyTest();
            addComp.addCompany();

            //EditCompanyTest editComp = new EditCompanyTest();
            //editComp.editCompany();

            //ViewPaymentTerminalGroupTest viewPayTerm = new ViewPaymentTerminalGroupTest();
            //viewPayTerm.viewPaymentTerminalGroup();

            //CreatePaymentTerminalGroupTest createPayTerm = new CreatePaymentTerminalGroupTest();
            //createPayTerm.createPaymentTerminalGroup();

            //DiagnosticinMaintenanceTest diagMain = new DiagnosticinMaintenanceTest();
            //diagMain.serilNoinUsed();
            //diagMain.serilNoNotUsed();


        }
    }
}
