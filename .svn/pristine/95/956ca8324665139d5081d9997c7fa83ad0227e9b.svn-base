using System.Web.Mvc;

namespace CommonMoudle.Areas.CitySelect
{
    public class CitySelectAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CitySelect";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CitySelect_default",
                "CitySelect/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
