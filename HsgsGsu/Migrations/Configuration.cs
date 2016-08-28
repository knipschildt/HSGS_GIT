namespace HsgsGsu.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HsgsGsu.Models.GSUContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;            
        }

        protected override void Seed(HsgsGsu.Models.GSUContext context)
        {
           
        }
    }
}
