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
    public class ImageUploadHelper
    {
        private static String sqlXmlFileName = "SQLXML\\ImageUpload.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        ///// <summary>
        ///// 取得產品現有資料
        ///// </summary>
        ///// <param name="strProductID">產品代碼</param>
        ///// <returns></returns>
      //  public static ProductMaitainModel GetProductData()
      //  {
      //     ProductMaitainModel ProductData = new ProductMaitainModel();
      //      DataAccess da = new DataAccess(sqlXmlFileName,true);
      //      try
       //     {
       //         List<SqlParameter> parm = new List<SqlParameter>();
        //        //過濾參數若為null值，則帶入空白值，以免RunSQL死掉
        //        parm.Add(new SqlParameter("@strProductID", String.IsNullOrEmpty(strProductID) ? "" : strProductID));

               // DataTable dt = da.RunQuery("GetProductData", parm.ToArray());
             //   if (dt.Rows.Count > 0)
              // {
       
                //  ProductData = (from p in dt.Select()
                                //   select new ProductMaitainModel()
                                //   {
        //                               strProductName_CH = p["strProductName_CH"].ToString(),
        //                               strProductName_EN = p["strProductName_EN"].ToString(),
        //                               strGovCode = p["strGovCode"].ToString(),
        //                               curNormalPrice = String.IsNullOrEmpty(p["curNormalPrice"].ToString()) ? 0 : Convert.ToDouble(p["curNormalPrice"].ToString()),
        //                               strADDesc = p["strADDesc"].ToString(),
        //                               strSkinCareStepID = p["strSkinCareStepID"].ToString(),
        //                               strProductSeriesID = p["strProductSeriesID"].ToString(),
        //                               strProductTypeID = p["strProductTypeID"].ToString(),
        //                               ysnNewProduct = String.IsNullOrEmpty(p["ysnNewProduct"].ToString()) ? false : Convert.ToBoolean(p["ysnNewProduct"].ToString()),
        //                               ysnHotProduct = String.IsNullOrEmpty(p["ysnHotProduct"].ToString()) ? false : Convert.ToBoolean(p["ysnHotProduct"].ToString()),
        //                               ysnSurvey = String.IsNullOrEmpty(p["ysnSurvey"].ToString()) ? false : Convert.ToBoolean(p["ysnSurvey"].ToString()),
        //                               ysnSample = String.IsNullOrEmpty(p["ysnSample"].ToString()) ? false : Convert.ToBoolean(p["ysnSample"].ToString()),
        //                               strProductDesc = p["strProductDesc"].ToString(),
                       //                strSPicture = String.IsNullOrEmpty(p["strSPicture"].ToString()) ? "" : p["strSPicture"].ToString(),
                         //              strLPicture = String.IsNullOrEmpty(p["strLPicture"].ToString()) ? "" : p["strLPicture"].ToString(),
                         //              strBPicture = String.IsNullOrEmpty(p["strBPicture"].ToString()) ? "" : p["strBPicture"].ToString()
        //                               intAnswerCode = p["intAnswerCode"].ToString() == "0" ? "" : p["intAnswerCode"].ToString(),
        //                               strKeyword = p["strKeyword"].ToString(),
        //                               strDescription = p["strDescription"].ToString()
                               //    }).FirstOrDefault();
             //   }
          //  }
      //      catch (Exception ex)
       //     {
        //        logger.Error("GetProductData " + ex.Message);
       //     }
        //    return ProductData;
      //  }






        /// <summary>
        /// 取得BS_Profile的設定值
        /// </summary>
        /// <param name="strProfileID">strProfileID</param>
        /// <returns></returns>
        public static String GetProfileParm(String strProfileID)
        {
            String strProfileValue = "";
            DataAccess da = new DataAccess(sqlXmlFileName, true);
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