using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using System.Configuration;
using CommonMoudle.MailHunter;
using CommonMoudle.Areas.Register.Models;
using System.Web.Security;
using CommonMoudle.Models;

namespace CommonMoudle.Areas.Register.Controllers
{
    public class RegisterController : Controller
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        #region 頁面

        /// <summary>
        /// 說明頁
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 註冊頁面
        /// </summary>
        public ActionResult Register()
        {
            //若現在已為登入狀態則自動導至"首頁"
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        /// <summary>
        /// 感謝註冊頁面
        /// </summary>
        public ActionResult RegisterThanks()
        {
            return View();
        }
        
        /// <summary>
        /// 完成驗證頁面
        /// </summary>
        public ActionResult VerifyFinished()
        {            
            return View();
        }

        /// <summary>
        /// 重寄驗證信頁面
        /// </summary>
        public ActionResult ResendVerify()
        {
            return View();
        }


        #endregion

        #region 資料驗證階段
        /// <summary>
        /// 檢查輸入的資料是否已註冊
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="name">name</param>
        /// <param name="strMobile">mobile</param>
        /// <returns></returns>
        public ActionResult IsExistMember(String strEMail, String strName, String strMobile)
        {
            if (String.IsNullOrEmpty(strEMail))
            {
                if (RegisterHelper.CheckNameMobileExisted(strName, strMobile))
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                } // if exist
            } // by name and mobile
            else
            {
                if (RegisterHelper.CheckMailExisted(strEMail))
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                } // if exist
            } // by email

            return Json(false, JsonRequestBehavior.AllowGet);
        } // IsExistMember()



        /// <summary>
        /// 查詢E-mail是否已開通驗證碼
        /// </summary>
        /// <param name="inputEmail">信箱</param>
        /// <returns>是否存在此信箱、是否已開通、是否失效、會員驗證相關資料</returns>
        public ActionResult CheckEmail(String inputEmail)
        {
            Boolean Exist = false;
            Boolean Activate = false;
            Boolean Active = false;


            VerifyMemberModel objMember = RegisterHelper.GetVerifyDataByEmail(inputEmail);
           
            if (objMember == null)
            {
                return Json(new
                {
                    isExist = Exist,
                    isActivate = Activate,
                    isActive = Active,
                    strEMail = "NO",
                    strName = "NO",
                    strMemberID = "NO",
                    strActivateCode = "NO",
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Exist = true;
                Activate = objMember.ysnActivate;
                Active = objMember.ysnActive;

                return Json(new
                {
                    isExist = Exist,
                    isActivate = Activate,
                    isActive = Active,
                    strEMail = objMember.strEMail,
                    strName = objMember.strName,
                    strMemberID = objMember.strMemberID,
                    strActivateCode = objMember.strActivateCode
                }, JsonRequestBehavior.AllowGet);
            }

            

        }//End actGetMemberByEmail







        #endregion

        #region 登錄會員資料
        /// <summary>
        /// 將註冊資料新增進SE_Member與Log_Member並寄出驗證信
        /// </summary>
        public ActionResult actSubmitRegister(JoinMemberModel obj)
        {
            string response = RegisterHelper.InsertNewMember(obj);// 將註冊資料新增進SE_Member與Log_Member
            if (response == "Repeat")
            {
            return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
            string[] parameter = response.Split('&');
            string strMemberID = parameter[0];
            string strActivateCode = parameter[1];
            RegisterHelper.InsertLogMember(strMemberID, "I", "TECRM");

            //判斷Log_EmailSent表格中是否有該會員代碼(strMemberID)若不存在則新增一筆資料到Log_EmailSent中
            if (!RegisterHelper.CheckLogEmailSentExisted(strMemberID))
            {
                RegisterHelper.InsertLogEmailSent(strMemberID, obj.strEMail);
            }

            //寄出驗證信後，更新Log_EmailSent
            if (SendVerifyMail(obj.strEMail, obj.strName, strMemberID, strActivateCode))
            { RegisterHelper.UpdateLogEmailSend(strMemberID, 1, 0); }
            else
            { RegisterHelper.UpdateLogEmailSend(strMemberID, 0, 0); }

            return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 寄送驗證信


        /// <summary>
        /// 將送信紀錄新增進Log_Member並寄出驗證信
        /// </summary>
        /// <param name="email">信箱</param>
        /// <param name="name">姓名</param>
        /// <param name="strMemberID">會員編號</param>
        /// <param name="strActivateCode">驗證碼</param>
        /// <returns></returns>
        public ActionResult actSubmitResendEmail(String email, String name, String strMemberID, String strActivateCode)
        {
            //判斷Log_EmailSent表格中是否有該會員代碼(strMemberID)若不存在則新增一筆資料到Log_EmailSent中
            if (!RegisterHelper.CheckLogEmailSentExisted(strMemberID))
            {
                RegisterHelper.InsertLogEmailSent(strMemberID, email);
            }

            //寄出驗證信後，更新Log_EmailSent
            if (SendVerifyMail(email, name, strMemberID, strActivateCode))
            { RegisterHelper.UpdateLogEmailSend(strMemberID, 1, 0);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            { RegisterHelper.UpdateLogEmailSend(strMemberID, 0, 0);
                return Json(false, JsonRequestBehavior.AllowGet);
            }


        }//End actSubmitResendEmail
        
        /// <summary>
        /// 寄出驗證信
        /// </summary>
        /// <param name="email">信箱</param>
        /// <param name="name">收件者姓名</param>
        /// <param name="strMemberID">會員編號</param>
        /// <param name="strActivateCode">驗證碼</param>
        /// <returns>是否寄送成功</returns>
        public Boolean SendVerifyMail(String email, String name, String strMemberID, String strActivateCode)
        {
            string WebDomain = ConfigurationManager.AppSettings["WebDomain"];
            string project_category_code = ConfigurationManager.AppSettings["ProjectCategoryCode"];
            string toname = name;
            string toemail = email;
            string fromname = ConfigurationManager.AppSettings["EmailFromName"];
            string fromemail = ConfigurationManager.AppSettings["EmailFrom"];
            string subject = name + "你好，理膚寶水-敏感肌膚美好生活會員email驗證通知函";
            string content = string.Format("<div style=\"width: 665px\">" +
                                                "<div style=\"padding-bottom:10px; font-size: small\">" +
                                                "</div><div style=\"font-size: medium\">" +

                                                "親愛的" + name + " 您好，<br /><br />" +
                                                "歡迎您加入理膚寶水-敏感肌膚美好生活，為確認您的email帳號無誤。<br />" +                                                
                                                "請由此處完成您的會員帳號認證：<a href=\"" + WebDomain + "/Register/Register/RunFinishVerify?strMemberID=" + strMemberID + "&strActivateCode=" + strActivateCode + "\">請點選此處進行會員帳號啟用</a>。完成會員申請。<br />" +
                                                "若您並未進行註冊申請，請忽略本封郵件。謝謝！<br /><br />" +
                                                "若點選連結卻無法完成驗證程序時，請直接<a href=\"" + WebDomain + "/Register/ContactUs/\">聯絡我們</a>，將盡快為您處理！<br /><br />" +
                                                "理膚寶水-敏感肌膚美好生活會員小組<br />" +
                                                "敬上</div>" +
                                                "<div style=\"border-style: dashed; border-color: #000; border-width: 1px; border-left-width: 0px; border-right-width: 0px; padding: 10px 0px 10px 0px; margin: 10px 0px 10px 0px; font-size: small\">" +
                                                "歡迎您隨時登入理膚寶水-敏感肌膚美好生活查詢個人積點歷程及更多會員好禮兌換活動資訊。<br />" +
                                                "為了保障您的會員權益，請牢記您的網站登入帳號及密碼，並請勿告訴他人。</div>" +
                                                "<div style=\"font-size: small\"><br />" +
                                                "<div style=\"color: gray;\">" +
                                                "此信件為系統發出信件，請勿直接回覆，感謝您的配合。謝謝！<br />" +
                                                "如果您有任何問題，歡迎<a href=\"" + WebDomain + "/Register/ContactUs/\">聯絡我們</a>或撥打客服電話，將有專人為您服務<br />" +
                                                "理膚寶水-敏感肌膚美好生活：<a href=\""+WebDomain+"\">www.lrp.com.tw</a><br /></div>" +
                                                "會員服務中心：0800-257-889</div></div>");

            // 寄信Function
            try
            {
                SendNowSoapClient objAPIService = new SendNowSoapClient();
                Boolean bResult = objAPIService.SendToOne(project_category_code, toname, toemail, fromname, fromemail, subject, content);


                return true;
            }
            catch (Exception e)
            {
                logger.Error("SendVerifyMail " + e.Message);  // Error log
                return false;
            }
        }//End SendVerifyMail







        #endregion

        #region 開通驗證碼
        /// <summary>
        /// 完成驗證動作
        /// </summary>
        /// <param name="strMemberID">會員編號</param>
        /// <param name="strActivateCode">驗證碼</param>
        /// <returns>導至"完成驗證頁"</returns>
        public ActionResult RunFinishVerify(string strMemberID, string strActivateCode)
        {
            //若未取得會員資料，則導至首頁
            if (strMemberID == null || strActivateCode == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
            //載入該會員驗證相關資料
            VerifyMemberModel MemberData = RegisterHelper.GetVerifyDataByID(strMemberID);

            //若未取得會員資料，則導至首頁
            if (MemberData==null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
            //若該會員為未激活狀態，則進行激活。並新增SE_MemberLifeCycle
            if (MemberData.strActivateCode == strActivateCode && //驗證碼相符
                !MemberData.ysnActivate && //為未開通
                MemberData.strMemberType =="Guest" //會籍為未開通會員
                )
            {
                //更新會員主檔為已開通
                RegisterHelper.ActivateMember(strMemberID);
                //插入Log
                RegisterHelper.InsertLogMember(strMemberID,"U","TECRM");
                //新增初始會籍歷程
                RegisterHelper.NewMemberLifeCycle(strMemberID);
                //更新驗證信寄送Log為已開通驗證
                RegisterHelper.UpdateLogEmailSend(strMemberID, 0, 1);
                
                //完成開通驗證頁
                return RedirectToAction("VerifyFinished", "Register", new { area = "Register" });

            }
            else  //若該會員為已激活狀態則跳至首頁
            {                         
                return RedirectToAction("Index", "Home", new { area = "" });                   
            }
              
            
        }
        #endregion

    }
}
