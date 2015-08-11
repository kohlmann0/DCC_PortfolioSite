namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CollaborateProject")]
    public partial class CollaborateProject
    {
        public CollaborateProject()
        {
            CollaborateMembers = new HashSet<CollaborateMember>();
            CollaboratePosts = new HashSet<CollaboratePost>();
        }

        public int CollaborateProjectID { get; set; }

        [Required]
        [StringLength(255)]
        public string ProjectName { get; set; }

        public int ProfileId { get; set; }

        [StringLength(2000)]
        public string ProjectDescription { get; set; }

        public byte[] ProjectImage { get; set; }

        [StringLength(255)]
        public string ProjectLink { get; set; }

        public bool? ProjectStatus { get; set; }

        public virtual ICollection<CollaborateMember> CollaborateMembers { get; set; }

        public virtual ICollection<CollaboratePost> CollaboratePosts { get; set; }

        public virtual ContactProfile ContactProfile { get; set; }
    }
}
