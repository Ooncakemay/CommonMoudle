using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.telexpress.Data.DA;
using System.Data.SqlClient;
using System.Data;
using NLog;

namespace CommonMoudle.Areas.ImageUpload.Models
{
    public class GiftHelper
    {
        private static String sqlXmlFileName = "SQLXML\\ImageUpload.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 取得BS_Profile的設定值
        /// </summary>
        /// <param name="strProfileID">strProfileID</param>
        /// <returns></returns>
        public static String GetProfileParm(String strProfileID)
        {
            String strProfileValue = "";
            DataAccess da = new DataAccess(sqlXmlFileName,true);
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>();
                parm.Add(new SqlParameter("@strProfileID", strProfileID));
                DataTable dt = da.RunQuery("GetProfileParm", parm.ToArray());
                if (dt.Rows.Count > 0)
                {
                    strProfileValue = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetProfileParm " + ex.Message);
            }
            return strProfileValue;
        }
    }
}