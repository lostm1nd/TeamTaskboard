using System.Web;
using System.Web.Optimization;

namespace TeamTaskboard.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterStyles(bundles);

            RegisterScipts(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                      "~/Content/bootstrap.paper.css"));

            bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
                      "~/Content/bootstrap-datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/mycss").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendoui").Include(
                      "~/Content/kendoui/kendo.common.min.css",
                      "~/Content/kendoui/kendo.common-bootstrap.min.css",
                      "~/Content/kendoui/kendo.flat.min.css"));
        }

        private static void RegisterScipts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                      "~/Scripts/Chart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepickerjs").Include(
                      "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendoui").Include(
                      "~/Scripts/kendoui/kendo.all.min.js",
                      "~/Scripts/kendoui/kendo.aspnetmvc.min.js"));
        }
    }
}
