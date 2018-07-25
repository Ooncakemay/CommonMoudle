using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonMoudle.Areas.AutoComplete.Models
{
   
    /// <summary>
    /// 會員地址
    /// </summary>
    public class AutoCompleteModel
    {
      
        /// <summary>
        /// 地址
        /// </summary>
        public String strAddress { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime dtmUpdate { get; set; }

         /// <summary>
        /// 流水號
        /// </summary>
        public int intSeqNo { get; set; }

    }
}