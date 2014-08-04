using System.Web.Optimization;
using FileUpload.Infrastructure;

namespace FileUpload.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/bundles/jquery").Include(
                                                                  "~/Scripts/Kendo/jquery.min.js",
                                                                  "~/Scripts/jquery.validate.min.js",
                                                                  "~/Scripts/jquery.validate.unobtrusive.min.js",
                                                                  "~/Scripts/globalize/globalize.js",
                                                                  "~/Scripts/globalize/cultures/globalize.cultures.js",
                                                                  "~/Scripts/globalize/cultures/globalize.culture.bg - BG.js");
            bundle.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(bundle);

            var kendoBundle = new ScriptBundle("~/bundles/kendo").Include(
                                                                      "~/Scripts/Kendo/kendo.all.min.js", // or kendo.all.min.js if you want to use Kendo UI Web and Kendo UI DataViz
                                                                      "~/Scripts/Kendo/kendo.aspnetmvc.min.js",
                                                                      "~/Scripts/Kendo/kendo.culture.bg-BG.min.js",
                                                                      "~/Scripts/Kendo/kendo.culture.bg.min.js");
            kendoBundle.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(kendoBundle);

            // The Kendo CSS bundle
            bundles.Add(new StyleBundle("~/Content/kendo/styles").Include(
                "~/Content/Kendo/kendo.common.min.css",
                "~/Content/Kendo/kendo.default.min.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css/styles").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));
            //// Set EnableOptimizations to false for debugging. For more information,
            //// visit http://go.microsoft.com/fwlink/?LinkId=301862
            ////BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/customscripts").Include(
                "~/Scripts/CustomScripts/AccountAdministrationIndex.js",
                "~/Scripts/CustomScripts/FileUploadIndex.js",
                "~/Scripts/CustomScripts/sendAntiForgery.js",
                "~/Scripts/CustomScripts/SetGlobalization.js"));

            bundles.IgnoreList.Clear();
        }
    }
}