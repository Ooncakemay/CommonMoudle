using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Security.Principal;
using System.Net;
using CommonMoudle.Areas.ReportingService.Models;

namespace CommonMoudle.Areas.ReportingService.ReportForm
{
    public partial class ReportForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportDataModelBinder.ReportData reportData = (new ReportDataModelBinder()).Bind(Request.Form);
                //ReportViewer設定
                System.Diagnostics.Debug.Write("a:" + reportData.ReportName);
                mainReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
                mainReportViewer.ServerReport.ReportPath = string.Format(ConfigurationManager.AppSettings["ReportPath"], reportData.ReportName);
                //mainReportViewer.ServerReport.ReportPath = "/TestArea/VIP會員明細表";
                System.Diagnostics.Debug.Write("b:" + mainReportViewer.ServerReport.ReportPath);
                string ReportUser = ConfigurationManager.AppSettings["ReportUser"];
                string ReportPass = ConfigurationManager.AppSettings["ReportPass"];
                string ReportArea = ConfigurationManager.AppSettings["ReportArea"];
                mainReportViewer.ServerReport.ReportServerCredentials = new CustomReportCredentials(ReportUser, ReportPass, ReportArea);
                mainReportViewer.ProcessingMode = ProcessingMode.Remote;
                mainReportViewer.ShowParameterPrompts = false;
                mainReportViewer.ShowRefreshButton = false;
                mainReportViewer.ShowWaitControlCancelLink = false;
                mainReportViewer.ShowBackButton = false;
                mainReportViewer.ShowCredentialPrompts = false;

                //丟參數去ReportViewer
                var parametersCollection = new List<ReportParameter>();
                foreach (var parameter in reportData)
                {
                    parametersCollection.Add(new ReportParameter(parameter.Key, parameter.Value, false));
                }
                //parametersCollection.Add(new ReportParameter("ActiveDateBegin", "2015-01-01", false));
                //parametersCollection.Add(new ReportParameter("ActiveDateEnd", "2015-06-30", false));
                mainReportViewer.ServerReport.SetParameters(parametersCollection);
                mainReportViewer.ServerReport.Refresh();
            }
        }
    }
    //將帳密包起來丟給reportview
    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        // local variable for network credential.
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;  // not use ImpersonationUser
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {

                // use NetworkCredentials
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {

            // not use FormsCredentials unless you have implements a custom autentication.
            authCookie = null;
            user = password = authority = null;
            return false;
        }

    }
}