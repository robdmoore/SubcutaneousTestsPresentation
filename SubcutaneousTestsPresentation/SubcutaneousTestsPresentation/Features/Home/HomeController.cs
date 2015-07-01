using System.Web.Mvc;

namespace SubcutaneousTestsPresentation.Features.Home
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}