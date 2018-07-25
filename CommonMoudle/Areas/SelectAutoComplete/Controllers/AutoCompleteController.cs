using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.SelectAutoComplete.Models;

namespace CommonMoudle.Areas.SelectAutoComplete.Controllers
{
    public class AutoCompleteController : Controller
    {
        //
        // GET: /SelectAutoComplete/AutoComplete/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 下拉選單自動完成範例頁
        /// </summary>
        /// <returns></returns>
        public ActionResult AutoComplete()
        {

            return View();
        }
        /// <summary>
        /// 商品名稱下拉選單
        /// </summary>
        public ActionResult GetItemNumber()
        {
            List<Item> items = new List<Item>();
            items = AutoCompleteHelper.GetItemNumberList();
            return Json(items);
        }
    }
}
