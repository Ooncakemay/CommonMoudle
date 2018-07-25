using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace CommonMoudle.Areas.ReportingService.Models
{
    public class ReportParam
    {
        [Key]
        public string ParameterName { get; set; }
        public string DataType { get; set; }
        public string Prompt { get; set; }
        public string DataSetName { get; set; }
        public string ValueField { get; set; }
        public string LabelField { get; set; }
        public string CommandText { get; set; }
        public bool? IsMenu { get; set; }

    }

    public class ReportDataModelBinder : IModelBinder
    {
        [ModelBinder(typeof(ReportDataModelBinder))]
        public class ReportData : Dictionary<string, string>
        {

            public Guid ReportID { get; internal set; }

            public string ReportName { get; internal set; }

        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return this.Bind(controllerContext.HttpContext.Request.Form);

        }

        public ReportData Bind(NameValueCollection form)
        {
            var returnValue = new ReportData();
            foreach (var key in form.AllKeys)
            {
                if (key.StartsWith("#"))
                {
                    returnValue.Add(key.Replace("#", ""), form[key]);
                }
                else if (key == "ReportID")
                {
                    returnValue.ReportID = Guid.Parse(form[key]);
                }
                else if (key == "ReportName")
                {
                    returnValue.ReportName = form[key];
                }
            }
            return returnValue;
        }
    }

    public class SelectMenu
    {
        /// <summary>
        /// 選取值
        /// </summary>
        public string strSelectValue { get; set; }
        /// <summary>
        /// 顯示值
        /// </summary>
        public string strSelectName { get; set; }
    }
}