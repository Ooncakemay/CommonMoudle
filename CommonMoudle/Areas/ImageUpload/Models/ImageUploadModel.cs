using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonMoudle.Areas.ImageUpload.Models
{
    public class ImageUploadModel
    {

    }

    public class ProductMaitainModel
    {
        /// <summary>
        /// 產品代碼
        /// </summary>
        public String strProductID { get; set; }
        /// <summary>
        /// 產品小圖示
        /// </summary>
        public String strSPicture { get; set; }
        /// <summary>
        /// 產品大圖示
        /// </summary>
        public String strLPicture { get; set; }
        /// <summary>
        /// 背景圖
        /// </summary>
        public String strBPicture { get; set; }
        /// <summary>
        /// 產品中文名
        /// </summary>
        public String strProductName_CH { get; set; }
        /// <summary>
        /// 產品英文名
        /// </summary>
        public String strProductName_EN { get; set; }
        /// <summary>
        /// 幣別
        /// </summary>
        public String strCurrency { get; set; }
        /// <summary>
        /// 市價
        /// </summary>
        public Double curNormalPrice { get; set; }
        /// <summary>
        /// 產品類別名稱
        /// </summary>
        public String strProductTypeDesc { get; set; }
        /// <summary>
        /// 產品系統名稱
        /// </summary>
        public String strProductSeriesDesc { get; set; }
        /// <summary>
        /// 產品系統代碼
        /// </summary>
        public String strProductSeriesID { get; set; }
        /// <summary>
        /// 廣告文稿描述
        /// </summary>
        public String strADDesc { get; set; }
        /// <summary>
        /// 廣字號
        /// </summary>
        public String strGovCode { get; set; }
        /// <summary>
        /// 產品說明(HTML語法)
        /// </summary>
        public String strProductDesc { get; set; }
        /// <summary>
        /// 文章內容(含Html tag)
        /// </summary>
        public String strHTMLContent { get; set; }
        /// <summary>
        /// 產品類別代碼
        /// </summary>
        public String strProductTypeID { get; set; }
        /// <summary>
        /// 保養程序代碼
        /// </summary>
        public String strSkinCareStepID { get; set; }
        /// <summary>
        /// 商品分類代碼
        /// </summary>
        public String strDeptCode { get; set; }
        /// <summary>
        /// 新品
        /// </summary>
        public bool ysnNewProduct { get; set; }
        /// <summary>
        /// 熱門產品
        /// </summary>
        public bool ysnHotProduct { get; set; }
        /// <summary>
        /// 產品回函
        /// </summary>
        public bool ysnSurvey { get; set; }
        /// <summary>
        /// 試用品
        /// </summary>
        public bool ysnSample { get; set; }
        /// <summary>
        /// 建立者UserID
        /// </summary>
        public String strWHO { get; set; }
        /// <summary>
        /// 產品進階文章intAnswerCode
        /// </summary>
        public String intAnswerCode { get; set; }
        /// <summary>
        /// 產品關鍵字
        /// </summary>
        public String strKeyword { get; set; }
        /// <summary>
        /// 產品描述
        /// </summary>
        public String strDescription { get; set; }
    }
    

}