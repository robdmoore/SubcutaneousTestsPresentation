using System.Web.Optimization;

namespace SubcutaneousTestsPresentation
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Ignore("*.tests.js");

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                // jQuery
                "~/Scripts/jquery-{version}.js",
                // jQuery Unobtrusive Validate
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive.chameleon.js",
                "~/Scripts/jquery.validate.unobtrusive.twitterbootstrap.js",
                // foolproof validation
                "~/Scripts/mvcfoolproof.unobtrusive.js",
                // Bootstrap
                "~/Scripts/bootstrap.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/_css/bundled").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/chameleonforms-twitterbootstrap.css",
                "~/Content/css/site.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}