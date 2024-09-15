using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalReportingApp
{
    public partial class ReportIssuesForm : Form
    {
        
        private List<Issue> issues = new List<Issue>();

        public ReportIssuesForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ReportIssuesForm_Load);
        }

        // This is the method that handles the Load event
        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            // Initialize the ProgressBar and Labels
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            lblEngagement.Text = "Start reporting your issue!";
            lblError.Text = ""; // Clear the error label on form load

            // Add predefined categories to the ComboBox
            cmbCategory.Items.AddRange(new string[]
            {
                "Pothole",
                "Water Leakage",
                "Power Outage",
                "Broken Streetlight",
                "Illegal Dumping",
                "Noise Complaint",
                "Vandalism",
                "Traffic Signal Issue",
                "Other"
            });

            // Optionally set the default selection to nothing
            cmbCategory.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to handle attaching both media and document files
        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            // Open file dialog to allow media or document attachment
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|Documents|*.pdf;*.docx;*.txt|All Files|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string filePath = openFileDialog.FileName;
                lblEngagement.Text = "File attached: " + System.IO.Path.GetFileName(filePath);

                // Update the ProgressBar to show some progress
                progressBar1.Value = 50;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Capture issue details
            string location = txtLocation.Text;
            string category = cmbCategory.SelectedItem?.ToString() ?? ""; // Fetch selected category
            string description = rtxtDescription.Text;

            // Validation to ensure all fields are filled
            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(description))
            {
                lblError.Text = "Please fill in all required fields!";
                lblError.ForeColor = System.Drawing.Color.Red;
                return; // Stop the submission process if validation fails
            }

            DateTime reportedAt = DateTime.Now;  // Get the current date and time
            string filePath = lblEngagement.Text.Contains("File attached:")
                                ? lblEngagement.Text.Replace("File attached: ", "")
                                : null; // Get the file path if attached

            // Add the issue to the persistent list
            issues.Add(new Issue
            {
                Location = location,
                Category = category,
                Description = description,
                ReportedAt = reportedAt,
                MediaPath = filePath // MediaPath now supports both media and documents
            });

            // Provide feedback to the user
            MessageBox.Show("Your issue has been reported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form inputs after submission
            txtLocation.Clear();
            rtxtDescription.Clear();
            cmbCategory.SelectedIndex = -1; // Reset the combo box
            lblEngagement.Text = "Thank you for your feedback!";
            lblError.Text = ""; // Clear error label after successful submission

            // Update the ListBox to show the issues
            listBox1.Items.Clear(); // Clear the ListBox before adding new items
            foreach (var issue in issues)
            {
                listBox1.Items.Add($"{issue.ReportedAt}: {issue.Location} - {issue.Category}: {issue.Description}");
                if (!string.IsNullOrEmpty(issue.MediaPath))
                {
                    listBox1.Items.Add($"    Attached File: {issue.MediaPath}");
                }
            }

            // Update the ProgressBar to 100% when the issue is reported
            progressBar1.Value = 100;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lblEngagement.Text = "Category selected!";
            progressBar1.Value = 25; // Increment the progress as category is selected
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
    }

}