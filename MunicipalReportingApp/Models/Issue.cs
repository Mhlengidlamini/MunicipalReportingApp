using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalReportingApp
{
    // Consolidate the Issue class here and remove any other duplicate definitions
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaPath { get; set; }  // Path to attached media
        public DateTime ReportedAt { get; set; }  // Date and time of the report
    }
}
