using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBook;
using SmartBook.Controllers;
using SmartBook.Models;


namespace SmartBook.Tests.Controllers
{

    [TestClass]

    public class HomeControllerTest

    {
        private readonly Localize test_localizer = new Localize();
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Books()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Books() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Picture()
        {

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
                Assert.IsNotNull(sessions);

            }
        }
        [TestMethod]
        public void Book()
        {


            {
                var sessions = new List<Book>();
                sessions.Add(new Book()
                {


                    BookId = 1,
                    BookUrl = "testurl",
                    Number_Of_Pages = 10,
                    BookName = "test",
                    PictureId = 1,
                    YearOfPublish = 1990,
                    Summary = "bloblo",
                    WriterName = "idan"

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
                Assert.IsNotNull(sessions);
            }
        }
             [TestMethod]
        public void Review()
        {

            
            {
                var sessions = new List<Review>();
                sessions.Add(new Review()
                {


                    BookId = 1,
                    UserName = "IDAN",
                    ReviewDate = DateTime.Now,
                    ReviewId = 1,
                    ReviewRating = 1,
                    ReviewText = "bloblo"

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
                Assert.IsNotNull(sessions);

            }
        }
            // Assert






        }
    }


