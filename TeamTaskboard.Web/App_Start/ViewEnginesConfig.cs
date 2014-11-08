namespace TeamTaskboard.Web
{
    using System.Web.Mvc;

    class ViewEnginesConfig
    {
        internal static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
