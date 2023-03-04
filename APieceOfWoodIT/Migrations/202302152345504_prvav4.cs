namespace APieceOfWoodIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prvav4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tmps",
                c => new
                    {
                        tmpId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tmpId)
                .ForeignKey("dbo.Products", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tmps", "Id", "dbo.Products");
            DropIndex("dbo.Tmps", new[] { "Id" });
            DropTable("dbo.Tmps");
        }
    }
}
