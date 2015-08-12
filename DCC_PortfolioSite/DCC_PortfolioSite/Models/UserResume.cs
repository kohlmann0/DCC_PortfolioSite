namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserResume")]
    public partial class UserResume
    {
        public int UserResumeID { get; set; }

        public int ProfileID { get; set; }

        [Required]
        public string HtmlUpload { get; set; }

        public virtual ContactProfile ContactProfile { get; set; }
    }
}
