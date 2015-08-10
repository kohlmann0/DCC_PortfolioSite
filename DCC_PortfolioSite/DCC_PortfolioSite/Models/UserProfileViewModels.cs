using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class UserProfileViewModels
    {
        public int ProfileID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PrimaryPhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string AlternatePhone { get; set; }
        [EmailAddress]
        public string PrimaryEmail { get; set; }
        [EmailAddress]
        public string AlternateEmail { get; set; }
        public byte[] ProfilePhoto { get; set; }
        [Url]
        public UrlAttribute LinkInProfile { get; set; }
        [Url]
        public UrlAttribute GitHubProfile { get; set; }
        [Url]
        public UrlAttribute PersonalWebsite { get; set; }
        public string AvailableForWorkMessage { get; set; }
        public string HireByMessage { get; set; }
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
    }
}