using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using com.telexpress.Data.DA;
using NLog;

namespace CommonMoudle.Areas.MultipleSelect.Models
{
    public class MultipleSelectHelper
    {

        private static String sqlXmlFileName = "SQLXML\\MultipleSelect.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能

        /// <summary>
        /// 初始化城市列表
        /// </summary>
        public static List<CityModel> InitCity()
        {
            List<CityModel> listCM = new List<CityModel>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            try
            {
                DataTable dt = da.RunQuery("InitCity");
                if (dt.Rows.Count > 0)
                {
                    listCM = (from p in dt.Select()
                              select new CityModel
                              {
                                  intCityCode = Int32.Parse(p["intCityCode"].ToString()),
                                  strCity = p["strCity"].ToString()
                              }).ToList();

                    return listCM;
                } // If has data
            } // Try run query: InitCity
            catch (Exception e)
            {
                logger.Error("InitCity " + e.Message);  // Error log
            } // Catch exception: all

            return default(List<CityModel>);
        } // List<CityModel> InitCity()
    }
}