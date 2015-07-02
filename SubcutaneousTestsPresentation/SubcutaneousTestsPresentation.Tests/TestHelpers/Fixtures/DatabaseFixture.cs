using System;
using System.Data.Common;
using System.IO;
using SubcutaneousTestsPresentation.Infrastructure.Config;
using SubcutaneousTestsPresentation.Infrastructure.Database;

namespace SubcutaneousTestsPresentation.Tests.TestHelpers.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public static SqlConnectionString SqlConnectionString = new SqlConnectionString
            {
                Value = "Data Source=(LocalDb)\\v11.0;Initial Catalog=SubcutaneousTestsPresentation.Tests;Integrated Security=True;AttachDBFilename=|DataDirectory|\\SubcutaneousTestsPresentation.Tests.mdf"
            };
        private readonly SubcutaneousTestsPresentationDbContext _parentContext;
        private readonly DbTransaction _transaction;

        static DatabaseFixture()
        {
            DatabaseConfiguration.UseAzureExecutionStrategy = false;
            var testPath = Path.GetDirectoryName(typeof(DatabaseFixture).Assembly.CodeBase.Replace("file:///", ""));
            AppDomain.CurrentDomain.SetData("DataDirectory", testPath); // For localdb connection string
            using (var migrationsContext = new SubcutaneousTestsPresentationDbContext())
            {
                migrationsContext.Database.Initialize(false);
            }
        }

        public DatabaseFixture()
        {
            _parentContext = new SubcutaneousTestsPresentationDbContext(SqlConnectionString);
            _parentContext.Database.Connection.Open();
            _transaction = _parentContext.Database.Connection.BeginTransaction();

            SeedDbContext = GetNewDbContext();
            WorkDbContext = GetNewDbContext();
            VerifyDbContext = GetNewDbContext();
        }

        public SubcutaneousTestsPresentationDbContext SeedDbContext { get; private set; }
        public SubcutaneousTestsPresentationDbContext WorkDbContext { get; private set; }
        public SubcutaneousTestsPresentationDbContext VerifyDbContext { get; private set; }

        private SubcutaneousTestsPresentationDbContext GetNewDbContext()
        {
            var context = new SubcutaneousTestsPresentationDbContext(_parentContext.Database.Connection);
            context.Database.UseTransaction(_transaction);
            return context;
        }

        public void Dispose()
        {
            SeedDbContext.Dispose();
            WorkDbContext.Dispose();
            VerifyDbContext.Dispose();
            _transaction.Dispose(); // Discard any inserts since we didn't commit
            _parentContext.Dispose();
        }
    }
}
