namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfile")]
    public partial class UserProfile
    {
        public UserProfile()
        {
            ContactProfiles = new HashSet<ContactProfile>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string UserPassword { get; set; }

        public virtual ICollection<ContactProfile> ContactProfiles { get; set; }
    }
}
