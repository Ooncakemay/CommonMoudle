using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.MultipleSelect.Models;

namespace CommonMoudle.Areas.MultipleSelect.Controllers
{
    public class MultipleSelectController : Controller
    {
        /// <summary>
        /// 說明頁
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 城市多選下拉選單
        /// </summary>
        public ActionResult MultipleSelect()
        {
            List<CityModel> ListCityModel = new List<CityModel>();
            ListCityModel = MultipleSelectHelper.InitCity();
            return View(ListCityModel);
        }
    }
}
