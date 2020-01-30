namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriorityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Description = c.String(),
                        PriorityTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriorityTypes", t => t.PriorityTypeId, cascadeDelete: true)
                .Index(t => t.PriorityTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "PriorityTypeId", "dbo.PriorityTypes");
            DropIndex("dbo.ToDoes", new[] { "PriorityTypeId" });
            DropTable("dbo.ToDoes");
            DropTable("dbo.PriorityTypes");
        }
    }
}
