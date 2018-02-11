using System.Web;
using System.Web.Optimization;

namespace CMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/lib").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/bootstrap.js",
            //            "~/Scripts/bootbox.js",
            //            "~/Scripts/respond.js",
            //            "~/Scripts/DataTables/jquery.dataTables.js",
            //            "~/Scripts/DataTables/datatables.bootstrap.js",
            //            "~/Scripts/jquery-ui-{version}.js",
            //            "~/Scripts/jquery-ui-timepicker-addon.js",
            //            "~/Scripts/toastr.js"        
            //    ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/datatables/css/dataTables.bootstrap.css",
            //          "~/Content/themes/base/jquery-ui.css",
            //          "~/Content/themes/base/datepicker.css",
            //          "~/Content/jquery-ui-timepicker-addon.css",
            //          "~/Content/toastr.css",
            //          "~/Content/site.css"));



            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/sbTheme/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/sbTheme/vendor/metisMenu/metisMenu.min.css",
                      "~/Content/sbTheme/dist/css/sb-admin-2.css",
                      "~/Content/sbTheme/vendor/morrisjs/morris.css",
                      "~/Content/sbTheme/vendor/font-awesome/css/font-awesome.min.css"));
           

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                       "~/Content/sbTheme/vendor/jquery/jquery.min.js",
                       "~/Content/sbTheme/vendor/bootstrap/js/bootstrap.min.js",
                       "~/Content/sbTheme/vendor/metisMenu/metisMenu.min.js",
                       "~/Content/sbTheme/vendor/raphael/raphael.min.js",
                       "~/Content/sbTheme/vendor/morrisjs/morris.min.js",
                       "~/Content/sbTheme/data/morris-data.js",
                       "~/Content/sbTheme/dist/js/sb-admin-2.min.js"));





        }
    }
}
