using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using System.Data.SqlClient;
using com.telexpress.Data.DA;
using System.Data;

namespace CommonMoudle.Areas.Register.Models
{
    public class RegisterHelper
    {
        private static String sqlXmlFileName = "SQLXML\\Register.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能

        #region 輸入資料檢查(信箱、姓名+手機)
        /// <summary>
        /// 檢查信箱是否已被註冊
        /// </summary>
        /// <param name="strEMail">信箱</param>
        /// <returns>回傳是否已存在該信箱</returns>
        public static bool CheckMailExisted(String strEMail)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strEMail", strEMail));
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            try
            {
                DataTable dt = da.RunQuery("CheckMailExisted", param.ToArray());
                if (dt.Rows.Count > 0)
                {//存在相同信箱
                    return true;
                }
                else
                {
                    return false;
                }
            } // try
            catch (Exception e)
            {
                logger.Error("CheckMailExisted " + e.Message);  // Error log
                return true;
            } // catch: all exception

        } // CheckMailExisted()


        /// <summary>
        /// 檢查姓名+手機是否已被註冊
        /// </summary>
        /// <param name="strEMail">姓名</param>
        /// <param name="strEMail">手機</param>
        /// <returns>回傳是否已存在相同的姓名+手機</returns>
        public static bool CheckNameMobileExisted(String strName, String strMobile)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strName", strName));
            param.Add(new SqlParameter("@strMobile", strMobile));
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            try
            {
                DataTable dt = da.RunQuery("CheckNameMobileExisted", param.ToArray());
                if (dt.Rows.Count > 0)
                {//存在相同的姓名+手機
                    return true;
                }
                else
                {
                    return false;
                }
            } // try
            catch (Exception e)
            {
                logger.Error("CheckNameMobileExisted " + e.Message);  // Error log
                return true;
            } // catch: all exception

        } // CheckNameMobileExisted()
        #endregion

        #region 登錄新會員資料
        /// <summary>
        /// 將註冊資料新增進SE_Member
        /// </summary>
        /// <param name="objJoinMember">註冊資料</param>
        /// <returns>新會員之編號&驗證碼</returns>
        public static string InsertNewMember(JoinMemberModel objJoinMember)
        {
            string strMemberID = "";//新會員之客戶代碼
            string ysnActivate = "";//新會員之驗證碼

            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            DataTable dt = new DataTable();

            param.Add(new SqlParameter("@strEMail", objJoinMember.strEMail));
            param.Add(new SqlParameter("@strPassword", objJoinMember.strPassword));
            param.Add(new SqlParameter("@strName", objJoinMember.strName));
            param.Add(new SqlParameter("@strMobile", objJoinMember.strMobile));
            param.Add(new SqlParameter("@dtmBirth", objJoinMember.dtmBirth));
            param.Add(new SqlParameter("@strCity", objJoinMember.strCity));//此為城市編號
            param.Add(new SqlParameter("@intZipCode", objJoinMember.intZipCode));
            param.Add(new SqlParameter("@strAddress", objJoinMember.strAddress));
            
            try
            {
                dt = da.RunQuery("InsertNewMember", param.ToArray());
                if ((dt.Rows[0][0]).ToString() == "Repeat") 
                { 
                    return "Repeat"; 
                }
                else
                {
                strMemberID = (dt.Rows[0][0]).ToString();
                ysnActivate = (dt.Rows[0][1]).ToString();
                }
            }
            catch (Exception e)
            {
                logger.Error("InsertNewMember " + e.Message);  // Error log
            } // catch: all exception

            return strMemberID + '&' + ysnActivate;
        }//End InsertNewMember

        /// <summary>
        /// 插入Log_Member
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <param name="strLogType">異動類別</param>
        /// <param name="strLogWHO">異動者</param>
        public static void InsertLogMember(string strMemberID, string strLogType, string strLogWHO)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess(sqlXmlFileName, true);

            param.Add(new SqlParameter("@strMemberID", strMemberID));
            param.Add(new SqlParameter("@strLogType", strLogType));
            param.Add(new SqlParameter("@strLogWHO", strLogWHO));

            try
            {
                da.RunNonQuery("InsertLogMember", param.ToArray());
            }
            catch (Exception e)
            {
                logger.Error("InsertLogMember " + e.Message);  // Error log
            } // catch: all exception

        }//InsertLogMember
        #endregion

        #region 驗證信
        /// <summary>
        /// 檢查Log_EmailSent表格中是否有該會員編號
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <returns>是否有該會員之寄送驗證信紀錄</returns>
        public static bool CheckLogEmailSentExisted(string strMemberID)
        {
            bool Existed = false;
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@strMemberID", strMemberID));

            try
            {
                DataTable dt = da.RunQuery("GetLogEMailSend", param.ToArray());
                if (dt.Rows.Count > 0) { Existed = true; }

            }
            catch (Exception e)
            {
                logger.Error("CheckLogEmailSentExisted " + e.Message);  // Error log
            }
            return Existed;
        }//CheckLogEmailSendExisted

        /// <summary>
        /// 新增一筆資料到Log_EmailSent中
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <param name="strEMAIL">信箱</param>
        public static void InsertLogEmailSent(string strMemberID, string strEMAIL)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strMemberID", strMemberID));
            param.Add(new SqlParameter("@strEMAIL", strEMAIL));
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            int insert_checker = 0;

            try
            {
                insert_checker = da.RunNonQuery("InsertLogEmailSent", param.ToArray());
            } // try
            catch (Exception e)
            {
                logger.Error("InsertLogEmailSent " + e.Message);  // Error log
            } // catch: all exception

        }//CheckLogEmailSendExisted

        /// <summary>
        /// 更新Log_EmailSent
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <param name="AddCount">增加寄送次數</param>
        /// <param name="ChangeActivated">是否更新為已驗證(是=1，否=0)</param>
        public static void UpdateLogEmailSend(string strMemberID, int AddCount, int ChangeActivated)
        {
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@strMemberID", strMemberID));
            param.Add(new SqlParameter("@AddCount", AddCount));
            param.Add(new SqlParameter("@ChangeActivated", ChangeActivated));


            try
            {
                da.RunNonQuery("UpdateLogEmailSend", param.ToArray());
            }
            catch (Exception e)
            {
                logger.Error("UpdateLogEmailSend " + e.Message);
            }

        }//CheckLogEmailSendExisted


        #endregion

        #region 會籍開通驗證

        /// <summary>
        /// 以會員編號取得與開通驗證相關之會員資料
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <returns>會員編號、信箱、姓名、是否已開通、驗證碼、會籍、會籍是否生效</returns>
        public static VerifyMemberModel GetVerifyDataByID(string strMemberID)
        {
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            VerifyMemberModel MemberData = null;

            param.Add(new SqlParameter("@strMemberID", strMemberID));
            try
            {
                DataTable dt = da.RunQuery("GetVerifyDataByID", param.ToArray());

                if (dt.Rows.Count > 0)
                {
                    MemberData = (from p in dt.Select()
                                  select new VerifyMemberModel()
                                  {
                                      strMemberID = p["strMemberID"].ToString(),
                                      strEMail = p["strEMail"].ToString(),
                                      strName = p["strName"].ToString(),
                                      ysnActivate = bool.Parse(p["ysnActivate"].ToString()),
                                      strActivateCode = p["strActivateCode"].ToString(),
                                      strMemberType = p["strMemberType"].ToString(),
                                      ysnActive = bool.Parse(p["ysnActive"].ToString())
                                  }).First();                    

                }

            }
            catch (Exception e)
            {
                logger.Error("GetVerifyDataByID " + e.Message);
            }
            return MemberData;
        }//GetVerifyDataByID


        /// <summary>
        /// 以信箱取得與開通驗證相關之會員資料
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <returns>會員編號、信箱、姓名、是否已開通、驗證碼、會籍、會籍是否生效</returns>
        public static VerifyMemberModel GetVerifyDataByEmail(string strEMail)
        {
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            VerifyMemberModel MemberData = null;

            param.Add(new SqlParameter("@strEMail", strEMail));
            try
            {
                DataTable dt = da.RunQuery("GetVerifyDataByEmail", param.ToArray());

                if (dt.Rows.Count > 0)
                {
                    MemberData = (from p in dt.Select()
                                  select new VerifyMemberModel()
                                  {
                                      strMemberID = p["strMemberID"].ToString(),
                                      strEMail = p["strEMail"].ToString(),
                                      strName = p["strName"].ToString(),
                                      ysnActivate = bool.Parse(p["ysnActivate"].ToString()),
                                      strActivateCode = p["strActivateCode"].ToString(),
                                      strMemberType = p["strMemberType"].ToString(),
                                      ysnActive = bool.Parse(p["ysnActive"].ToString())
                                  }).First();

                }

            }
            catch (Exception e)
            {
                logger.Error("GetVerifyDataByEmail " + e.Message);
            }
            return MemberData;
        }//GetVerifyDataByEmail

        /// <summary>
        /// 更新會員主檔為已開通
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        public static void ActivateMember(string strMemberID)
        {
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strMemberID", strMemberID));
            try
            { 
                da.RunNonQuery("ActivateMember",param.ToArray());
            }
            catch(Exception e)
            {
                logger.Error("ActivateMember " + e.Message);
            }

        }//ActivateMember

        /// <summary>
        /// 新增初始會籍歷程
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        public static void NewMemberLifeCycle(string strMemberID)
        { 
            DataAccess da = new DataAccess(sqlXmlFileName, true);
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@strMemberID", strMemberID));
            try
            {
                da.RunNonQuery("NewMemberLifeCycle", param.ToArray());
            }
            catch (Exception e)
            {
                logger.Error("NewMemberLifeCycle " + e.Message);
            }
        }//NewMemberLifeCycle




        #endregion
    }
}