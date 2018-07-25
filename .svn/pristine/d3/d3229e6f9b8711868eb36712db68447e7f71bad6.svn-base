using System.Web.Mvc;

namespace CommonMoudle.Areas.SelectAutoComplete
{
    public class SelectAutoCompleteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SelectAutoComplete";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SelectAutoComplete_default",
                "SelectAutoComplete/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
