using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonMoudle.Areas.Parameter.Models
{
    public class SysParamModel
    {
        /// <summary>
        /// 參數值
        /// </summary>
        public String strParamValue { get; set; }

        /// <summary>
        /// 參數說明
        /// </summary>
        public String ParamDesc { get; set; }
    }
}