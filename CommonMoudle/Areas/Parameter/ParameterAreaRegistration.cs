using System.Web.Mvc;

namespace CommonMoudle.Areas.Parameter
{
    public class ParameterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Parameter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Parameter_default",
                "Parameter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
