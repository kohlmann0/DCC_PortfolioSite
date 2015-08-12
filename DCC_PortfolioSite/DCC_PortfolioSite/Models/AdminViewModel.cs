using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class AdminViewModel
    {
        ContactProfile contactProfile = new ContactProfile();
        UserProfile userProfile = new UserProfile();
        UserResume userResume = new UserResume();
        ProjectSpotlight projectSpotlight = new ProjectSpotlight();


        public ContactProfile ContactProfile { get; set; }
        public UserProfile UserProfile { get; set; }
        public UserResume UserResume { get; set; }
        public ProjectSpotlight ProjectSpotlight { get; set; }
    }
}