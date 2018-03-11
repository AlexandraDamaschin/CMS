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
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/datatables.bootstrap.js",
                        "~/Scripts/Js/bootstrap.min.js",
                        //                        "~/Scripts/bootbox.js",
                        //                        "~/Scripts/respond.js",


                        "~/Scripts/toastr.js",
                        "~/Scripts/jquery-ui-timepicker-addon.js",
                        "~/Scripts/jquery-ui-timepicker-addon.min.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/jquery-ui.min.css",
                                             "~/Content/bootstrap.min.css",
                       //                       "~/Content/font-awesome.min.css",
                       "~/Content/font-awesome.css",
                        //                      "~/Content/sb-admin-2.min.css",
                        "~/Content/dataTables.bootstrap.min.css",

                        "~/Content/toastr.css",
                        "~/Content/datepicker.css",
                        "~/Content/jquery-ui-timepicker-addon.min.css",
                        "~/Content/site.css"
                       ));

        }
    }
}
