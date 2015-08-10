using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class ResumeViewModels
    {
        public int ResumeID { get; set; }
        public int UserID { get; set; }
        public byte[] ResumeFile { get; set; }
        public int RevisionNumber { get; set; }
    }
}