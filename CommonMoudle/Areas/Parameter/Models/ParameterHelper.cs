using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using com.telexpress.Data.DA;
using System.Data.SqlClient;
using System.Data;

namespace CommonMoudle.Areas.Parameter.Models
{
    public class ParameterHelper
    {
        private static String sqlXmlFileName = "SQLXML\\Parameter.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能
        /// <summary>
        /// 取得系統參數
        /// </summary>
        /// <param name="strClassification">Classification</param>
        /// <param name="strParamCode">ParamCode</param>
        /// <returns>SysParamModel</returns>
        public static SysParamModel GetSysParam(String strClassification, String strParamCode)
        {
            SysParamModel objSPM = new SysParamModel();
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strClassification", strClassification));
            param.Add(new SqlParameter("@strParamCode", strParamCode));

            try
            {
                DataTable dt = da.RunQuery("GetSysParam", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    objSPM = (from p in dt.Select()
                              select new SysParamModel
                              {
                                  strParamValue = p["ParamValue"].ToString(),
                                  ParamDesc = p["ParamDesc"].ToString()
                              }).First();
                } // If has data
            } // Try query: GetAreasByCityCode
            catch (Exception e)
            {
                logger.Error("GetSysParam " + e.Message);  // Error log
            } // Catch: all exception

            return objSPM;
        } // SysParamModel GetSysParam(String strClassification, String strParamCode)
    }
}