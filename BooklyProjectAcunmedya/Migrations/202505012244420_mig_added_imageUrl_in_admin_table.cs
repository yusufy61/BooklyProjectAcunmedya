﻿namespace BooklyProjectAcunmedya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_imageUrl_in_admin_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ImageUrl");
        }
    }
}
