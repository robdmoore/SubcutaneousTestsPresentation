using System.Threading.Tasks;
using System.Web.Mvc;
using SubcutaneousTestsPresentation.Infrastructure.Commands;

namespace SubcutaneousTestsPresentation.Features.UserRegistration
{
    public class UserRegistrationController : BaseController
    {
        private readonly ICommandExecutor _commandExecutor;

        public UserRegistrationController(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public ActionResult Index()
        {
            return View(new UserRegistrationViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserRegistrationViewModel vm)
        {
            var loginUrl = Url.Action("Index", "Home", null, Request.Url.Scheme);
            if (!await ModelValidAndSuccess(() => _commandExecutor.ExecuteAsync(vm.ToCommand(loginUrl))))
                return View(vm);

            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}