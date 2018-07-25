using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.GetIP.Models;

namespace CommonMoudle.Areas.GetIP.Controllers
{
    public class GetIPController : Controller
    {
       
        /// <summary>
        /// 說明頁
        /// </summary>
        public ActionResult Index()
        {
            
            return View();
        }
        /// <summary>
        /// 取得IP位址
        /// </summary>
        /// <returns></returns>
        public ActionResult GetIP()
        {
            string strIP = GetIPHelper.GetLocalIP();
            ViewBag.strIP = strIP;
            return View();
        }
    }
}
