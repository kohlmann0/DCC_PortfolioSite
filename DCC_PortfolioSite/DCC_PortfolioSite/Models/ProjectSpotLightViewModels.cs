using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel;

namespace DCC_PortfolioSite.Models
{
    public class ProjectSpotLightViewModels
    {
        public int ProjectID { get; set; }
        public int ProfileID { get; set; }

        [DisplayName("Description")]
        public string ProjectDescription { get; set; }

        [DisplayName("Technologies Used")]
        public List<string> Technologies { get; set; }

        [DisplayName("Team Members")]
        public List<string> TeamMembers { get; set; }

        [DisplayName("Project Image")]
        public byte[] ProjectImage1 { get; set; }

        [DisplayName("Project Image")]
        public byte[] ProjectImage2 { get; set; }

        [DisplayName("Development Time")]
        public int DevelopementTime { get; set; }

        [DisplayName("Git Hub Repository")]
        [Url]
        public UrlAttribute GitHubProfile { get; set; }
    }
}