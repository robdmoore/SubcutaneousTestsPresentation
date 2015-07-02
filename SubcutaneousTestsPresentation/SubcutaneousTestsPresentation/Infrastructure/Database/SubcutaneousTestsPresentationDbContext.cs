using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using SubcutaneousTestsPresentation.Infrastructure.Config;
using SubcutaneousTestsPresentation.Domain.Users;
using SubcutaneousTestsPresentation.Migrations;

namespace SubcutaneousTestsPresentation.Infrastructure.Database
{
    public class SubcutaneousTestsPresentationDbContext : DbContext
    {
        static SubcutaneousTestsPresentationDbContext()
        {
            // Set initialiser in static constructor so that it's only set once per process
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<SubcutaneousTestsPresentationDbContext, Configuration>(true));
        }

        /// <summary>
        /// Constructor to allow Add-Migration to work in Package Manager Console
        /// </summary>
        public SubcutaneousTestsPresentationDbContext() : base("SubcutaneousTestsPresentation") {}

        public SubcutaneousTestsPresentationDbContext(SqlConnectionString connectionString) : base(connectionString.Value) {}

        public SubcutaneousTestsPresentationDbContext(DbConnection connection) : base(connection, false) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<ForeignKeyNamingConvention>();
        }

        public DbSet<User> Users { get; set; }
    }

    public class DatabaseConfiguration : DbConfiguration
    {
        public static bool UseAzureExecutionStrategy = true;

        public DatabaseConfiguration()
        {
            if (UseAzureExecutionStrategy)
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}