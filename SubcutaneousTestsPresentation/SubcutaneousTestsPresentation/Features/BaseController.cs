using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SubcutaneousTestsPresentation.Domain;

namespace SubcutaneousTestsPresentation.Features
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Return true if the ModelState is valid and the specified delegate completed without throwing a ClientException
        /// </summary>
        /// <param name="action">The delegate which may or may not throw a ClientException</param>
        protected async Task<bool> ModelValidAndSuccess(Func<Task> action)
        {
            if (!ModelState.IsValid)
                return false;

            try
            {
                await action();
                return true;
            }
            catch (ClientException e)
            {
                var paramName = e.ParamName;
                // We ignore case, since ModelState errors are case-insensitive
                var isPropValid = e.ParamName != null
                    && (Request.Params.AllKeys.Any(x => x.Equals(e.ParamName, StringComparison.InvariantCultureIgnoreCase))
                        || Request.Files.AllKeys.Any(x => x.Equals(e.ParamName, StringComparison.InvariantCultureIgnoreCase)));

                if (!isPropValid && (
                    Request.Params.AllKeys.Any(x => x.EndsWith("." + e.ParamName, StringComparison.InvariantCultureIgnoreCase))
                    || Request.Files.AllKeys.Any(x => x.EndsWith("." + e.ParamName, StringComparison.InvariantCultureIgnoreCase))))
                {
                    isPropValid = true;
                    paramName = Request.Params.AllKeys.FirstOrDefault(x => x.EndsWith("." + e.ParamName, StringComparison.InvariantCultureIgnoreCase))
                        ?? Request.Files.AllKeys.First(x => x.EndsWith("." + e.ParamName, StringComparison.InvariantCultureIgnoreCase));
                }

                ModelState.AddModelError(isPropValid ? paramName : string.Empty, e.Message);
            }

            return false;
        }
    }
}