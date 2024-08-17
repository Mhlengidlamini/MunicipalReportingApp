using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalReportingApp
{
    public partial class ReportIssuesForm : Form
    {
        // Declare the list of issues at the class level
        private List<Issue> issues = new List<Issue>();

        public ReportIssuesForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ReportIssuesForm_Load);
        }

        // This is the missing method that handles the Load event
        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            // Add your code here that should run when the form loads
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Handle the selected file (e.g., save the file path)
                string filePath = openFileDialog.FileName;
                lblEngagement.Text = "Media file attached: " + System.IO.Path.GetFileName(filePath);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Capture issue details
            string location = txtLocation.Text;
            string category = cmbCategory.SelectedItem?.ToString() ?? "Unspecified";
            string description = rtxtDescription.Text;
            DateTime reportedAt = DateTime.Now;  // Get the current date and time
            string mediaPath = lblEngagement.Text.Contains("Media file attached:")
                                ? lblEngagement.Text.Replace("Media file attached: ", "")
                                : null; // Get the media path if attached

            // Add the issue to the persistent list
            issues.Add(new Issue
            {
                Location = location,
                Category = category,
                Description = description,
                ReportedAt = reportedAt,
                MediaPath = mediaPath
            });

            // Provide feedback to the user
            MessageBox.Show("Your issue has been reported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form inputs after submission
            txtLocation.Clear();
            rtxtDescription.Clear();
            cmbCategory.SelectedIndex = -1; // Reset the combo box
            lblEngagement.Text = "Thank you for your feedback!";

            // Update the ListBox to show the issues
            listBox1.Items.Clear(); // Clear the ListBox before adding new items
            foreach (var issue in issues)
            {
                listBox1.Items.Add($"{issue.ReportedAt}: {issue.Location} - {issue.Category}: {issue.Description}");
                if (!string.IsNullOrEmpty(issue.MediaPath))
                {
                    listBox1.Items.Add($"    Attached Media: {issue.MediaPath}");
                }
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
