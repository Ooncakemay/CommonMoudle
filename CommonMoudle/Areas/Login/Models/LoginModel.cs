using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonMoudle.Areas.Login.Models
{
    public class LoginModel
    {
        /// <summary>
        /// 會員代碼
        /// </summary>
        public String strMemberID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public String strName { get; set; }

        /// <summary>
        /// Cookie id
        /// </summary>
        public String strCookieID { get; set; }
        /*
        /// <summary>
        /// 會員會籍是否為生效
        /// </summary>
        public Boolean ysnActive { get; set; }

        /// <summary>
        /// 帳號是否已開通
        /// </summary>
        public Boolean ysnActivate { get; set; }
         * 
        /// <summary>
        /// 帳號
        /// </summary> 
        public String strEMail { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public String strPassword { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public String strGender { get; set; }
        */
    }
    /// <summary>
    /// 寄件者及信件資訊
    /// </summary>
    public class MailModel
    {
        /// <summary>
        /// web.config裡面的Host值
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// web.config裡面的Port值
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 寄件者mail
        /// </summary>
        public string MailFrom { get; set; }

        /// <summary>
        /// 寄件者名稱
        /// </summary>
        public string MailFromName { get; set; }

        /// <summary>
        /// 收件者mail
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        /// 信件主旨
        /// </summary>
        public string MessageSubject { get; set; }

        /// <summary>
        /// 信件內容
        /// </summary>
        public string MessageBody { get; set; }
    }
    /// <summary>
    /// EMail發送設定檔
    /// </summary>
    public class EMailModel
    {
        /// <summary>
        /// EMail代碼
        /// </summary>
        public String strEMailID { get; set; }
        /// <summary>
        /// EMail主旨
        /// </summary>
        public String strEMail_Subject { get; set; }
        /// <summary>
        /// 寄件人
        /// </summary>
        public String strSender { get; set; }
        /// <summary>
        /// 寄件人郵件地址
        /// </summary>
        public String strSenderAddress { get; set; }
        /// <summary>
        /// EMail內容
        /// </summary>
        public String strEMail_Content { get; set; }
        /// <summary>
        /// 參數數量
        /// </summary>
        public int IntParameter { get; set; }
    }
    /// <summary>
    /// 會員個人資料主檔
    /// </summary>
    public class SE_MemberModel
    {
        public SE_MemberModel()
        {
            strMemberType = "";
        }
        /// <summary>
        /// 會員代碼
        /// </summary>
        public String strMemberID { get; set; }

        /// <summary>
        /// GDCRM對應客戶代碼
        /// </summary>
        public String strContactID { get; set; }

        /// <summary>
        /// E-Mail(帳號)
        /// </summary>
        public String strEMail { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public String strPassword { get; set; }

        /// <summary>
        /// 會員姓名
        /// </summary>
        public String strName { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        public String strMobile { get; set; }

        /// <summary>
        /// 市話號碼
        /// </summary>
        public String strPhone { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime dtmBirth { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public String strGender { get; set; }

        /// <summary>
        /// 縣市代碼
        /// </summary>
        public int intCityCode { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public int intZipCode { get; set; }

        /// <summary>
        /// 縣市
        /// </summary>
        public String strCity { get; set; }

        /// <summary>
        /// 區
        /// </summary>
        public String strZone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public String strAddress { get; set; }

        /// <summary>
        /// 是否同意會員條款
        /// </summary>
        public bool ysnPolicy { get; set; }

        /// <summary>
        /// 通路名單種類代碼
        /// </summary>
        public String strJoinTypeCode { get; set; }

        /// <summary>
        /// 通路名單來源代碼
        /// </summary>
        public String strJoinListCode { get; set; }

        /// <summary>
        /// 會員圖像
        /// </summary>
        public String strPicture { get; set; }

        /// <summary>
        /// 是否開通
        /// </summary>
        public bool ysnActivate { get; set; }

        /// <summary>
        /// 開通碼
        /// </summary>
        public String strActivateCode { get; set; }

        /// <summary>
        /// 會籍
        /// </summary>
        public String strMemberType { get; set; }

        /// <summary>
        /// 會籍狀態
        /// </summary>
        public bool ysnActive { get; set; }

        /// <summary>
        /// 會籍開始日
        /// </summary>
        public DateTime dtmActivated { get; set; }

        /// <summary>
        /// 會籍截止日
        /// </summary>
        public DateTime dtmExpired { get; set; }

        /// <summary>
        /// 第一次升等日
        /// </summary>
        public DateTime dtmVIPDate { get; set; }

        /// <summary>
        /// 是否願意收到郵寄溝通物
        /// </summary>
        public bool ysnDM { get; set; }

        /// <summary>
        /// 是否願意收到傳真溝通物
        /// </summary>
        public bool ysnFax { get; set; }

        /// <summary>
        /// 是否願意收到電子郵件溝通物
        /// </summary>
        public bool ysnEmail { get; set; }

        /// <summary>
        /// 是否願意收到簡訊溝通物
        /// </summary>
        public bool ysnSMS { get; set; }

        /// <summary>
        /// 是否停止聯繫(電話)
        /// </summary>
        public bool ysnTel { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public String strMemo { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime dtmCreate { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public String strWHO { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime dtmUpdate { get; set; }

        /// <summary>
        /// 流水號
        /// </summary>
        public int intSeqNo { get; set; }

        /// <summary>
        /// GD客戶名稱
        /// </summary>
        public String strDisplayName { get; set; }

        /// <summary>
        /// 市話號碼區碼
        /// </summary>
        public String strPhoneCity { get; set; }

        /// <summary>
        /// Facebook代碼
        /// </summary>
        public String strFacebookID { get; set; }
    }
    public class Log_MemberAccessSysModel
    {
        /// <summary>
        /// 會員代碼
        /// </summary>
        public String strMemberID { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        /// 登入：Login　
        /// 登出：Logout   
        public String strType { get; set; }

        /// <summary>
        /// 登入狀態
        /// </summary>
        public Boolean ysnSuccess { get; set; }

        /// <summary>
        /// 登入(登出)時間
        /// </summary>
        public DateTime dtmLogin { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public String strIP { get; set; }

        /// <summary>
        /// 登入者CookieID
        /// </summary>
        public String strCookieID { get; set; }
    }
}