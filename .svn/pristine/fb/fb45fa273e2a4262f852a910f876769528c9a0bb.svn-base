using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Configuration;
using System.Drawing;
using NLog;
using System.Drawing.Imaging;
using CommonMoudle.Areas.ImageUpload.Models;
using CommonMoudle.DataObject;

namespace CommonMoudle.Services
{
    /// <summary>
    ///ProductUploadHandler 的摘要描述
    /// </summary>
    public class ProductUploadHandler : IHttpHandler
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                //取得檔案放置路徑
                var uploadPath = context.Request.Params["uploadPath"];
                //取得上傳圖片類型尺寸
                var strProfileID = context.Request.Params["strProfileID"];
                PhysicalFile objPhysicalFile = new PhysicalFile();
                //取得會使用到的相關資訊
                //objArticleService = new ArticleService();
                //Enum.TryParse(sArticleStatus, out objArticleStatus);
                //objArticle = objArticleService.GetArticle(sAnswerCode, objArticleStatus);
                //objSystemParam = new SysemParam();

                //壓縮檔處理
                foreach (string file in context.Request.Files)
                {
                    HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;

                    //fileExtension:副檔名
                    String fileExtension = System.IO.Path.GetExtension(hpf.FileName).ToLower(); 

                    object result = new object();
                    string sZipFilePath = string.Empty;
                    string sFolderPath = string.Empty;

                    Image img = Image.FromStream(hpf.InputStream, true, true);
                    
                    //取得影像的格式
                    ImageFormat thisFormat = img.RawFormat;

                    String PictureSize = ImageUploadHelper.GetProfileParm(strProfileID);       
                    String[] PictureSizeLimit = PictureSize.Replace(" ","").Split('x');
                    //寬 & 高不得小於設定
                    //if (img.Width < Convert.ToInt32(PictureSizeLimit[0]) || img.Height < Convert.ToInt32(PictureSizeLimit[1]))
                    //{
                    //    String ErrorMsg = "請上傳尺寸大於" + PictureSize + "的檔案，謝謝!";
                    //    result = new { status = "Failure", ErrorMsg = ErrorMsg };
                    //    var jsonObjImg = js.Serialize(result);
                    //    context.Response.Write(jsonObjImg.ToString());
                    //    break;
                    //}

                    if (hpf.ContentLength == 0)
                    {
                        continue;
                    }

                    //資料夾路徑
                    sFolderPath = System.Web.HttpContext.Current.Server.MapPath(uploadPath + "/");
                    List<MultiSizeImg> MultiSizeImgList = new List<MultiSizeImg>();

                    if (String.Equals(strProfileID, "Picture"))
                    {
                        MultiSizeImgList = ResizeImg(img, new String[] { "MiddlePicture", "SmallPicture" }, sFolderPath, fileExtension);
                    }
                    else
                    {
                        MultiSizeImgList = ResizeImg(img, new String[] { "BackgroundPicture" }, sFolderPath, fileExtension);
                    }
                    
                    //要儲存的路徑
                    objPhysicalFile.CreateFolder(sFolderPath);

                    foreach (var item in MultiSizeImgList)
                    {
                        //儲存圖片，需加入影像的格式，不然IE圖片不出現
                        item.ImageOut.Save(item.FilePath, thisFormat);
                    }

                    result = new { status = "Success", MultiSizeImgList = MultiSizeImgList, uploadPath = uploadPath, FolderPath = sFolderPath };
                    var jsonObj = js.Serialize(result);
                    context.Response.Write(jsonObj.ToString());
                   
                }
            }
            catch (Exception ex)
            {
                object result = new { status = "Failure", ErrorMsg = "發生異常錯誤，請重新上傳" };
                var jsonObjImg = js.Serialize(result);
                context.Response.Write(jsonObjImg.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class ViewDataUploadFilesResult
        {
            public string NewFilePath { get; set; }
            public string OldFileName { get; set; }
            public int Length { get; set; }
            public string Type { get; set; }
        }

        public class MultiSizeImg
        {
            public MultiSizeImg(String Size)
            {
                if (Size == "M") // MiddlePicture的尺寸會存到strSPicture，而不是strMPicture
                {
                    ImgType = "strLPicture";
                }
                else
                {
                    ImgType = "str" + Size + "Picture";
                }
            }
            public String ImgType { get; set; }
            public Bitmap ImageOut { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public String FileName { get; set; }
            public String FilePath { get; set; }
        }

        /// <summary>
        /// 多尺寸繪製
        /// </summary>
        /// <param name="img">圖檔</param>
        /// <param name="Size">尺寸陣列(from BS_Profile)</param>
        /// <param name="sFolderPath">資料夾路徑</param>
        /// <param name="fileExtension">副檔名</param>
        /// <returns></returns>
        public List<MultiSizeImg> ResizeImg(Image img, String[] Size, String sFolderPath, String fileExtension)
        {
            try
            {
                List<MultiSizeImg> MultiSizeImgList = new List<MultiSizeImg>();
                foreach (var item in Size)
                {
                    MultiSizeImg MultiSizeImgData = new MultiSizeImg(item.Substring(0, 1));
                    String[] WidthHeight = GiftHelper.GetProfileParm(item).Replace(" ","").Split('x');
                    MultiSizeImgData.Width = Convert.ToInt32(WidthHeight[0]);
                    MultiSizeImgData.Height = Convert.ToInt32(WidthHeight[1]);
                    //resize
                    MultiSizeImgData.ImageOut = new Bitmap(img, MultiSizeImgData.Width, MultiSizeImgData.Height);
                    MultiSizeImgData.FileName = Guid.NewGuid().ToString() + fileExtension;
                    MultiSizeImgData.FilePath = Path.Combine(sFolderPath, MultiSizeImgData.FileName);
                    MultiSizeImgList.Add(MultiSizeImgData);
                }
                return MultiSizeImgList;
            }
            catch(Exception ex)
            {
                logger.Error("ResizeImg 圖片多尺寸繪製" + ex.Message);
                //在外層處理
                throw ex;
                
            }
        }
    }
}