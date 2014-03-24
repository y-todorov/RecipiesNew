using System.Web.Optimization;

namespace RecipiesWebFormApp
{
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254726
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            BundleTable.EnableOptimizations = true;

            //bundles.Add(new ScriptBundle("~/bundles/modernizr", "http://ajax.aspnetcdn.com/ajax/modernizr/modernizr-2.0.6-development-only.js"));//.Include(

            //bundles.Add(new ScriptBundle("~/bundles/jquery", "http://cdn.kendostatic.com/2013.2.918/js/jquery.min.js"));//.Include(
            ////"~/Scripts/jquery-{version}.js"));

            ////bundles.Add(new ScriptBundle("~/bundles/kendo", "http://cdn.kendostatic.com/2013.2.918/js/jquery.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/kendoall", "http://cdn.kendostatic.com/2013.2.918/js/kendo.all.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/kendoaspnetmvc", "http://cdn.kendostatic.com/2013.2.918/js/kendo.aspnetmvc.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/kendoculture", "http://cdn.kendostatic.com/2013.2.918/js/cultures/kendo.culture.en-IE.min.js"));


            //bundles.Add(new ScriptBundle("~/bundles/js").Include(
            //            "~/Scripts/Bundles/*.js"));

            // this way no other request is made for the map file
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/WebEssentials/WebEssentialsJsBundle.min.js"));


            bundles.Add(new StyleBundle("~/Content/bundles/css")
                .Include("~/Content/Bundles/*.css")
                .Include("~/Content/Bundles/BlueOpal/*.png")
                .Include("~/Content/Bundles/BlueOpal/*.gif"))
                ;


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr", "http://ajax.aspnetcdn.com/ajax/modernizr/modernizr-2.0.6-development-only.js"));//.Include(
            //"~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}