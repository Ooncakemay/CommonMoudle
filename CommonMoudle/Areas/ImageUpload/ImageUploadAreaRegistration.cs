using System.Web.Mvc;

namespace CommonMoudle.Areas.ImageUpload
{
    public class ImageUploadAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ImageUpload";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ImageUpload_default",
                "ImageUpload/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
