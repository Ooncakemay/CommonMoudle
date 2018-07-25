using System.Web;
using System.Web.Optimization;

namespace CommonMoudle
{
    public class BundleConfig
    {
        // 如需 Bundling 的詳細資訊，請造訪 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            //Plupload js
            bundles.Add(new ScriptBundle("~/bundles/Plupload_jquery").Include(
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/jquery.plupload.queue/jquery.plupload.queue.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.gears.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.silverlight.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.flash.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.browserplus.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.html4.js",
                        "~/Scripts/ImageUpload/EditorService/Plupload/Script/plupload.html5.js"));

            //Plupload css
            bundles.Add(new StyleBundle("~/bundles/Plupload_css").Include(
                        "~/Scripts/ImageUpload/EditorService/Plupload/css/jquery.plupload.queue.css",
                        "~/Styles/ImageUpload/Uploadstyle.css"));

           
            //共用CSS
            bundles.Add(new StyleBundle("~/Styles/Common").Include("~/Styles/te_lrp_reset.css", 
                                                                   "~/Styles/te_lrp_common.css"));
            //Register會員註冊
            bundles.Add(new StyleBundle("~/Styles/Register").Include("~/Styles/Register/te_lrp_login_reg.css"));
            bundles.Add(new ScriptBundle("~/Scripts/Register").Include("~/Scripts/Register/jquery.validate.js"));


            //產品說明編輯器 CKeditor
            bundles.Add(new ScriptBundle("~/bundles/CKeditor").Include(
                    "~/Scripts/ImageUpload/EditorService/ckeditor/ckeditor.js"));



            //autocomplete
            bundles.Add(new ScriptBundle("~/bundles/jquery.autocomplete").Include("~/Scripts/Autocomplete/jquery.autocomplete.js"));
            //autocomplete
            bundles.Add(new StyleBundle("~/Styles/te_gogoro_member").Include("~/Styles/Autocomplete/te_gogoro_member.css"));
            bundles.Add(new ScriptBundle("~/Styles/autocomplete").Include("~/Styles/Autocomplete/jquery-ui.css", "~/Styles/Autocomplete/jquery.ui.autocomplete.css"));
            //loading
            bundles.Add(new StyleBundle("~/Styles/loading").Include("~/Styles/loading/temcs_common.css"));
            //ReportingService 2016/06/30
            bundles.Add(new StyleBundle("~/Styles/te_subscribe_report").Include(
            "~/Styles/ReportingService/te_subscribe_report_reset.css",
            "~/Styles/ReportingService/te_subscribe_report.css"));
            
            //ImageUpload
            bundles.Add(new StyleBundle("~/Styles/ImageUpload/TecrmBackweb_Common").Include("~/Styles/ImageUpload/TecrmBackweb_Common.css"));

            //下拉選單autocomplete
            bundles.Add(new ScriptBundle("~/Scripts/customSelect").Include("~/Scripts/SelectAutoComplete/bootstrap.js", "~/Scripts/SelectAutoComplete/angular.js", "~/Scripts/SelectAutoComplete/customSelect.js"));
            //下拉選單autocomplete會用到的 css
            bundles.Add(new StyleBundle("~/Styles/customSelect_css").Include(
                         "~/Styles/SelectAutoComplete/bootstrap_less.css",
                         "~/Styles/SelectAutoComplete/style.css",
                         "~/Styles/SelectAutoComplete/font-awesome.css"));
            //Html編輯器
            bundles.Add(new ScriptBundle("~/Scripts/ckeditor").Include(
                        "~/Scripts/ckeditor/ckeditor.js"));

            //多選下拉選單
            bundles.Add(new ScriptBundle("~/bundles/MultipleSelect").Include("~/Scripts/MultipleSelect/jquery.multiple.select.js"));
            bundles.Add(new StyleBundle("~/Styles/MultipleSelect").Include("~/Styles/MultipleSelect/multiple-select.css"));

        }
    }
}