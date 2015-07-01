using System.Web.Mvc;

namespace SubcutaneousTestsPresentation.Views
{
    public class FeaturesViewEngine : RazorViewEngine
    {
        public FeaturesViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/Shared/{0}.cshtml"
            };

            MasterLocationFormats = ViewLocationFormats;
            PartialViewLocationFormats = ViewLocationFormats;
        }
    }
}