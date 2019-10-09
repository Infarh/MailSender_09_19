namespace MailSender.ConsoleTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    // Add-Migration TrackStyleAdded -Verbose
    public partial class TrackStyleAdded : DbMigration
    {
        public override void Up()
        {                                      //c.Byte() -> c.Byte(defaultValue: 0)  - поменял сам
            AddColumn("dbo.Track", "Style", c => c.Byte(defaultValue: 0));

            //Sql("SQL-запрос");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Track", "Style");

            //Sql("SQL-запрос");
        }
    }
}
