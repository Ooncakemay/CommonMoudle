using System.Web.Mvc;

namespace CommonMoudle.Areas.GetIP
{
    public class GetIPAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GetIP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GetIP_default",
                "GetIP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
