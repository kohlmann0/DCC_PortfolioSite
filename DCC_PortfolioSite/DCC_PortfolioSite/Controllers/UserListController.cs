using DCC_PortfolioSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCC_PortfolioSite.Controllers
{
    public class UserListController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        AlumniDBModel db = new AlumniDBModel();
        // GET: UserList
        public ActionResult Index(List<ContactProfile> SearchResults)
        {
            var userList = context.Users;

            List<ContactProfile> results = null;

            if (SearchResults != null)
            {
                results = SearchResults.ToList();
            }

            
            return View("Index",results);
        }

        public ActionResult Search(string tb_SearchBox)
        {

            List<List<string>> userRoleList = new List<List<string>>();
            if (string.IsNullOrEmpty(tb_SearchBox))
            {
                tb_SearchBox = "";
            }
            var results = (from contact in db.ContactProfiles
                           where
                               contact.FirstName.Contains(tb_SearchBox)
                               || contact.LastName.Contains(tb_SearchBox)
                               || contact.AlternateEmail.Contains(tb_SearchBox)
                               || contact.PrimaryEmail.Contains(tb_SearchBox)
                           select contact).OrderByDescending(m=>m.LastName).ToList();

            foreach (var item in results)
            {

                UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(item.PrimaryEmail, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                List<string>roleList = _userManager.GetRoles(user.Id).ToList();

                userRoleList.Add(roleList);
            }
            userRoleList.Reverse();
            ViewBag.Roles = userRoleList;
              





            return View("Index", results);
        }
    }
}