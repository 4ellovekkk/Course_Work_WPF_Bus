namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _time = c.String(),
                        _car = c.Int(nullable: false),
                        _how_often = c.String(),
                        Path_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voyages", t => t.Path_Id)
                .Index(t => t.Path_Id);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Start_point = c.String(),
                        End_point = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Route", "Path_Id", "dbo.Voyages");
            DropIndex("dbo.Route", new[] { "Path_Id" });
            DropTable("dbo.Voyages");
            DropTable("dbo.Route");
        }
    }
}
