using Non_Pocket_Pay.Tests;
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

            // TC2004809 - Login Sucessfully
            LoginSucessfullyTest loginsucessfully = new LoginSucessfullyTest();
            loginsucessfully.TC2004809_LoginSucessfully("fireforx");

            //// TC2004810 - Login not Sucessfully
            //LoginNotsucessfullyTest loginnotsucessfully = new LoginNotsucessfullyTest();
            //loginnotsucessfully.TC2004810_LoginNotsucessfully();

            //// TC2004827 - Add Customer type Company
            //AddCustomerCompanyTest addCustomerComp = new AddCustomerCompanyTest();
            //addCustomerComp.TC2004827_AddCustomerCompany();

            //// TC2004821 - Add Dealer type Company
            //AddDelearCompanyTest addDealerComp = new AddDelearCompanyTest();
            //addDealerComp.TC2004821_AddDealerCompany();

            //CreateCompanyunderDealerTest compunderdealer = new CreateCompanyunderDealerTest();
            //compunderdealer.TC2004821_CreateCompanyunderDealer();


            //// TC200482 - Visit Company
            //VisitCompanyTest visitComp = new VisitCompanyTest();
            //visitComp.TC2004828_VisitCompany();

            //// TC2004859 - Edit Company
            //EditCompanyTest editComp = new EditCompanyTest();
            //editComp.TC2004859_EditCompany();

            //// TC2004961 - View Payment Terminals Group
            //ViewPaymentTerminalGroupTest viewPTG = new ViewPaymentTerminalGroupTest();
            //viewPTG.TC2004961_ViewPaymentTerminalGroup();

            //// TC2004860 - Create Payment Terminals Group
            //CreatePaymentTerminalGroupTest createPayTerm = new CreatePaymentTerminalGroupTest();
            //createPayTerm.TC2004860_CreatePaymentTerminalGroup();

            //// TC2004896 - Delete Payment Terminals Group
            //DeletePaymentTerminalGroupTest deletePayTerm = new DeletePaymentTerminalGroupTest();
            //deletePayTerm.TC2004896_DeletePaymentTerminalGroup();

            //// TC2004873 - Create Payment Terminals
            //CreatePaymentTerminalsTest createPTs = new CreatePaymentTerminalsTest();
            //createPTs.TC2004873_CreatePaymentTerminals();

            //// TC2004962 - Edit Payment Terminals
            //EditPaymentTerminalsTest editPTs = new EditPaymentTerminalsTest();
            //editPTs.TC2004962_EditPaymentTerminals();

            //// TC2004960 - Block Payment Terminals
            //BlockPaymentTerminalsTest blockPTs = new BlockPaymentTerminalsTest();
            //blockPTs.TC2004960_BlockPaymentTerminals();

            //// TC2004870 - Seril No Not Used
            //SerilNoNotUsedTest serilnonotused = new SerilNoNotUsedTest();
            //serilnonotused.TC2004870_SerilNoNotUsed();

            //// TC2004870 - Seril No Not Used
            //SerialNoinUsedTest serialnonotused = new SerialNoinUsedTest();
            //serialnonotused.TC2004955_SerilNoinUsed();

            ////TC2004958 - Add Payment Terminal to Companypool
            //AddPaymentTerminaltoCompanypoolTest addPayTermcompPool = new AddPaymentTerminaltoCompanypoolTest();
            //addPayTermcompPool.TC2004958_AddPaymentTerminaltoCompanypool();

            ////TC2004989 - Delete Payment Terminal to Company pool
            //DisassociatePTfromCompanypoolTest disassociatePayTermcompPool = new DisassociatePTfromCompanypoolTest();
            //disassociatePayTermcompPool.TC2004989_DisassociatePaymentTerminalfromCompanypool();

            ////TC2004959 - Delete Payment Terminal to Company pool
            //DeletePaymentTerminaltoCompanypoolTest deletePayTermcompPool = new DeletePaymentTerminaltoCompanypoolTest();
            //deletePayTermcompPool.TC2004959_DeletePaymentTerminaltoCompanypool();


            //// TC2004975 - Add Sim Management Maintenance
            //AddSimManagement_MaintenanceTest addsim = new AddSimManagement_MaintenanceTest();
            //addsim.TC2004975_AddsimManagement_MaintenanceTest();

            ////TC2004976 - Delete Sim Management Maintenance
            //DeleteSimManagement_MaintenanceTest deletesim = new DeleteSimManagement_MaintenanceTest();
            //deletesim.TC2004976_DeletesimManagement_MaintenanceTest();

            //////TC2004976 - Upload Sim Management Maintenance
            //UploadSimManagement_MaintenanceTest uploadsim = new UploadSimManagement_MaintenanceTest();
            //uploadsim.TC2005045_UploadsimManagement_MaintenanceTest();

            ////TC2004991 - Surcharge Configuration for Company level
            //SurchargeConfigurationforCompanylevelTest surchargeCompLevel = new SurchargeConfigurationforCompanylevelTest();
            //surchargeCompLevel.TC2004991_SurchargeConfigurationforCompanylevel();

            ////TC2004993 - Surcharge Configuration for PTG level
            //SurchargeConfigurationforPTGlevelTest surchargePTGLevel = new SurchargeConfigurationforPTGlevelTest();
            //surchargePTGLevel.TC2004993_SurchargeConfigurationforPTGlevel();

            ////TC2004995 - Surcharge Configuration for PT level
            //SurchargeConfigurationforPTlevelTest surchargePTLevel = new SurchargeConfigurationforPTlevelTest();
            //surchargePTLevel.TC2004995_SurchargeConfigurationforPTlevel();

            ////TC2004992 - Terminal Configuration for Company level
            //TerminalConfigurationforCompanylevelTest terminalCompLevel = new TerminalConfigurationforCompanylevelTest();
            //terminalCompLevel.TC2004992_TerminalConfigurationforCompanylevel();

            ////TC2004994 - Terminal Configuration for PTG level
            //TerminalConfigurationforPTGlevelTest terminalPTGLevel = new TerminalConfigurationforPTGlevelTest();
            //terminalPTGLevel.TC2004994_TerminalConfigurationforPTGlevel();

            ////TC2004996 - Terminal Configuration for PT level
            //TerminalConfigurationforPTlevelTest terminalPTLevel = new TerminalConfigurationforPTlevelTest();
            //terminalPTLevel.TC2004996_TerminalConfigurationforPTlevel();

            ////2004874 - Configuration Firmware for Company level Test
            //ConfigurationFirmwareforCompanylevelTest configFirewarecomp = new ConfigurationFirmwareforCompanylevelTest();
            //configFirewarecomp.TC2004874_ConfigurationFirmwareforCompanylevel();

            ////2005019 - Configuration Firmware for PTG level Test
            //ConfigurationFirmwareforPTGlevelTest configFirewarePTG = new ConfigurationFirmwareforPTGlevelTest();
            //configFirewarePTG.TC2005019_ConfigurationFirmwareforPTGlevel();

            ////2005019 - Configuration Firmware for PT level Test
            //ConfigurationFirmwareforPTlevelTest configFirewarePT = new ConfigurationFirmwareforPTlevelTest();
            //configFirewarePT.TC2005021_ConfigurationFirmwareforPTlevel();

            ////2004879 - Configuration Airpay for Company level Test
            //ConfigurationAirpayforCompanylevelTest configAirpaycomp = new ConfigurationAirpayforCompanylevelTest();
            //configAirpaycomp.TC2004874_ConfigurationAirpayforCompanylevel();

            ////2005019 - Configuration Airpay for PTG level Test
            //ConfigurationAirpayforPTGlevelTest configAirpayPTG = new ConfigurationAirpayforPTGlevelTest();
            //configAirpayPTG.TC2005020_ConfigurationAirpayforPTGlevel();

            ////2005019 - Configuration Airpay for PT level Test
            //ConfigurationAirpayforPTlevelTest configAirpayPT = new ConfigurationAirpayforPTlevelTest();
            //configAirpayPT.TC2005022_ConfigurationAirpayforPTlevel();

            //ReportsTest report = new ReportsTest();
            //report.TC2004870_PINpadHealthStatusReport();


            ////Rajesh's Test Cases

            ////Reset Email
            //UserSignIn_ResetPasswordTest resetPasswordTest = new UserSignIn_ResetPasswordTest();
            //resetPasswordTest.TC2004816_UserSignIn_ResetPasswordTest();

            ////Test Cancel
            //UserSignIn_CancelButtonTest cancelButtonTest = new UserSignIn_CancelButtonTest();
            //cancelButtonTest.TC2004815_UserSignIn_CancelButtonTest();

            ////2004897 - Create Users
            //CreateUserTest createUserTest = new CreateUserTest();
            //createUserTest.TC2004897_CreateUserTest();

            //////2004898 - Edit Users
            //EditUserTest editUser = new EditUserTest();
            //editUser.TC2004898_EditUserTest();

            ////2004897 - Delete Users
            //DeleteUserTest deleteUserTest = new DeleteUserTest();
            //deleteUserTest.TC2004899_DeleteUserTest();

            ////2005023 - Export PINpad Files
            //Quest_PinpadFileUpdateStatusTest quest_PinpadFileUpdateStatusTest = new Quest_PinpadFileUpdateStatusTest();
            //quest_PinpadFileUpdateStatusTest.TC2005023_Quest_PinpadFileUpdateStatus();

            //// 2004892 - Add POS Gateway
            //AddPOSGatewayTest addPOSGateway = new AddPOSGatewayTest();
            //addPOSGateway.TC2004892_AddPOSGatewayTest();

            ////2004893 - Edit POS Gateway Record
            //EditPOSGatewayTest editPOSGatewayTest = new EditPOSGatewayTest();
            //editPOSGatewayTest.TC2004893_EditPOSGatewayTest();

            ////2004894 - Delete POS Gateway
            //DeletePOSGatewayTest deletePOSGateway = new DeletePOSGatewayTest();
            //deletePOSGateway.TC2004894_DeletePOSGatewayTest();

            //// 2004963 - Add Sim Number
            //AddSimNumberDetailsTest addSimNumberDetails = new AddSimNumberDetailsTest();
            //addSimNumberDetails.TC2004963_AddSimNumberDetailsTest();

            //// 2004964 - Delete Sim Number
            //DeleteSimNumberTest deleteSimNumber = new DeleteSimNumberTest();
            //deleteSimNumber.TC2004964_DeleteSimNumberTest();

            //// 2004964 - Edit Sim Number
            //EditSimNumberTest editSimNumber = new EditSimNumberTest();
            //editSimNumber.TC2004965_EditSimNumberTest();

            //// 2005011 - Export Terminal Count reort
            //TerminalCountReportTest terminalCount = new TerminalCountReportTest();
            //terminalCount.TC2005011_ReportTest();

            //// 2005012 - Export Terminal Count reort by Company
            //TerminalCountReportByCompanyTest terminalCountReportByCompany = new TerminalCountReportByCompanyTest();
            //terminalCountReportByCompany.TC2005012_TerminalCountReportByCompany();

            ////////terminalCountReportByCompany.TC_2005013_TCReportBySetCompany();

            ////Add New Device Test
            //AddNewDeviceTest addNewDevice = new AddNewDeviceTest();
            //addNewDevice.TC2004972_AddNewDeviceTest();

            ////Block Existing Device
            //BlockExistingDeviceTest BlockExistingDevice = new BlockExistingDeviceTest();
            //BlockExistingDevice.TC2004973_BlockExistingDeviceTest();

            ////Unblock Device Test
            //UnblockDeviceTest unblockDevice = new UnblockDeviceTest();
            //unblockDevice.TC2004974_UnblockDeviceTest();

            ////Add Maintainance Admin User test
            //MAddAdminUserTest mAddAdminUser = new MAddAdminUserTest();
            //mAddAdminUser.TC2004977_MAddAdminUserTest();

            ////Delete Maintainance Admin test
            //MDeleteAdminUserTest mDeleteAdminUser = new MDeleteAdminUserTest();
            //mDeleteAdminUser.TC2004978_MDeleteAdminUserTest();

            ////Edit Maintainance Admin 
            //MEditAdminUserTest editAdminUserTest = new MEditAdminUserTest();
            //editAdminUserTest.TC2004979_MEditAdminUserTest();

            ////Add DPT Range test
            //AddDPTRangeTest addDPTRange = new AddDPTRangeTest();
            //addDPTRange.TC2004980_AddDPTRangeTest();

            ////Edit DPT Range Test
            //EditDPTRangeTest editDPTRange = new EditDPTRangeTest();
            //editDPTRange.TC2004982_EditDPTRangeTest();

            ////Delete DPT Range Test
            //DeleteDPTRangeTest dPTRangeTest = new DeleteDPTRangeTest();
            //dPTRangeTest.TC2004981_DeleteDPTRangeTest();

            ////Transaction Count for all Companies
            //TransactionCountForAllCompaniesTest transactionCountForAllCompanies = new TransactionCountForAllCompaniesTest();
            //transactionCountForAllCompanies.TC2005016_TransactionCount();

            ////Approved and declined trancasction counts
            //TransCountApprovedAndDeclinedTest transCountApprovedAndDeclined = new TransCountApprovedAndDeclinedTest();
            //transCountApprovedAndDeclined.TC2005017_TransCountApprovedAndDeclined();

            ////Erroneous Transaction Count
            //ErroneousTransactionCountTest erroneousTransactionCount = new ErroneousTransactionCountTest();
            //erroneousTransactionCount.TC2005018_ErroneousTransactionCount();


        }
    }
}
