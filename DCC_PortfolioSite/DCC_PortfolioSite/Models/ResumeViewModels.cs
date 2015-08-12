using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class ResumeViewModels
    {
        public int ResumeID { get; set; }
        public int ProfileID { get; set; }
        public string ResumeFile { get; set; }
        public int RevisionNumber { get; set; }
        public string HtmlUpload { get; set; }

    }
}