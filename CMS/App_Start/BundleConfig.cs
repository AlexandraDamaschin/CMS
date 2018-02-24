using System.Web;
using System.Web.Optimization;

namespace CMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/Js/bootstrap.min.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/datatables.bootstrap.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-timepicker-addon.js",
                        "~/Scripts/toastr.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/Css/sb-admin-2.min.css",
                      "~/Content/Css/dataTables.bootstrap.css",
                      "~/Content/Css/jquery-ui.min.css",
                      "~/Content/Css/datepicker.css",
                      "~/Content/Css/jquery-ui-timepicker-addon.min.css",
                      "~/Content/Css/toastr.min.css",
                      "~/Content/Css/site.css"
                       ));

        }
    }
}
