namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicauth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserOrganizationTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);
            
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Users", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "PhoneNum", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Authorization_Id", c => c.Int());
            CreateIndex("dbo.Users", "Authorization_Id");
            AddForeignKey("dbo.Users", "Authorization_Id", "dbo.Authorizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserOrganizationTables", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserOrganizationTables", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.JobCategories", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Users", "Authorization_Id", "dbo.Authorizations");
            DropIndex("dbo.JobCategories", new[] { "OrganizationID" });
            DropIndex("dbo.UserOrganizationTables", new[] { "OrganizationID" });
            DropIndex("dbo.UserOrganizationTables", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "Authorization_Id" });
            DropColumn("dbo.Users", "Authorization_Id");
            DropColumn("dbo.Users", "PhoneNum");
            DropColumn("dbo.Users", "DOB");
            DropColumn("dbo.Users", "Gender");
            DropTable("dbo.JobCategories");
            DropTable("dbo.Organizations");
            DropTable("dbo.UserOrganizationTables");
            DropTable("dbo.Authorizations");
        }
    }
}
