namespace APieceOfWoodIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        Price = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Tmps",
                c => new
                    {
                        TmpId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TmpId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tmps", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Tmps", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tmps", new[] { "ProductId" });
            DropIndex("dbo.Tmps", new[] { "Id" });
            DropTable("dbo.Tmps");
            DropTable("dbo.Products");
        }
    }
}
