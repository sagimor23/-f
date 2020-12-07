using SmartBook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace SmartBook.DAL
{
    public class SmartBookWebContext: IdentityDbContext
    {
        

     
            public SmartBookWebContext() : base("SmartBookContext") { }
            public DbSet<Book> Book { get; set; }
            public DbSet<Review> Review { get; set; }
            public DbSet<Comment> Forum { get; set; }
            public DbSet<Picture> Picture { get; set; }
            public DbSet<UserBookVisits> UserBookVisits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }



            //public System.Data.Entity.DbSet<Website.ViewModels.MovieDetails> MovieDetails { get; set; }
        }
    }

