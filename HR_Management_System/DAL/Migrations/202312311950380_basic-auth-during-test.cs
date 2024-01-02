namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicauthduringtest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserJobTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        JobCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCategories", t => t.JobCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.JobCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserJobTables", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserJobTables", "JobCategoryID", "dbo.JobCategories");
            DropIndex("dbo.UserJobTables", new[] { "JobCategoryID" });
            DropIndex("dbo.UserJobTables", new[] { "UserID" });
            DropTable("dbo.UserJobTables");
        }
    }
}
