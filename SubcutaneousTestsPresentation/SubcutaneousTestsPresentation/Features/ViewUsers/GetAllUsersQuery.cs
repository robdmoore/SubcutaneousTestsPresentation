using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SubcutaneousTestsPresentation.Domain.Users;
using SubcutaneousTestsPresentation.Infrastructure.Database;
using SubcutaneousTestsPresentation.Infrastructure.Queries;

namespace SubcutaneousTestsPresentation.Features.ViewUsers
{
    public class GetAllUsersQuery : IQuery<IList<User>> {}

    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IList<User>>
    {
        private readonly SubcutaneousTestsPresentationDbContext _context;

        public GetAllUsersQueryHandler(SubcutaneousTestsPresentationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> QueryAsync(GetAllUsersQuery query)
        {
            return (await _context.Users.OrderBy(x => x.PersonalDetails.LastName).ToListAsync());
        }
    }
}