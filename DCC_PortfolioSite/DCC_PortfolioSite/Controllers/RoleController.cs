using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using DCC_PortfolioSite.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DCC_PortfolioSite.Controllers
{
    public class RoleController : Controller
    {

        ApplicationDbContext context;
        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        
        // GET: Role
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create(string name)
        {
            var Role = new IdentityRole();
            Role.Name = name;
            return View(Role);
        }



        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string name)
        {
            var Roles = context.Roles;
            var newRole = (from r in context.Roles
                          where
                          r.Id == name
                          select r).FirstOrDefault();
            
            return View(newRole);
        }



        [HttpPost]
        public ActionResult Delete(IdentityRole Role)
        {
            var Roles = context.Roles;

            var newRole = (from r in context.Roles
                           where
                           r.Id == Role.Name
                           select r).FirstOrDefault();
            context.Roles.Remove(newRole);
            context.SaveChanges();


            //foreach (IdentityRole item in Roles)
            //{
            //    if (item.Id == Role.Id)
            //    {
            //        context.Roles.Remove(item);
            //    }
            //}
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }

 // POST: /Users/Delete/5
[HttpPost, ActionName("DeleteUser")]
[ValidateAntiForgeryToken]
public async Task<ActionResult> DeleteConfirmed(string id)
{
  if (ModelState.IsValid)
  {
    if (id == null)
    {
      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    
    var user = await _userManager.FindByIdAsync(id);
    var logins = user.Logins;

    foreach (var login in logins.ToList())
    {
      await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
    }

    var rolesForUser = await _userManager.GetRolesAsync(id);

    if (rolesForUser.Count() > 0)
    {
      foreach (var item in rolesForUser.ToList())
      {
        // item should be the name of the role
        var result = await _userManager.RemoveFromRoleAsync(user.Id, item);
      }
    }

    await _userManager.DeleteAsync(user);

    return RedirectToAction("Index");
  }
  else
  {
    return View();
  }
}






    }
}