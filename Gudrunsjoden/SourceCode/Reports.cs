using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using GudrunsjodenConfig.SourceCode;
using System.IO;

namespace Gudrunsjoden.Reports
{
    public class re
    {
        //private static ExtentReports extent;
        public static ExtentTest test;
        public static string ReportName;
        public static ExtentReports extent = re.Instance;

        public static ExtentReports Instance
        {

            get
            {
                if (extent == null)
                {
                    //var ReportLocation = Main.ReportsDirectory;
                    //if (!Directory.Exists(ReportLocation))  // if it doesn't exist, create
                    //    Directory.CreateDirectory(ReportLocation);
                    //extent = new ExtentReports(ReportLocation +   "report_" + DateTime.Now.ToString("hh-mm-sstt") + ".html", false);


                    string CurrentTime = DateTime.Now.ToString("hh-mm-sstt");
                    var ReportLocation = Path.Combine(Main.ReportsDirectory, DateTime.Now.ToString("dd-MMM-yyyy"));
                    if (!Directory.Exists(ReportLocation))
                        Directory.CreateDirectory(ReportLocation);
                    ReportName = Path.Combine(ReportLocation, "report_" + DateTime.Now.ToString("hh-mm-sstt") + ".html");
                    extent = new ExtentReports(ReportName);








                }



                return extent;



            }
        }
        public static void StartTest(string TestName, string TestDescription)
        {
            test = extent.StartTest(TestName, TestDescription);
        }
        public static void EndTest()
        {
            extent.EndTest(test);
            extent.Flush();
        }

        public static void LogStatusReport(string status, string description)
        {

            LogStatus logstatus;

            switch (status.ToUpper())
            {
                case "FAIL":
                    logstatus = LogStatus.Fail;
                    break;
                case "WARNING":
                    logstatus = LogStatus.Warning;
                    break;
                case "SKIP":
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, description);


        }


    }
}
