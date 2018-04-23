using System;
using System.Windows.Forms;

using System.Text;
using System.Diagnostics;
using System.Globalization;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
// ...


namespace ExportToTextCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // A path to export a report.
            string reportPath = "c:\\Test.txt";

            // Create a report instance.
            XtraReport1 report = new XtraReport1();

            // Get its Text export options.
            TextExportOptions txtOptions = report.ExportOptions.Text;

            // Set Text-specific export options.
            txtOptions.Encoding = Encoding.Unicode;
            txtOptions.Separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString();

            // Export the report to Text.
            report.ExportToText(reportPath);

            // Show the result.
            StartProcess(reportPath);
        }

        // Use this method if you want to automaically open
        // the created Text file in the default program.
        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch { }
        }
    }
}