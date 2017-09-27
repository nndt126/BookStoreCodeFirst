namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(storeType: "date"),
                        AuthorImage = c.String(nullable: false, maxLength: 250),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Prices = c.Int(),
                        Description = c.String(maxLength: 50),
                        Image = c.String(maxLength: 250),
                        IsDeleted = c.Boolean(),
                        AuthorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Author", t => t.AuthorID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PhanQuyen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        IDRole = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PhanQuyen", t => t.IDRole)
                .Index(t => t.IDRole);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "IDRole", "dbo.PhanQuyen");
            DropForeignKey("dbo.Book", "AuthorID", "dbo.Author");
            DropIndex("dbo.User", new[] { "IDRole" });
            DropIndex("dbo.Book", new[] { "AuthorID" });
            DropTable("dbo.User");
            DropTable("dbo.PhanQuyen");
            DropTable("dbo.Login");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
