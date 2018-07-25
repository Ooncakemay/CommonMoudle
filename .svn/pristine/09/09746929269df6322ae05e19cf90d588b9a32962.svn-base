using System.Web.Mvc;

namespace CommonMoudle.Areas.AutoComplete
{
    public class AutoCompleteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AutoComplete";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AutoComplete_default",
                "AutoComplete/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
