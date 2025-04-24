﻿namespace BooklyProjectAcunmedya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        CoverImageUrl = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountRate = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Review = c.Int(nullable: false),
                        IsOnSale = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.BookCategories",
                c => new
                    {
                        BookCategoryId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookCategoryId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhotoGalleries",
                c => new
                    {
                        PhotoGalleryId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        IsShown = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoGalleryId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Commment = c.String(),
                        Review = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BookCategories", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.BookCategories", new[] { "BookId" });
            DropIndex("dbo.BookCategories", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.Services");
            DropTable("dbo.PhotoGalleries");
            DropTable("dbo.Banners");
            DropTable("dbo.Categories");
            DropTable("dbo.BookCategories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
