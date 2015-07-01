using System.Threading.Tasks;
using System.Web.Mvc;
using SubcutaneousTestsPresentation.Infrastructure.Queries;

namespace SubcutaneousTestsPresentation.Features.ViewUsers
{
    public class ViewUsersController : BaseController
    {
        private readonly IQueryExecutor _queryExecutor;

        public ViewUsersController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _queryExecutor.QueryAsync(new GetAllUsersQuery());

            return View(users);
        }
    }
}