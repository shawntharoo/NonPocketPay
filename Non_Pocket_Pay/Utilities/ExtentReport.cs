using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace DataDriven.Utilities
{
    class ExtentReporter
    {
        public static ExtentReports extRptDrv;
        ExtentHtmlReporter htmlReporter;
        private static ExtentTest testCase;

        public void setupExtentReport(string reportName, string documentTitle)
        {

            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");

            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;

            htmlReporter = new ExtentHtmlReporter(projectPath);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extRptDrv = extent;
            //extent.AddSystemInfo("Environment", "System Test Environment");
            //extent.AddSystemInfo("User name", "QuestAdmin");

        }

        public void CreateTest(string testName)
        {
            testCase = extRptDrv.CreateTest(testName);
        }

        public void logReportStatement(Status status, string message)
        {
            testCase.Log(status, message);
        }

        public void flushReport()
        {
            extRptDrv.Flush();
        }




    }
}