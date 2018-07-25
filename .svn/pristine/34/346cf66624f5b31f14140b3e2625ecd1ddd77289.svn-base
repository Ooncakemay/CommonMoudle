using System.Web.Mvc;

namespace CommonMoudle.Areas.ckeditor
{
    public class ckeditorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ckeditor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ckeditor_default",
                "ckeditor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
