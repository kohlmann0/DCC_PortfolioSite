using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class UserRoleViewModel
    {
        
            public List<ApplicationUser> Users { get; set; }
            public List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles { get; set; }
            
            
            public string Username { get; set; }
            public string Role { get; set; }
        
    }
}