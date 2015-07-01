using System.Data.Entity.Migrations;

namespace SubcutaneousTestsPresentation.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Database.SubcutaneousTestsPresentationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infrastructure.Database.SubcutaneousTestsPresentationDbContext context)
        {
        }
    }
}
