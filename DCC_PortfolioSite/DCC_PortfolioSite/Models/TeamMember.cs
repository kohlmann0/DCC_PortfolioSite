namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamMember")]
    public partial class TeamMember
    {
        public int TeamMemberID { get; set; }

        public int ProfileID { get; set; }

        public int ProjectSpotlightID { get; set; }

        public virtual ContactProfile ContactProfile { get; set; }

        public virtual ProjectSpotlight ProjectSpotlight { get; set; }
    }
}
