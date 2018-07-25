using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using com.telexpress.Data.DA;
using System.Data.SqlClient;
using System.Data;

namespace CommonMoudle.Areas.Login.Models
{
    public class LoginHelper
    {
        private static String sqlXmlFileName = "SQLXML\\Login.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能
      
        /// <summary>
        /// 取得 Member Access Sys Log
        /// </summary>
        public static Log_MemberAccessSysModel GetLogMemberAccessSys(String strCookieID)
        {
            Log_MemberAccessSysModel accessLog = new Log_MemberAccessSysModel();
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            param.Add(new SqlParameter("@strCookieID", strCookieID));

            try
            {
                DataTable dt = da.RunQuery("GetLogMemberAccessSys", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    accessLog = (from p in dt.Select()
                                 select new Log_MemberAccessSysModel()
                                 {
                                     strMemberID = p["strMemberID"].ToString(),
                                     strCookieID = p["strCookieID"].ToString(),
                                     dtmLogin = DateTime.Parse(p["dtmLogin"].ToString()),
                                     strType = p["strType"].ToString(),
                                     strIP = p["strIP"].ToString(),
                                     ysnSuccess = Convert.ToBoolean(p["ysnSuccess"].ToString())
                                 }).First();

                } // if has data
            } // try
            catch (Exception e)
            {
                logger.Error("GetLogMemberAccessSys " + e.Message);  // Error log
            } // catch: all exception

            return accessLog;
        }//End GetLogMemberAccessSys
        /// <summary>
        /// 新增 Member Access Sys Log
        /// </summary>
        public static Boolean InsertLogMemberAccessSys(Log_MemberAccessSysModel accessLog)
        {
            int insert_checker = 0;
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            param.Add(new SqlParameter("@strMemberID", accessLog.strMemberID));
            param.Add(new SqlParameter("@strType", accessLog.strType));
            param.Add(new SqlParameter("@ysnSuccess", accessLog.ysnSuccess));
            param.Add(new SqlParameter("@strIP", accessLog.strIP));
            param.Add(new SqlParameter("@strCookieID", accessLog.strCookieID));

            try
            {
                insert_checker = da.RunNonQuery("InsertLogMemberAccessSys", param.ToArray());
            }
            catch (Exception e)
            {
                logger.Error("InsertLogMemberAccessSys " + e.Message);  // Error log
            } // catch: all exception

            return insert_checker > 0;
        }//End InsertLogMemberAccessSys
        /// <summary>
        ///  取得登入者的帳密
        /// </summary>
        public static SE_MemberModel GetLoginInfo(string strEMail)
        {
            SE_MemberModel data = null;

            try
            {
                if (!String.IsNullOrEmpty(strEMail))
                {
                    DataAccess da = new DataAccess(sqlXmlFileName, true);
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@strEMail", strEMail));
                    DataTable dt = da.RunQuery("GetLoginInfo", param.ToArray());
                    data = (from p in dt.Select()
                            select new SE_MemberModel()
                            {
                                strMemberID = p["strMemberID"].ToString(),
                                strEMail = p["strEMail"].ToString(),
                                strPassword = p["strPassword"].ToString(),
                                strGender = p["strGender"].ToString(),
                                strName = p["strName"].ToString(),
                                strDisplayName = p["strName"].ToString(),
                                ysnActive = Convert.ToBoolean(p["ysnActive"].ToString()),
                                ysnActivate = Convert.ToBoolean(p["ysnActivate"].ToString())
                            }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetLoginInfo " + ex.Message);  // Error log
            } // catch: all exception

            return data;
        }
        /// <summary>
        /// 取得Member info by MemberID
        /// </summary>
        public static SE_MemberModel GetMemberByMemberID(String strMemberID)
        {
            SE_MemberModel member = new SE_MemberModel();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strMemberID", strMemberID));

            DataAccess da = new DataAccess(sqlXmlFileName, true);

            try
            {
                DataTable dt = da.RunQuery("GetMemberByMemberID", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    member = (from p in dt.Select()
                              select new SE_MemberModel()
                              {
                                  strContactID = p["strContactID"].ToString(),
                                  ysnPolicy = bool.Parse(p["ysnPolicy"].ToString()),
                                  strJoinTypeCode = p["strJoinTypeCode"].ToString(),
                                  strJoinListCode = p["strJoinListCode"].ToString(),
                                  strPicture = p["strPicture"].ToString(),
                                  strMemberType = p["strMemberType"].ToString(),
                                  dtmActivated = DateTime.Parse(p["dtmActivated"].ToString()),
                                  dtmExpired = DateTime.Parse(p["dtmExpired"].ToString()),
                                  dtmVIPDate = DateTime.Parse(p["dtmVIPDate"].ToString()),
                                  ysnDM = bool.Parse(p["ysnDM"].ToString()),
                                  ysnFax = bool.Parse(p["ysnFax"].ToString()),
                                  ysnEmail = bool.Parse(p["ysnEmail"].ToString()),
                                  ysnSMS = bool.Parse(p["ysnSMS"].ToString()),
                                  ysnTel = bool.Parse(p["ysnTel"].ToString()),
                                  strMemo = p["strMemo"].ToString(),
                                  dtmCreate = DateTime.Parse(p["dtmCreate"].ToString()),
                                  strWHO = p["strWHO"].ToString(),
                                  dtmUpdate = DateTime.Parse(p["dtmUpdate"].ToString()),
                                  intSeqNo = Convert.ToInt32(p["intSeqNo"]),
                                  strMemberID = p["strMemberID"].ToString(),
                                  strFacebookID = p["strFacebookID"].ToString(),
                                  strEMail = p["strEMail"].ToString(),
                                  strPassword = p["strPassword"].ToString(),
                                  strName = p["strName"].ToString(),
                                  strDisplayName = p["strDisplayName"].ToString(),
                                  strMobile = p["strMobile"].ToString(),
                                  strPhoneCity = p["strPhoneCity"].ToString(),
                                  strPhone = p["strPhone"].ToString(),
                                  dtmBirth = DateTime.Parse(p["dtmBirth"].ToString()),
                                  strGender = p["strGender"].ToString(),
                                  intZipCode = Convert.ToInt32(p["intZipCode"]),
                                  strCity = p["strCity"].ToString(),
                                  strZone = p["strZone"].ToString(),
                                  strAddress = p["strAddress"].ToString(),
                                  strActivateCode = p["strActivateCode"].ToString(),
                                  ysnActivate = bool.Parse(p["ysnActivate"].ToString()),
                                  ysnActive = bool.Parse(p["ysnActive"].ToString())
                              }).First();
                } // if: has data
            } // try
            catch (Exception e)
            {
                logger.Error("GetMemberByMemberID " + e.Message);  // Error log
            } // catch: all exception

            return member;
        } // GetMemberByMemberID()
        /// <summary>
        /// 取得Member info by EMail
        /// </summary>
        public static SE_MemberModel GetMemberByEmail(String strEMail)
        {
            SE_MemberModel member = new SE_MemberModel();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strEMail", strEMail));

            DataAccess da = new DataAccess(sqlXmlFileName, true);

            try
            {
                DataTable dt = da.RunQuery("GetMemberByEmail", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    member = (from p in dt.Select()
                              select new SE_MemberModel()
                              {
                                  strMemberID = p["strMemberID"].ToString(),
                                  strFacebookID = p["strFacebookID"].ToString(),
                                  strEMail = p["strEMail"].ToString(),
                                  strPassword = p["strPassword"].ToString(),
                                  strName = p["strName"].ToString(),
                                  strDisplayName = p["strDisplayName"].ToString(),
                                  strMobile = p["strMobile"].ToString(),
                                  strPhoneCity = p["strPhoneCity"].ToString(),
                                  strPhone = p["strPhone"].ToString(),
                                  dtmBirth = DateTime.Parse(p["dtmBirth"].ToString()),
                                  strGender = p["strGender"].ToString(),
                                  intZipCode = Convert.ToInt32(p["intZipCode"]),
                                  strCity = p["strCity"].ToString(),
                                  strZone = p["strZone"].ToString(),
                                  strAddress = p["strAddress"].ToString(),
                                  strActivateCode = p["strActivateCode"].ToString(),
                                  ysnActivate = bool.Parse(p["ysnActivate"].ToString()),
                                  ysnActive = bool.Parse(p["ysnActive"].ToString())
                              }).First();
                } // if: has data
            } // try
            catch (Exception e)
            {
                logger.Error("GetMemberByEmail " + e.Message);  // Error log
            } // catch: all exception

            return member;
        } // GetMemberByEMail()
        /// <summary>
        /// 新增log member
        /// </summary>
        /// <param name="memberID">member id</param>
        /// <param name="logType">log type</param>
        /// <returns></returns>
        public static Boolean InsertLogMember(String memberID, String logType)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            param.Add(new SqlParameter("@strMemberID", memberID));
            param.Add(new SqlParameter("@strLogType", logType));
            int insert_checker = 0;

            try
            {
                insert_checker = da.RunNonQuery("InsertLogMember", param.ToArray());
            } // try
            catch (Exception e)
            {
                logger.Error("InsertLogMember " + e.Message);  // Error log
            } // catch: all exception

            return insert_checker > 0;
        } // InsertLogMember()
        /// <summary>
        /// 新增email send log
        /// </summary>
        /// <param name="strMemberID">member id</param>
        /// <returns></returns>
        public static Boolean InsertLogEMailSend(String strMemberID, String strEMAIL)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strMemberID", strMemberID));
            param.Add(new SqlParameter("@strEMAIL", strEMAIL));
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            int insert_checker = 0;

            try
            {
                insert_checker = da.RunNonQuery("InsertLogEMailSend", param.ToArray());
            } // try
            catch (Exception e)
            {
                logger.Error("InsertLogEMailSend " + e.Message);  // Error log
            } // catch: all exception

            return insert_checker > 0;
        }
    }
}