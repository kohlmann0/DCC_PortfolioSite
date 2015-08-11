namespace DCC_PortfolioSite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AlumniDBModel : DbContext
    {
        public AlumniDBModel()
            : base("name=AlumniDBModel")
        {
        }

        public virtual DbSet<CollaborateMember> CollaborateMembers { get; set; }
        public virtual DbSet<CollaboratePost> CollaboratePosts { get; set; }
        public virtual DbSet<CollaborateProject> CollaborateProjects { get; set; }
        public virtual DbSet<ContactProfile> ContactProfiles { get; set; }
        public virtual DbSet<ProjectSpotlight> ProjectSpotlights { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserResume> UserResumes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollaboratePost>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<CollaborateProject>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<CollaborateProject>()
                .Property(e => e.ProjectDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CollaborateProject>()
                .Property(e => e.ProjectLink)
                .IsUnicode(false);

            modelBuilder.Entity<CollaborateProject>()
                .HasMany(e => e.CollaborateMembers)
                .WithRequired(e => e.CollaborateProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CollaborateProject>()
                .HasMany(e => e.CollaboratePosts)
                .WithRequired(e => e.CollaborateProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.PrimaryPhone)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.AlternatePhone)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.PrimaryEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.AlternateEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.StreetAddress)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.USAState)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.About)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.LinkedIn)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.GitHub)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.PersonalWebsite)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.HiredBy)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .Property(e => e.CurrentWork)
                .IsUnicode(false);

            modelBuilder.Entity<ContactProfile>()
                .HasMany(e => e.CollaborateMembers)
                .WithRequired(e => e.ContactProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactProfile>()
                .HasMany(e => e.CollaboratePosts)
                .WithRequired(e => e.ContactProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactProfile>()
                .HasMany(e => e.CollaborateProjects)
                .WithRequired(e => e.ContactProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactProfile>()
                .HasMany(e => e.ProjectSpotlights)
                .WithRequired(e => e.ContactProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactProfile>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.ContactProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactProfile>()
                .HasMany(e => e.UserResumes)
                .WithRequired(e => e.ContactProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectSpotlight>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSpotlight>()
                .Property(e => e.Technologies)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSpotlight>()
                .Property(e => e.DevelopmentTime)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSpotlight>()
                .Property(e => e.ProjectDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSpotlight>()
                .Property(e => e.RepoLink)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSpotlight>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.ProjectSpotlight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.ContactProfiles)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(false);
        }
    }
}
