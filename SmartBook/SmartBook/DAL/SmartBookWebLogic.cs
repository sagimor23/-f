using SmartBook.Models;
using SmartBook.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Website.Models;
using Website.ViewModels;

namespace SmartBook.DAL
{
    public class SmartBookWebLogic
    {
        private SmartBookWebContext db = new SmartBookWebContext();


        public Book GetBookById(int Id)
        {
            return db.Book.Where(m => m.BookId == Id).FirstOrDefault();
        }

        public IQueryable<Book> GetAllBooks()
        {
            return db.Book;
        }

        public void UpdateBook(Book m)
        {
            db.Entry(m).State = EntityState.Modified;
        }
        public void AddBook(Book m)
        {
            db.Book.Add(m);
        }
        public void DeleteBook(Book m)
        {
            db.Book.Remove(m);
        }

       
        public double GetBookRating(int id)
        {
            double reviewSum = db.Review.Where(a => a.BookId == id).Sum(a => a.ReviewRating);
            double numOfRevies = db.Review.Where(a => a.BookId == id).Count();
            if (numOfRevies == 0)
                return 0;
            return reviewSum / numOfRevies;
        }
        public Review GetReviewById(int reviewId)
        {
            //Review rev = db.Review.Where(m => m.ReviewId == reviewId).Join(db.Book, r => r.BookId, m => m.BookId, (r, m) => new Review { Book = m, BookId = m.BookId, ReviewId = r.ReviewId, ReviewDate = r.ReviewDate, ReviewRating = r.ReviewRating, ReviewText = r.ReviewText, UserName = r.UserName }).FirstOrDefault();
            //return rev;
            return db.Review.Where(m => m.ReviewId == reviewId).FirstOrDefault();
        }

        public IQueryable<Review> GetAllReviews()
        {
            IQueryable<Review> rev = db.Review.Join(db.Book, r => r.BookId, m => m.BookId, (r, m) => new Review { Book = m, BookId = m.BookId, ReviewId = r.ReviewId, ReviewDate = r.ReviewDate, ReviewRating = r.ReviewRating, ReviewText = r.ReviewText, UserName = r.UserName });
            return rev;
            //return db.Review.Include(m => m.Book);
        }

        public void AddReview(Review r)
        {
            db.Review.Add(r);
        }

        public void DeleteReview(Review r)
        {
            db.Review.Remove(r);
        }

        public IQueryable<Picture> GetAllPictures()
        {
            return db.Picture;
        }


        public Picture GetPictureById(int PictureId)
        {
            return db.Picture.Where(m => m.PictureId == PictureId).FirstOrDefault();
        }
        public void DeletePicture(Picture e)
        {
            db.Picture.Remove(e);
        }
        public void AddPicture(Picture e)
        {
            db.Picture.Add(e);
        }
        public void UpdatePicture(Picture e)
        {
            db.Entry(e).State = EntityState.Modified;
        }

        public Comment GetCommentById(int CommentId)
        {
            return db.Forum.Where(m => m.CommentId == CommentId).FirstOrDefault();

        }

        public IQueryable<Comment> GetAllComments()
        {
            return db.Forum;

        }

        public void AddComment(Comment r)
        {
            db.Forum.Add(r);
        }

        public void DeleteComment(Comment r)
        {
            db.Forum.Remove(r);
        }

        public void UpdateComment(Comment e)
        {
            db.Entry(e).State = EntityState.Modified;
        }

        public List<ReviewTracker> GetReviewsCountByMonthStatistic()
        {
            List<ReviewTracker> list = db.Review.GroupBy(r => new { r.ReviewDate.Year, r.ReviewDate.Month })
                .Select(g => new ReviewTracker
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    NumOfReviews = g.Count()
                }).ToList();
            return list;
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }



    }
}