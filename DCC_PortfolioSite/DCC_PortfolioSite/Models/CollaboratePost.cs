namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CollaboratePost
    {
        public int CollaboratePostID { get; set; }

        public int ProfileId { get; set; }

        public int CollaborateProjectId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        public virtual CollaborateProject CollaborateProject { get; set; }

        public virtual ContactProfile ContactProfile { get; set; }
    }
}
