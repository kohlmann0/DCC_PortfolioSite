﻿using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCC_PortfolioSite.Controllers
{
    public class UserRoleController : Controller
    {
        
        
        ApplicationDbContext context;
        public UserRoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: UserRole

        public ActionResult Index()
        {
            var allusers = context.Users.ToList();
            //var users = allusers.Where(x => x.Roles.Select(role => role.RoleId).Contains("User")).ToList();
            //var userVM = users.Select(user => new UserRoleViewModel { Username = user.UserName, Roles = string.Join(",", user.Roles.Select(role => role.RoleId)) }).ToList();

            //var admins = allusers.Where(x => x.Roles.Select(role => role.RoleId).Contains("Admin")).ToList();
            //var adminsVM = admins.Select(user => new UserRoleViewModel { Username = user.UserName, Roles = string.Join(",", user.Roles.Select(role => role.RoleId)) }).ToList();
            //var model = new DCC_PortfolioSite.Models.UserRoleViewModel.GroupedUserRoleViewModel { Users = userVM, Admins = adminsVM };

            return View(allusers);
        }
    }
}