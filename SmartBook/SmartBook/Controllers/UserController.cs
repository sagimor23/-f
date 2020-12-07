using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartBook.DAL;
using SmartBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.ViewModels;

namespace SmartBook.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbLogic applicationContext = new ApplicationDbLogic();



        public ActionResult GetAllUsers()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        
            var users = applicationContext.GetAllUsers();



            return View(users);


        }





        public ActionResult Delete(string id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityUser iUser = applicationContext.GetUserById(id);
            if (iUser == null)
            {
                return HttpNotFound();
            }
            return View(iUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }
            ApplicationUser iUser = applicationContext.GetUserById(id);
            applicationContext.DeleteUser(iUser);
            applicationContext.SaveChanges();
            return RedirectToAction("GetAllUsers");
        }

        public ActionResult Edit(string id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleViewModel urvm = new UserRoleViewModel();
            ApplicationUser iUser = applicationContext.GetUserById(id);
            if (iUser == null)
            {
                return HttpNotFound();
            }
            urvm.Email = iUser.Email;
            urvm.UserName = iUser.UserName;
            urvm.Id = iUser.Id;
            urvm.RoleId = iUser.Roles.FirstOrDefault().RoleId;
            ViewBag.RoleId = new SelectList(applicationContext.GetAllRoles(), "Id", "Name", urvm.RoleId);

            return View(urvm);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,RoleId")] UserRoleViewModel userRole)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                ApplicationUser iUser = applicationContext.GetUserById(userRole.Id);
                iUser.UserName = userRole.UserName;
                iUser.Email = userRole.Email;
                iUser.Roles.Clear();
                IdentityUserRole iUserRole = new IdentityUserRole();
                iUserRole.RoleId = userRole.RoleId;
                iUserRole.UserId = userRole.Id;
                iUser.Roles.Add(iUserRole);
                applicationContext.UpdateUser(iUser);
                applicationContext.SaveChanges();


                return RedirectToAction("GetAllUsers");
            }
            ViewBag.RoleId = new SelectList(applicationContext.GetAllRoles(), "Id", "Name", userRole.RoleId);
            return View(userRole);
        }





        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}