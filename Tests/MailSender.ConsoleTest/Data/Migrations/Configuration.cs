namespace MailSender.ConsoleTest.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    // В консоли диспетчера пакетов NuGet: Enable-Migrations -MigrationsDirectory Data\Migrations
    internal sealed class Configuration : DbMigrationsConfiguration<SongsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(SongsDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
