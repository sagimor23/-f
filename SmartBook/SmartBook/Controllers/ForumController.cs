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

namespace SmartBook.Controllers
{
    public class ForumController : Controller
    {
        private SmartBookWebLogic dbLogic = new SmartBookWebLogic();
        private ApplicationDbLogic applicationContext = new ApplicationDbLogic();


        // GET: Comment
        public ActionResult GetAllComments()
        {
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }
            if (isParentUser())
            {
                ViewBag.isParent = "true";
            }

            var comments = dbLogic.GetAllComments().OrderBy(a => a.CommentId);



            return View(comments);
        }

        // GET: Comment/Details/id
        public ActionResult GetCommentById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment Comment = dbLogic.GetCommentById((int)id);
            if (Comment == null)
            {
                return HttpNotFound();
            }
            return View(Comment);
        }


        // GET: Comment/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,UserName,CommentText,CommentData")] Comment comment)
        {
            comment.CommentDate = DateTime.Now;

            if (ModelState.IsValid)
            {
               
                dbLogic.AddComment(comment);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllComments");
            }

            return View(comment);
        }


        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = dbLogic.GetCommentById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            Comment comment = dbLogic.GetCommentById(id);
            dbLogic.DeleteComment(comment);
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllComments");
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = dbLogic.GetCommentById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,UserName,CommentText,CommentData")] Comment comment)
        {

            if (ModelState.IsValid)
            {
                comment.CommentDate = DateTime.Now;
                dbLogic.UpdateComment(comment);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllComments");
            }
            return View(comment);
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

        public Boolean isParentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Parent")
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