using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.ImageUpload.Models;

namespace CommonMoudle.Areas.ImageUpload.Controllers
{
    public class ImageUploadController : Controller
    {

        //
        // GET: /ImageUpload/ImageUpload/

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 圖片上傳頁面
        /// </summary>
        /// 
        /// <returns></returns>
        public ActionResult Upload()
        {
         //   ProductMaitainModel ProductData = new ProductMaitainModel();
            //if (!String.IsNullOrEmpty(strProductID))
            //{
             // ViewBag.PictureID  = ImageUploadHelper.GetProductData();
            //}
            //ProductData.strProductID = strProductID;

            //取得圖片尺寸&限制大小
            ViewBag.Picture = ImageUploadHelper.GetProfileParm("Picture");
            //ViewBag.BackgroundPicture = ImageUploadHelper.GetProfileParm("BackgroundPicture");
            ViewBag.SizeLimit = ImageUploadHelper.GetProfileParm("SizeLimit");
            return View();
        }


        /// <summary>
        /// 上傳圖片
        /// </summary>
        
        /// <returns></returns>
        public ActionResult ImageUpload( String strProfileID)
        {
            //ViewBag.strProductID = strProductID;
            ViewBag.strProfileID = strProfileID;
            ViewBag.SizeLimit = ImageUploadHelper.GetProfileParm("SizeLimit");
            return View();
        }

    }
}
