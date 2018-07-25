using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using com.telexpress.Data.DA;
using System.Data;

namespace CommonMoudle.Areas.Langue.Models
{
    public class LangueHelper
    {
        private static String sqlXmlFileName = "SQLXML\\langue.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能

        /// <summary>
        /// 取得語系列表
        /// </summary>
        public static List<LangueModel> GetLanguages()
        {
            List<LangueModel> list = new List<LangueModel>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            try
            {
                DataTable dt = da.RunQuery("GetLanguages");
                if (dt.Rows.Count > 0)
                {
                    list = (from p in dt.Select()
                              select new LangueModel
                              {
                                  LongLangCode = p["LongLangCode"].ToString(),
                                  ShortLangCode = p["ShortLangCode"].ToString(),
                                  NameCHT = p["NameCHT"].ToString(),
                                  NameENG = p["NameENG"].ToString()
                              }).ToList();

                    return list;
                } // If has data
            } // Try run query: GetLanguages
            catch (Exception e)
            {
                logger.Error("GetLanguages " + e.Message);  // Error log
            } // Catch exception: all

            return default(List<LangueModel>);
        } 
    }
}