using System.Web.Mvc;

namespace CommonMoudle.Areas.MultipleSelect
{
    public class MultipleSelectAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MultipleSelect";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MultipleSelect_default",
                "MultipleSelect/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
