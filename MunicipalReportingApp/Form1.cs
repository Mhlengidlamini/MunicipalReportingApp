using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalReportingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Manually assign the Click event handler for btnReportIssues
            btnReportIssues.Click += new EventHandler(button1_Click);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set the title and size of the form
            this.Text = "Municipal Reporting Application";
            this.Size = new System.Drawing.Size(400, 300);

            // Create and configure the "Report Issues" button
            Button btnReportIssues = new Button();
            btnReportIssues.Text = "Report Issues";
            btnReportIssues.Location = new System.Drawing.Point(100, 50);
            btnReportIssues.Size = new System.Drawing.Size(200, 50);
            btnReportIssues.Click += new EventHandler(button1_Click);
            this.Controls.Add(btnReportIssues);

            // Create and configure the "Local Events and Announcements" button (disabled)
            Button btnLocalEvents = new Button();
            btnLocalEvents.Text = "Local Events and Announcements";
            btnLocalEvents.Location = new System.Drawing.Point(100, 110);
            btnLocalEvents.Size = new System.Drawing.Size(200, 50);
            btnLocalEvents.Enabled = false;  // Disable this button
            this.Controls.Add(btnLocalEvents);

            // Create and configure the "Service Request Status" button (disabled)
            Button btnServiceStatus = new Button();
            btnServiceStatus.Text = "Service Request Status";
            btnServiceStatus.Location = new System.Drawing.Point(100, 170);
            btnServiceStatus.Size = new System.Drawing.Size(200, 50);
            btnServiceStatus.Enabled = false;  // Disable this button
            this.Controls.Add(btnServiceStatus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the ReportIssuesForm
            ReportIssuesForm reportForm = new ReportIssuesForm();

            // Show the ReportIssuesForm
            reportForm.Show();

            // Optionally, hide the current form (Form1)
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: You can also assign event handlers here if needed
            // button1.Click += new EventHandler(button1_Click);
        }
    }
}
