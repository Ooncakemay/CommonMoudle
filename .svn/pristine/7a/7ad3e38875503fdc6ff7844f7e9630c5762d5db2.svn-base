using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.CitySelect.Models;

namespace CommonMoudle.Areas.CitySelect.Controllers
{
    public class CitySelectController : Controller
    {

        /// <summary>
        /// 說明頁
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 城市下拉選單
        /// </summary>
        public ActionResult CitySelect()
        {           
            return View();
        }


        /// <summary>
        /// 取得城市清單
        /// </summary>
        public ActionResult CityList()
        {
            List<CityModel> ListCityModel = new List<CityModel>();
            ListCityModel = CitySelectHelper.InitCity();
            return View(ListCityModel);
        }

        /// <summary>
        /// 取得對應所選城市的區域清單
        /// </summary>
        public ActionResult AreaList(int intCityCode)
        {
            List<AreaModel> ListAreaModel = new List<AreaModel>();
            ListAreaModel = CitySelectHelper.GetAreasByCityCode(intCityCode);

            return View(ListAreaModel);
        }


    }
}
