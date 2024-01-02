namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobtables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobRequirments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        JobCategoryId = c.Int(nullable: false),
                        OrgID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCategories", t => t.JobCategoryId, cascadeDelete: true)
                .Index(t => t.JobCategoryId);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNo = c.String(),
                        Address = c.String(),
                        UploadFileName = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobRequirments", "JobCategoryId", "dbo.JobCategories");
            DropIndex("dbo.JobRequirments", new[] { "JobCategoryId" });
            DropTable("dbo.JobApplications");
            DropTable("dbo.JobRequirments");
        }
    }
}
