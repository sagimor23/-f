namespace SmartBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cancelWriter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "WriterName", "dbo.Writer");
            DropIndex("dbo.Book", new[] { "WriterName" });
            AddColumn("dbo.Book", "WriterName", c => c.String(nullable: false));
            DropColumn("dbo.Book", "WriterName");
            DropTable("dbo.Writer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Writer",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        WriterName = c.String(nullable: false, maxLength: 100),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WriterName);
            
            AddColumn("dbo.Book", "WriterName", c => c.Int(nullable: false));
            DropColumn("dbo.Book", "WriterName");
            CreateIndex("dbo.Book", "WriterName");
            AddForeignKey("dbo.Book", "WriterName", "dbo.Writer", "WriterName", cascadeDelete: true);
        }
    }
}
