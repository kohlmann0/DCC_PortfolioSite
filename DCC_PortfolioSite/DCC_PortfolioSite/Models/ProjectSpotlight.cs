namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectSpotlight")]
    public partial class ProjectSpotlight
    {
        public ProjectSpotlight()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public int ProjectSpotlightID { get; set; }

        public int ProfileID { get; set; }

        [Required]
        [StringLength(255)]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(255)]
        public string Technologies { get; set; }

        [Required]
        [StringLength(255)]
        public string DevelopmentTime { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [Required]
        public string RepoLink { get; set; }

        
        public string Image_1 { get; set; }

        
        public string Image_2 { get; set; }

        [DisplayName("Project Image 1")]
        public byte[] SpotlightImg_1 { get; set; }

         [DisplayName("Project Image 2")]
        public byte[] SpotlightImg_2 { get; set; }

        public virtual ContactProfile ContactProfile { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
