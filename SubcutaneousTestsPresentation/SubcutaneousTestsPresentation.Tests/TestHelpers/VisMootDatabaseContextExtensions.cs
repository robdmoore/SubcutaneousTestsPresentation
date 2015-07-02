using System.Collections.Generic;
using System.Threading.Tasks;
using SubcutaneousTestsPresentation.Domain.Users;
using SubcutaneousTestsPresentation.Infrastructure.Database;
using SubcutaneousTestsPresentation.Tests.TestHelpers.Builders;
using TestStack.Dossier.Lists;

namespace SubcutaneousTestsPresentation.Tests.TestHelpers
{
    public static class SubcutaneousTestsPresentationDatabaseContextExtensions
    {
        public static async Task<User> SaveAsync(this SubcutaneousTestsPresentationDbContext context, UserBuilder builder)
        {
            var user = builder.Build();
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public static async Task<IList<User>> SaveAsync(this SubcutaneousTestsPresentationDbContext context, ListBuilder<User, UserBuilder> builder)
        {
            var users = builder.BuildList();
            context.Users.AddRange(users);
            await context.SaveChangesAsync();
            return users;
        }
    }
}
