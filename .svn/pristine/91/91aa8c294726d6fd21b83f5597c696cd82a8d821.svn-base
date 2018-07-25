using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.telexpress.Data.DA;
using System.Data;
using System.Data.SqlClient;
using NLog;

namespace CommonMoudle.Areas.ReportingService.Models
{
    public class ReportsHelper
    {
        private static String sqlXmlFileName = "SQLXML\\ReportingService.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能

        //財報-年區間選單
        public static List<SelectMenu> GetYear(string date, string table)
        {
            List<SelectMenu> objList = new List<SelectMenu>();

            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> parm = new List<SqlParameter>();

            try
            {
                parm.Add(new SqlParameter("@date", date));
                parm.Add(new SqlParameter("@table", table));
                DataTable dt = da.RunQuery("GetYear", parm.ToArray());

                if (dt.Rows.Count > 0)
                {
                    objList = (from p in dt.Select()
                               select new SelectMenu
                               {
                                   strSelectValue = p["year"].ToString(),
                                   strSelectName = p["year"].ToString(),
                               }).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error("GetYear " + e.Message);  // Error log
            }
            return objList;
        }
    }
}