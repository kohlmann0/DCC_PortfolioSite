namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CollaborateMember
    {
        public int CollaborateMemberID { get; set; }

        public int ProfileId { get; set; }

        public int CollaborateProjectId { get; set; }

        public virtual ContactProfile ContactProfile { get; set; }

        public virtual CollaborateProject CollaborateProject { get; set; }
    }
}
