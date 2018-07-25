using System.Web.Mvc;

namespace CommonMoudle.Areas.Langue
{
    public class LangueAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Langue";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Langue_default",
                "Langue/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
