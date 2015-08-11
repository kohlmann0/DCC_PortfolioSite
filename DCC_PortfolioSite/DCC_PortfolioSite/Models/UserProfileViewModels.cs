using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class UserProfileViewModels
    {
        public int ProfileID { get; set; }

        [DisplayName("First Name")]
        public string UserFirstName { get; set; }
        [DisplayName("Last Name")]
        public string UserLastName { get; set; }

        [DisplayName("Name")]
        public string FullName
        { 
            get { return(this.UserFirstName + " " + this.UserLastName);}
        }

        [DisplayName("Street Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [DisplayName("Zip Code")]
        public string Zip { get; set; }

        [DisplayName("Primary Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PrimaryPhone { get; set; }

        [DisplayName("Alternate Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string AlternatePhone { get; set; }

        [DisplayName("Primary Email Address")]
        [EmailAddress]
        public string PrimaryEmail { get; set; }

        [DisplayName("Alternate Email Address")]
        [EmailAddress]
        public string AlternateEmail { get; set; }

        [DisplayName("Profile Photo")]
        public byte[] ProfilePhoto { get; set; }

        [DisplayName("Link to LinkedIn profile")]
        [Url]
        public string LinkInProfile { get; set; }

        [DisplayName("Link to Git-Hub Profile")]
        [Url]
        public string GitHubProfile { get; set; }

        [DisplayName("Link to Personal Website")]
        [Url]
        public string PersonalWebsite { get; set; }

        [DisplayName("Available for Work Message")]
        public string AvailableForWorkMessage { get; set; }

        [DisplayName("Hire By Message")]
        public string HireByMessage { get; set; }

        [DisplayName("Currently Working on Message")]
        public string CurrentlyWorkingOnMessage { get; set; }


        // Boolean Hide/Display values
        public bool ShowAddress { get; set; }
        public bool ShowPrimaryPhone { get; set; }
        public bool ShowAlternatePhone { get; set; }
        public bool ShowPrimaryEmail { get; set; }
        public bool ShowAlternateEmail { get; set; }
        public bool ShowProfilePhoto { get; set; }
        public bool ShowLinkInProfile { get; set; }
        public bool ShowGitHubProfile { get; set; }
        public bool ShowPersonalWebsite { get; set; }
        public bool ShowAvailableForWorkMessage { get; set; }
        public bool ShowHireByMessage { get; set; }
        public bool ShowCurrentlyWorkingOnMessage { get; set; }


        public ResumeViewModels ResumeViewModelObject { get; set; }
        public List<ProjectSpotLightViewModels> ProjectSpotLightObjectList { get; set; }
    }
}