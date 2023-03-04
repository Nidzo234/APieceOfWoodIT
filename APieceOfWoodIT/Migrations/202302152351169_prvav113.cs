namespace APieceOfWoodIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prvav113 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tmps", "Id", "dbo.Products");
            DropIndex("dbo.Tmps", new[] { "Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Tmps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tmps",
                c => new
                    {
                        tmpId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tmpId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        Price = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tmps", "Id");
            AddForeignKey("dbo.Tmps", "Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
