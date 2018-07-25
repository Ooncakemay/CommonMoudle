using System.Web.Mvc;

namespace CommonMoudle.Areas.ReportingService
{
    public class ReportingServiceAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ReportingService";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ReportingService_default",
                "ReportingService/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
