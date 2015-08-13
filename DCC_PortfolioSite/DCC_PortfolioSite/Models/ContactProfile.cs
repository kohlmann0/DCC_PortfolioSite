namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Collections.Generic;
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
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(255)]
        public string PrimaryPhone { get; set; }

        [StringLength(255)]
        public string AlternatePhone { get; set; }

        [StringLength(255)]
        public string PrimaryEmail { get; set; }

        [StringLength(255)]
        public string AlternateEmail { get; set; }

        [StringLength(255)]
        public string StreetAddress { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string USAState { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        public int? PostalCode { get; set; }

        [Required]
        [StringLength(2000)]
        public string About { get; set; }

        public string Photo { get; set; }

        [StringLength(255)]
        public string LinkedIn { get; set; }

        [StringLength(255)]
        public string GitHub { get; set; }

        [StringLength(255)]
        public string PersonalWebsite { get; set; }

        public bool? AvailableForWork { get; set; }

        [StringLength(255)]
        public string HiredBy { get; set; }

        [StringLength(255)]
        public string CurrentWork { get; set; }

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
