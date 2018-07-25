using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.AutoComplete.Models;

namespace CommonMoudle.Areas.AutoComplete.Controllers
{
    public class AutoCompleteController : Controller
    {
       
        /// <summary>
        /// 說明頁
        /// </summary>
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 關鍵字範例頁
        /// </summary>
        /// <returns></returns>
        public ActionResult AutoComplete()
        {
            
            return View();
        }
        /// <summary>
        /// 關鍵字搜尋
        /// </summary>
        /// <param name="keyword">關鍵字</param>
        /// <returns></returns>
        public ActionResult Keyword(String keyword)
        {
            List<AutoCompleteModel> obj = new List<AutoCompleteModel>();
            if (!String.IsNullOrEmpty(keyword))
            {
                ViewBag.keyword = keyword;
                String[] KeywordArr = keyword.Split(' ');
                obj = AutoCompleteHelper.AutoSearch(KeywordArr[0]);
                for (int i = 1; i < KeywordArr.Length; i++)
                {
                    obj = (from baseobj in obj
                           join joinobj in AutoCompleteHelper.AutoSearch(KeywordArr[i]) on baseobj.intSeqNo equals joinobj.intSeqNo
                           select baseobj).ToList();
                }
                ViewBag.searchcount = obj.Count;
                obj = obj.OrderByDescending(x => x.dtmUpdate).Take(30).ToList();
            }
            return View(obj);
        }
        /// <summary>
        /// 取得關鍵字搜尋
        /// </summary>
        public JsonResult GetGuide(String key)
        {
            List<AutoCompleteModel> List = AutoCompleteHelper.AutoSearch(key);
            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}
