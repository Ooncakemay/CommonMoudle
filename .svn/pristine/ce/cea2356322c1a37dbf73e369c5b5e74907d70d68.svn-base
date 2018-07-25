using System.Web.Mvc;

namespace CommonMoudle.Areas.PopUp
{
    public class PopUpAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PopUp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PopUp_default",
                "PopUp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
