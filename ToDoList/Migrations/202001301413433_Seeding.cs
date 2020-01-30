namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeding : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PriorityTypes (Name) VALUES ('Low')");
            Sql("INSERT INTO PriorityTypes (Name) VALUES ('Medium')");
            Sql("INSERT INTO PriorityTypes (Name) VALUES ('High')");


        }
        
        public override void Down()
        {
        }
    }
}



