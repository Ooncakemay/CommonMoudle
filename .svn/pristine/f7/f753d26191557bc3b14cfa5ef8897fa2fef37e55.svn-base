using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.Areas.ReportingService.Models;

namespace CommonMoudle.Areas.ReportingService.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /ReportingService/Reports/

        /// <summary>
        /// 說明頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        //年區間選單
        public ActionResult Year(string date, string table)
        {
            List<SelectMenu> Year = ReportsHelper.GetYear(date, table);
            return PartialView("SelectItem", Year);
        }

        //VIP宅配抵購劵
        public ActionResult SampleReport()
        {
            return View();
        }

    }
}
