using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NLog;
using com.telexpress.Data.DA;
using System.Data.SqlClient;

namespace CommonMoudle.Areas.CitySelect.Models
{
    public class CitySelectHelper
    {
        private static String sqlXmlFileName = "SQLXML\\CitySelect.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能

        /// <summary>
        /// 初始化城市列表
        /// </summary>
        public static List<CityModel> InitCity()
        {
            List<CityModel> listCM = new List<CityModel>();
            DataAccess da = new DataAccess(sqlXmlFileName,true);

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




        /// <summary>
        /// 以被選擇的intCityCode產生對應的鄉鎮市區列表
        /// </summary>
        /// <param name="intCityCode">城市代碼</param>
        /// <returns>鄉鎮市區列表</returns>
        public static List<AreaModel> GetAreasByCityCode(int intCityCode)
        {
            List<AreaModel> listAM = new List<AreaModel>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@intCityCode", intCityCode));

            try
            {
                DataTable dt = da.RunQuery("GetAreasByCityCode", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    listAM = (from p in dt.Select()
                              select new AreaModel
                              {
                                  intZipCode = Int32.Parse(p["intZipCode"].ToString()),
                                  strArea = p["strArea"].ToString()
                              }).ToList();
                    return listAM;
                } // If has data
            } // Try run query: GetAreasByCityCode
            catch (Exception e)
            {
                logger.Error("GetAreasByCityCode " + e.Message);  // Error log
            } // Catch exception: all

            return default(List<AreaModel>);
        } // List<AreaModel> GetArea(intCityCode)




        /// <summary>
        /// 以郵遞區號獲得城市代碼
        /// </summary>
        public static int GetCityCodeByZipCode(int intZipCode)
        {
            int CityCode = 0;

            CityModel obj = new CityModel();
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@intZipCode", intZipCode));

            try
            {
                DataTable dt = da.RunQuery("GetCityCodeByZipCode", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    obj = (from p in dt.Select()
                           select new CityModel
                           {
                               intCityCode = Int32.Parse(p["intCityCode"].ToString()),
                               strCity = p["strCity"].ToString()
                           }).First();
                    CityCode = obj.intCityCode;
                } // If has data
            } // Try run query: GetAreasByCityCode
            catch (Exception e)
            {
                logger.Error("GetCityCodeByZipCode " + e.Message);  // Error log
            } // Catch exception: all

            return CityCode;
        } //CityCodeByZipCode()








        


    }
}