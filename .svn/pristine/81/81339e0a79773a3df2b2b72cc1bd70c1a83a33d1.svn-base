using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using System.Data;
using com.telexpress.Data.DA;

namespace CommonMoudle.Areas.SelectAutoComplete.Models
{
    public class AutoCompleteHelper
    {
        private static String sqlXmlFileName = "SQLXML\\SelectAutoComplete.xml";//SQL指令路徑
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();//使用NLog功能
        /// <summary>
        /// 商品下拉選單
        /// </summary>
        public static List<Item> GetItemNumberList()
        {
            List<Item> model = new List<Item>();

            DataTable dt = new DataTable();
           
            try
            {
                DataAccess da = new DataAccess(sqlXmlFileName, true);

                dt = da.RunQuery("GetItemNumberList");
                foreach (DataRow drs in dt.Rows)
                {
                    Item s = new Item();
                    s.strItemNumber = drs["strItemNumber"].ToString();
                    s.strItemLongDesc = drs["strItemLongDesc"].ToString();
                    model.Add(s);
                }
            }
            catch (Exception e)
            {
                logger.Error("GetItemNumberList" + e.Message);  // Error log
            }
            return model;
        }
    }
}