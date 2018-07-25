using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.Parameter.Models;

namespace CommonMoudle.Areas.Parameter.Controllers
{
    public class ParameterController : Controller
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
        /// 取得系統參數
        /// </summary>
        /// <returns></returns>
        public ActionResult Parameter()
        {
            //用取得首頁Title為範例
            //Classification = SYSTEM
            //ParamCode = IndexTitle
            ViewBag.ParamValue = ParameterHelper.GetSysParam("SYSTEM", "IndexTitle").strParamValue;
            ViewBag.ParamDesc = ParameterHelper.GetSysParam("SYSTEM", "IndexTitle").ParamDesc;
            return View();
        }
    }
}
