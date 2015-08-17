namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactProfile")]
    public partial class ContactProfile
    {
        public ContactProfile()
        {
            CollaborateMembers = new HashSet<CollaborateMember>();
            CollaboratePosts = new HashSet<CollaboratePost>();
            CollaborateProjects = new HashSet<CollaborateProject>();
            ProjectSpotlights = new HashSet<ProjectSpotlight>();
            TeamMembers = new HashSet<TeamMember>();
            UserResumes = new HashSet<UserResume>();
        }

        [Key]
        public int ProfileId { get; set; }

        public int? UserId { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(255)]
        public string LastName { get; set; }

        [DisplayName("Birth Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Primary Phone")]
        [StringLength(255)]
        public string PrimaryPhone { get; set; }

        [DisplayName("Alternate Phone")]
        [StringLength(255)]
        public string AlternatePhone { get; set; }

        [DisplayName("Primary Email")]
        [StringLength(255)]
        public string PrimaryEmail { get; set; }

        [DisplayName("Alternate Email")]
        [StringLength(255)]
        public string AlternateEmail { get; set; }

        [DisplayName("Street Address")]
        [StringLength(255)]
        public string StreetAddress { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [DisplayName("State or Province")]
        [StringLength(255)]
        public string USAState { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [DisplayName("Postal Code")]
        public int? PostalCode { get; set; }

        [Required]
        [DisplayName("About")]
        [StringLength(2000)]
        public string About { get; set; }

        public string Photo { get; set; }

        [DisplayName("LinkedIn Profile URL")]
        [StringLength(255)]        
        public string LinkedIn { get; set; }

        [DisplayName("GitHub Profile URL")]
        [StringLength(255)]
        public string GitHub { get; set; }

        [DisplayName("Personal Website URL")]
        [StringLength(255)]
        public string PersonalWebsite { get; set; }

        [DisplayName("Available for Work")]
        [StringLength(2000)]
        public string AvailableForWork { get; set; }

        [DisplayName("Hired By")]
        [StringLength(255)]
        public string HiredBy { get; set; }

        [DisplayName("Currently Working On")]
        [StringLength(2000)]
        public string CurrentWork { get; set; }

        [DisplayName("Available for Work")]
        public bool? AvailableForWorkMessage { get; set; }

        public bool? ShowAddress { get; set; }

        public bool? ShowAlternateEmail { get; set; }

        public bool? ShowAlternatePhone { get; set; }

        public bool? ShowAvailableForWork { get; set; }

        public bool? ShowCurrentlyWorking { get; set; }

        public bool? ShowGitHubLink { get; set; }

        public bool? ShowHireByMessage { get; set; }

        public bool? ShowLinkedInLink { get; set; }

        public bool? ShowPersonalWebsiteLink { get; set; }

        public bool? ShowPrimaryEmail { get; set; }

        public bool? ShowPrimaryPhone { get; set; }

        public bool? ShowProfilePhoto { get; set; }

        public virtual ICollection<CollaborateMember> CollaborateMembers { get; set; }

        public virtual ICollection<CollaboratePost> CollaboratePosts { get; set; }

        public virtual ICollection<CollaborateProject> CollaborateProjects { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<ProjectSpotlight> ProjectSpotlights { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }

        public virtual ICollection<UserResume> UserResumes { get; set; }
    }
}
