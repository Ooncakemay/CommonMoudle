using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.Langue.Models;

namespace CommonMoudle.Areas.Langue.Controllers
{
    public class LangueController : Controller
    {
       /// <summary>
       /// 說明頁
       /// </summary>
       /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 語系顯示
        /// </summary>
        /// <returns></returns>
        public ActionResult Langue()
        {
            List<LangueModel> List = new List<LangueModel>();
            List = LangueHelper.GetLanguages();
            return View(List);
        }
    }
}
