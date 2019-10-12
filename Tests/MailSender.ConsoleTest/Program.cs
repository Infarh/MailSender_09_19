using System;
using MailSender.ConsoleTest.Reports;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var report = new Report
            {
                Data1 = "Тестовые даныне",
                TimeValue = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 17))
            };

            const string report_file = "TestReport.docx";

            report.CreatePackage(report_file);


            //Console.ReadLine();
        }
    }
}
