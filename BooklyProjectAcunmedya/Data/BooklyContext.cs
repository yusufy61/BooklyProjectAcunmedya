﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Data
{
    public class BooklyContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}