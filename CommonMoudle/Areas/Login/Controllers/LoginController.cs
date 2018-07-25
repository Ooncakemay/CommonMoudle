using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonMoudle.MailHunter;
using System.Configuration;
using CommonMoudle.Areas.Login.Models;
using NLog;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace CommonMoudle.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        //
        // GET: /Login/Login/
        /// <summary>
        /// 說明頁
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登入頁面
        /// </summary>
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }
        /// <summary>
        /// 忘記密碼
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgetPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
            return View();
        } // ForgetPassword()
        //Login Submit
        public ActionResult LoginSubmit(String Account, String Password)
        {
            SE_MemberModel objLoginModle = LoginHelper.GetLoginInfo(Account);
            String status = "";
            if (objLoginModle != null)
            {
                String strCookieID = System.Guid.NewGuid().ToString("D");
                //UserData

                Log_MemberAccessSysModel accessLog = new Log_MemberAccessSysModel();
                accessLog.strMemberID = objLoginModle.strMemberID;
                accessLog.strIP = Request.ServerVariables["REMOTE_ADDR"];   // Get IP Address
                accessLog.strCookieID = strCookieID;
                accessLog.strType = "Login";
                if (!objLoginModle.strPassword.Equals(Password))
                {
                    accessLog.ysnSuccess = false;
                    LoginHelper.InsertLogMemberAccessSys(accessLog);
                    status = "WrongPassword";
                    return Json(new { status = status }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (!objLoginModle.ysnActive)
                    {
                        // notActive
                        accessLog.ysnSuccess = false;
                        LoginHelper.InsertLogMemberAccessSys(accessLog);
                        status = "notActive";
                        return Json(new { status = status }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (!objLoginModle.ysnActivate)
                        {
                            // notActivate
                            accessLog.ysnSuccess = false;
                            LoginHelper.InsertLogMemberAccessSys(accessLog);
                            status = "notActivate";
                            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Do Login
                            //1.登入
                            doLogin(objLoginModle, strCookieID);
                            // ok
                            accessLog.ysnSuccess = true;
                            LoginHelper.InsertLogMemberAccessSys(accessLog);
                            String LastUrl = "";
                            if (Session["LastUrl"] != null)
                            {
                                LastUrl = Session["LastUrl"].ToString();
                                Session["LastUrl"] = null;
                            }
                            status = "Success";
                            return Json(new { status = status, LastUrl = LastUrl }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            else
            {
                status = "NoAccount";
                return Json(new { status = status }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="accessLog">access log model</param>
        public void doLogin(SE_MemberModel member, String strCookieID)
        {
            LoginModel loginInfo = new LoginModel();
            loginInfo.strMemberID = member.strMemberID;
            loginInfo.strName = member.strName;
            loginInfo.strCookieID = strCookieID;


            FormsAuthenticationTicket Ticket;
            String UserData = new JavaScriptSerializer().Serialize(loginInfo);

            //建立 Ticket，資料30分鐘過期(記得把Cookie到期時間參數放Web.config)
            Ticket = new FormsAuthenticationTicket(1, loginInfo.strMemberID, DateTime.Now, DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["CookieTime"])), false, UserData, FormsAuthentication.FormsCookiePath);

            //資料加密
            string HashTicket = FormsAuthentication.Encrypt(Ticket);

            //建立 Cookie
            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);

            Response.Cookies.Add(UserCookie);
        } // Login()


        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsIdentity id = (FormsIdentity)User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                LoginModel loginInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginModel>(ticket.UserData);
                Log_MemberAccessSysModel accessLog = LoginHelper.GetLogMemberAccessSys(loginInfo.strCookieID);
                accessLog.strType = "Logout";
                accessLog.ysnSuccess = true;
                LoginHelper.InsertLogMemberAccessSys(accessLog);

                //登出
                FormsAuthentication.SignOut();
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }
        /// <summary>
        /// 檢查會員是否已註冊 (for jQuery validate)
        /// </summary>
        /// <param name="strEMail">email</param>
        /// <returns></returns>
        public JsonResult Exist_Validate(String strEMail)
        {
            SE_MemberModel member = LoginHelper.GetMemberByEmail(strEMail);

            if (String.IsNullOrEmpty(member.strMemberID))
            {
                return Json("此會員帳號(E-Mail)尚未註冊，請先進行註冊，謝謝！", JsonRequestBehavior.AllowGet);
            } // if: no exist
            else if (!member.ysnActive)
            {
                return Json("您的會員會籍已失效，若仍想繼續享有會員權益，請重新進行註冊成為新會員，謝謝您", JsonRequestBehavior.AllowGet);
            } // else if: not active
            else if (!member.ysnActivate)
            {
                return Json("帳號尚未開通，請先進行開通後再登入，謝謝！", JsonRequestBehavior.AllowGet);
            } // else if: not activate
            else if (!String.IsNullOrEmpty(member.strFacebookID))
            {
                return Json("此會員帳號(E-Mail)為Facebook帳號，請至Facebook查詢，謝謝！", JsonRequestBehavior.AllowGet);
            } // else if: is facebook 
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            } // else: verified ok
        } // Exist_Validate()

        /// <summary>
        /// Submit: forget password
        /// </summary>
        /// <param name="strEMail"></param>
        /// <returns></returns>
        public ActionResult ForgetPasswordSubmit(String strEMail)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            SE_MemberModel member = LoginHelper.GetMemberByEmail(strEMail);
            LoginHelper.InsertLogMember(member.strMemberID, "U");
            if (!String.IsNullOrEmpty(member.strFacebookID))
            {
                return Json("facebook", JsonRequestBehavior.AllowGet);
            }
            else
            {
                MailModel mail = new MailModel();

                mail.MailTo = member.strEMail;
                mail.MailFrom = "no-reply@lrp.com.tw";
                mail.MailFromName = "理膚寶水-敏感肌膚美好生活會員小組";
                mail.MessageSubject = member.strName + "你好，理膚寶水-敏感肌膚美好生活會員密碼通知信";

                if (SendPasswordMail(mail, member.strName, member.strPassword))
                {
                    LoginHelper.InsertLogEMailSend(member.strMemberID, member.strEMail);

                    return Json("done", JsonRequestBehavior.AllowGet);
                } // if
                else
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                } // else
            } // else
        } // ForgetPasswordSubmit()

        /// <summary>
        /// Send mail: password
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean SendPasswordMail(MailModel mail, String name, String password)
        {
            string project_category_code = ConfigurationManager.AppSettings["ProjectCategoryCode"];

            string mailTo = mail.MailTo;
            string mailToName = name;
            string WebDomain = ConfigurationManager.AppSettings["WebDomain"];
            string mailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            string mailFromName = ConfigurationManager.AppSettings["EmailFromName"];
            string subject = name + "你好，理膚寶水-敏感肌膚美好生活會員密碼通知信";
            string content = " <div style=\"width: 665px\">"+
            "<div style=\"padding-bottom:10px; font-size: small\">  </div>"+
            "<div style=\"font-size: medium\"> "+
            " 親愛的"+name+"您好，<br /><br />"+
            "以下為您透過《理膚寶水-敏感肌膚美好生活》中「忘記密碼」功能所查詢的密碼。<br />"+
            "您設定的會員密碼為" + password + "<br /><br /></div> " +
            "<div style=\"font-size: small\"><br /> "+
            "<div style=\"color: gray;\">"+
            "此信件為系統發出信件，請勿直接回覆，感謝您的配合。謝謝！<br />" +
            "如果您有任何問題，歡迎聯絡我們或撥打客服電話，將有專人為您服務<br />" +
            "理膚寶水-敏感肌膚美好生活：<a href=\"http://www.lrp.com.tw\">www.lrp.com.tw</a><br /></div>" +
            "會員服務中心：0800-257-899</div></div>";



            // 寄信Function
            try
            {
                SendNowSoapClient objAPIService = new SendNowSoapClient();
                Boolean bResult = objAPIService.SendToOne(project_category_code, mailToName, mailTo, mailFromName, mailFrom, subject, content);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }//End SendVerifyMail
    }
}
