using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonMoudle.Areas.ckeditor.Controllers
{
    public class ckeditorController : Controller
    {
        //
        // GET: /ckeditor/ckeditor/

        public ActionResult Index()
        {
            return View();
        }
        //HTML編輯器
        public ActionResult ckeditor()
        {
            return View();
        }
    }
}
