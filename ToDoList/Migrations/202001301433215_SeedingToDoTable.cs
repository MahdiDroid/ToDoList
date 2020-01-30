namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingToDoTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ToDoes (Title,Date,IsDone,Description,PriorityTypeId) VALUES ('Shopping','2020-01-30',0,'Monthly shoping',10)");

        }

        public override void Down()
        {
        }
    }
}
