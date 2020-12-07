using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartBook.DAL;
using SmartBook.Models;

namespace SmartBook.Controllers
{
    public class PictureController : Controller
    {
        private SmartBookWebLogic dbLogic = new SmartBookWebLogic();

        // GET: Picture
        public ActionResult GetAllPictures()
        {
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }


            var picture = dbLogic.GetAllPictures().OrderBy(a => a.PictureId);



            return View(picture);
        }

        // GET: Picture/Details/5
        public ActionResult GetPictureById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = dbLogic.GetPictureById((int)id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureId,PictureName")] Picture picture)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddPicture(picture);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllPictures");
            }

            return View(picture);
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Book");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = dbLogic.GetPictureById((int)id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureId,PictureName")] Picture picture)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {

                dbLogic.UpdatePicture(picture);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllPictures");
            }
            return View(picture);
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = dbLogic.GetPictureById((int)id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            Picture picture = dbLogic.GetPictureById(id);
            dbLogic.DeletePicture(picture);
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllPictures");
        }

        protected override void Dispose(bool disposing)
        {
            dbLogic.Dispose(disposing);
            base.Dispose(disposing);
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
