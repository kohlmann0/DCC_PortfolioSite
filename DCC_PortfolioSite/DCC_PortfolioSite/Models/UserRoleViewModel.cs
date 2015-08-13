using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCC_PortfolioSite.Models
{
    public class UserRoleViewModel
    {
        public class GroupedUserRoleViewModel
        {
            public List<UserRoleModel> Users { get; set; }
            public List<UserRoleModel> Admins { get; set; }
        }

        public class UserRoleModel
        {
            public string Username { get; set; }
            public string Roles { get; set; }
        }
    }
}