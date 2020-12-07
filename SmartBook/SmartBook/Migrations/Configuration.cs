namespace SmartBook.Migrations
{
    using SmartBook.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using static System.Net.WebRequestMethods;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartBook.DAL.SmartBookWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartBook.DAL.SmartBookWebContext context)
        {

            List<Picture> pictures = new List<Picture>();
            pictures.Add(new Picture { PictureId = 1, PictureName = "http://3.bp.blogspot.com/-Z_Jfn1Jii4U/VIj-k0-og_I/AAAAAAAAF_k/AHnYQbbBvsg/s1600/ppt296F.pptm%2B%5B%D7%9E%D7%A9%D7%95%D7%97%D7%96%D7%A8%5D.jpg" });
            pictures.Add(new Picture { PictureId = 2, PictureName = "https://cdn.theatlantic.com/assets/media/img/mt/2016/05/FrogToadCover/square.jpg?1522793979" });
            pictures.Add(new Picture { PictureId = 3, PictureName = "https://images-na.ssl-images-amazon.com/images/I/91JxTWpeOKL.jpg" });
            pictures.Add(new Picture { PictureId = 4, PictureName = "https://i.ytimg.com/vi/f1r1rdxj33I/maxresdefault.jpg" });
            pictures.Add(new Picture { PictureId = 5, PictureName = "https://m.media-amazon.com/images/M/MV5BMzA0YWMwMTUtMTVhNC00NjRkLWE2ZTgtOWEzNjJhYzNiMTlkXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SY1000_CR0,0,668,1000_AL_.jpg" });
           

            context.Picture.AddRange(pictures);
            List<Book> movies = new List<Book>();
            Book m1 = new Book {PictureId = 2, BookId = 99,BookUrl= "https://cdn.flipsnack.com/widget/v2/widget.html?hash=ftk8wnkx2", Number_Of_Pages=10, BookName = "הצפרדע המוזרה", WriterName = "ג.ציפורוב", YearOfPublish = 2018, Summary = "הצטרפו לצפרדע המוזרה ולהרפתקאות שהיא עוברת בחייה" };
            movies.Add(m1);
            Book m2 = new Book { PictureId = 1, BookId = 4, BookUrl = "https://cdn.flipsnack.com/widget/v2/widget.html?hash=f19l69nt4", Number_Of_Pages = 10, BookName = "עורב צבי זאב", WriterName = "סיפור עממי", YearOfPublish = 2018, Summary = "פעם נפגשו שלושה ביער: עורב, זאב וצבי. הם החליטו. להתחבר, לחיות ביחד ולעזור זה לזה בשעת הצורך." };
            movies.Add(m2);
            Book m3 = new Book { PictureId = 3, BookId = 3, BookUrl = "https://cdn.flipsnack.com/widget/v2/widget.html?hash=fhm0oimcb", Number_Of_Pages = 10, BookName = "הקטר הקטן", WriterName = "ג.ציפורוב", YearOfPublish = 2018, Summary = "סיפור זה עוסק בחייו של קטר שהיה קצת שונה מכל השאר, הוא תמיד היה מאחר עד שהחליט להתבגר." };
            movies.Add(m3);
            Book m4 = new Book { PictureId = 4, BookId = 7, BookUrl = "https://cdn.flipsnack.com/widget/v2/widget.html?hash=ftnsgmjh6", Number_Of_Pages = 10, BookName = "הקטר הקטן", WriterName = "ג.ציפורוב", YearOfPublish = 2018, Summary = "עלילות החזיר והגמל , לכל אחד יש יתרון משלו , הצטרפו ללמידה מעניינת בשפה האנגלית של חברים אלו." };
            movies.Add(m4);
            context.Book.AddRange(movies);

            SaveChanges(context);
        }
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }

}
