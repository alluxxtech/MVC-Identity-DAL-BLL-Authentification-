namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtablecategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.btlCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.btlCategories", t => t.ParentId)
                .Index(t => t.ParentId);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.btlCategories", "ParentId", "dbo.btlCategories");
            DropIndex("dbo.btlCategories", new[] { "ParentId" });
            DropTable("dbo.btlCategories");
        }
    }
}
