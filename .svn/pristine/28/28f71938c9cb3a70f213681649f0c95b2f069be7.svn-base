using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using com.telexpress.Data.DA;
using System.Data.SqlClient;
using NLog;

namespace CommonMoudle.Areas.AutoComplete.Models
{
    public class AutoCompleteHelper
    {
        private static String sqlXmlFileName = "SQLXML\\AutoComplete.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能
        /// <summary>
        /// 取得關鍵字搜尋結果
        /// </summary>
        /// <param name="keyword">關鍵字</param>
        /// <returns></returns>
        public static List<AutoCompleteModel> AutoSearch(String keyword)
        {
            List<AutoCompleteModel> obj = new List<AutoCompleteModel>();

            var dt = new DataTable();
            try
            {
                DataAccess da = new DataAccess(sqlXmlFileName, true);
                var param = new List<SqlParameter>();
                param.Add(new SqlParameter("@keyword", keyword));
                dt = da.RunQuery("AutoSearch", param);

                obj = (from p in dt.Select()
                       select new AutoCompleteModel
                       {
                           intSeqNo = Convert.ToInt32(p["intSeqNo"].ToString()),
                           strAddress = p["strAddress"].ToString(),
                           dtmUpdate = Convert.ToDateTime(p["dtmUpdate"].ToString()),
                       }).ToList();
            }
            catch (Exception ex)
            {
                logger.Error("CheckMailExisted " + ex.Message);  // Error log
            }
            return obj;
        }
    }
}