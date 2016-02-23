using System.Web;
using System.Web.Optimization;

// HACK: //!++ temp(?) support for Bundles in T4MVC...
// http://t4mvc.codeplex.com/discussions/399205
// http://t4mvc.codeplex.com/documentation (search for Bundle)
namespace Links
{
    public static partial class Bundles
    {
        public static partial class Script
        {
            public static readonly string all = "~/bundles/all";
            public static readonly string jquery = "~/bundles/jquery";
            public static readonly string jqueryval = "~/bundles/jqueryval";
            public static readonly string modernizr = "~/bundles/modernizr";
            public static readonly string bootstrap = "~/bundles/bootstrap";
            public static readonly string datatabes = "~/bundles/datatables";
            public static readonly string datepicker = "~/bundles/datepicker";
            public static readonly string codeprettifier = "~/bundles/googlecodeprettifier";
            public static readonly string ckeditor = "~/bundles/ckeditor";
            public static readonly string hyperslackers = "~/bundles/hyperslackers";
            public static readonly string dropzone = "~/bundles/dropzone";


            //public static read-only string jqueryui = "~/Scripts/jqueryui";
            //public static read-only string jqueryall = "~/Scripts/jqueryall";
            //public static read-only string jquerymigrate = "~/Scripts/jquerymigrate";
        }

        public static partial class Style
        {
            public static readonly string all_css = "~/Content/All/css";
            public static readonly string site_css = "~/Content/Site/css";
            public static readonly string content_fontawesome_css = "~/Content/FontAwesome/css";
            public static readonly string content_datatables_css = "~/Content/DataTables/css";
            public static readonly string content_datepicker_css = "~/Content/DatePicker/css";
            public static readonly string content_codeprettify_css = "~/Content/CodePrettify/css";
            public static readonly string content_dropzone_css = "~/Content/DropZone/css";
            //public static read-only string themes_base_css = "~/content/themes/base/jquery";
        }
    }
}

namespace HyperSlackers.Bootstrap.Demo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // bundles.IgnoreList.Clear(); // did not fix scripts not working on stage (see below)

            bundles.Add(new ScriptBundle(Links.Bundles.Script.all).Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/ckeditor/ckeditor.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/DataTables-1.10.1/jquery.dataTables.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/bootstrap.typeahead.js",
                "~/Scripts/Prettify/run_prettify.js",
                "~/Scripts/ckeditor/adapters/jquery.js",
                "~/Scripts/hyperslackers.bootstrap.js",
                "~/Scripts/dropzone/dropzone.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.jquery).Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.jqueryval).Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(Links.Bundles.Script.modernizr).Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.bootstrap).Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/bootstrap.typeahead.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.datatabes).Include(
                //"~/Scripts/DataTables-1.9.4/media/js/jquery.js",
                "~/Scripts/DataTables-1.10.1/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.datepicker).Include(
                "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.codeprettifier).Include(
                "~/Scripts/Prettify/run_prettify.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.ckeditor).Include(
                "~/Scripts/ckeditor/ckeditor.js",
                "~/Scripts/ckeditor/adapters/jquery.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.hyperslackers).Include(
                "~/Scripts/hyperslackers.bootstrap.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Script.dropzone).Include(
                "~/Scripts/dropzone/dropzone.js"));



            bundles.Add(new StyleBundle(Links.Bundles.Style.all_css).Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                //"~/Content/DataTables-1.10.1/css/jquery.dataTables.css",
                "~/Content/DataTables/css/dataTables.bootstrap.css",
                //"~/Content/DataTables/css/jquery.dataTables.css",
                //"~/Content/DataTables/css/jquery.dataTables_themeroller.css",
                "~/Content/bootstrap-datepicker3.css",
                "~/Content/Prettify/prettify.css",
                "~/Scripts/dropzone/css/basic.css",
                "~/Scripts/dropzone/css/dropzone.css",
                "~/Content/hyperslackers-bootstrap3.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle(Links.Bundles.Style.site_css).Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle(Links.Bundles.Style.content_fontawesome_css).Include(
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle(Links.Bundles.Style.content_datatables_css).Include(
                "~/Content/DataTables-1.10.0/css/jquery.dataTables.css",
                "~/Content/DataTables-1.10.0/css/jquery.dataTables_themeroller.css",
                "~/Content/DataTables-1.10.0/css/demo_table.css")); // TODO: should we use this or not?

            bundles.Add(new StyleBundle(Links.Bundles.Style.content_datepicker_css).Include(
                //"~/Content/bootstrap-datepicker.css",
                "~/Content/bootstrap-datepicker3.css"));

            bundles.Add(new StyleBundle(Links.Bundles.Style.content_codeprettify_css).Include(
                "~/Content/Prettify/prettify.css"));

            bundles.Add(new StyleBundle(Links.Bundles.Style.content_dropzone_css).Include(
                "~/Scripts/dropzone/css/basic.css",
                "~/Scripts/dropzone/css/dropzone.css"));

            BundleTable.EnableOptimizations = false;  // turned off to see if stage server works now...
        }
    }
}
