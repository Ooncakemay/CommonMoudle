using System.Web.Mvc;

namespace CommonMoudle.Areas.loading
{
    public class loadingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "loading";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "loading_default",
                "loading/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
