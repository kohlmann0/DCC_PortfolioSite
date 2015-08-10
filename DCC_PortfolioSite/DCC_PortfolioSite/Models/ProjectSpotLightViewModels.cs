using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class ProjectSpotLightViewModels
    {
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> Technologies { get; set; }
        public List<string> TeamMembers { get; set; }

        public byte[] ProjectImage1 { get; set; }
        public byte[] ProjectImage2 { get; set; }
        public int DevelopementTime { get; set; }
        [Url]
        public UrlAttribute GitHubProfile { get; set; }
    }
}