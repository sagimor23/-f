using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBook.Controllers;
using SmartBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmartBook.Tests.Controllers
{
    [TestClass]

    public class UnitTestsControllerTest
    {
        [TestMethod]
        public void UnitTestIndex()
        {
            
            UnitTestsController objUnitTestController = new UnitTestsController();

            
            ViewResult objViewResult = objUnitTestController.Index() as ViewResult;

            
            Assert.AreEqual("Index", objViewResult.ViewName);

        }

        [TestMethod]
        private List<Picture> GetTestSessions()
        {
            var sessions = new List<Picture>();
            sessions.Add(new Picture()
            {

                PictureId = 1,
                PictureName = "Test One"
            });
            sessions.Add(new Picture()
            {

                PictureId = 2,
                PictureName = "Test Two"
            });
            return sessions;
        }
        [TestMethod]
        private List<Book> GetBookSessions()
        {
            var sessions = new List<Book>();
            sessions.Add(new Book()
            {
               
                
               BookId = 1,
               BookUrl="testurl",
               Number_Of_Pages=10,
               BookName="test",
               PictureId=1,
               YearOfPublish=1990,
               Summary="bloblo",
               WriterName="idan"               
               
            });
            sessions.Add(new Book()
            {

                BookId = 2,
                BookUrl = "testurl2",
                Number_Of_Pages = 10,
                BookName = "test2",
                PictureId = 2,
                YearOfPublish = 1992,
                Summary = "bloblo2",
                WriterName = "idan2"
            });
            return sessions;
        }
        [TestMethod]
        private List<Review> GetReviewSessions()
        {
            var sessions = new List<Review>();
            sessions.Add(new Review()
            {


                BookId = 1,
                UserName = "IDAN",
                ReviewDate = DateTime.Now,
                ReviewId=1,
                ReviewRating=1,
                ReviewText="bloblo"
               
            });
            sessions.Add(new Review()
            {

                BookId = 2,
                UserName = "IDAN2",
                ReviewDate = DateTime.Now,
                ReviewId = 2,
                ReviewRating = 2,
                ReviewText = "bloblo2"
                    
            });
            return sessions;   
        }


    }
}
