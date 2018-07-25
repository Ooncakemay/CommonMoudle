using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
//using Telexpress.Parser;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Text;

namespace CommonMoudle.DataObject
{
    /// <summary>
    /// 實體檔案處理
    /// </summary>
    public class PhysicalFile
    {
        #region 變數(Variable)



        #endregion

        #region 建構子(Constructor)



        #endregion

        #region 公開函式(Public Method)

            /// <summary>
            /// 檔案重新命名
            /// </summary>
            /// <param name="pi_sFilePath">檔案路徑</param>
            /// <param name="pi_sReName">重新命名的名稱</param>
            public void FileReName(string pi_sFilePath, string pi_sReName)
            {
                if(File.Exists(pi_sFilePath))
                {
                    FileInfo objFile = new FileInfo(pi_sFilePath);
                    DirectoryInfo objFolder = objFile.Directory;
                    string sReNameFilePath = Path.Combine(objFolder.FullName, pi_sReName);

                    if (File.Exists(sReNameFilePath)) { File.Delete(sReNameFilePath); }
                    objFile.CopyTo(sReNameFilePath);
                    objFile.Delete();
                }
            }

            /// <summary>
            /// 資料夾重新命名
            /// </summary>
            /// <param name="pi_sFolderPath">資料夾路徑</param>
            /// <param name="pi_sReName">重新命名的名稱</param>
            public void FolderRename(string pi_sFolderPath, string pi_sReName)
            {
                if (Directory.Exists(pi_sFolderPath))
                {
                    DirectoryInfo objFolder = new DirectoryInfo(pi_sFolderPath);
                    string sReNameFolderPath = Path.Combine(objFolder.Parent.FullName, pi_sReName);

                    if (Directory.Exists(sReNameFolderPath)) { Directory.Delete(sReNameFolderPath, true); }
                    Directory.Move(objFolder.FullName, sReNameFolderPath);
                }
            }

            /// <summary>
            /// 複製檔案
            /// </summary>
            /// <param name="pi_sSourceFilePath">來源檔案路徑</param>
            /// <param name="pi_sTargetFilePath">目的地檔案路徑</param>
            public void CopyFile(string pi_sSourceFilePath, string pi_sTargetFilePath)
            {
                FileInfo objFile = new FileInfo(pi_sSourceFilePath);

                if (File.Exists(pi_sSourceFilePath))
                {
                    this.CreateFolder(pi_sTargetFilePath.Substring(0, pi_sTargetFilePath.LastIndexOf("\\")));
                    objFile.CopyTo(pi_sTargetFilePath, true);
                }
            }

            /// <summary>
            /// 複製資料夾
            /// </summary>
            /// <param name="pi_sSourceFolderPath">來源資料夾路徑</param>
            /// <param name="pi_sTargetFolderPath">目的地資料夾路徑</param>
            public void CopyFolder(string pi_sSourceFolderPath, string pi_sTargetFolderPath)
            {
                DirectoryInfo objFolder = null;

                if (Directory.Exists(pi_sSourceFolderPath))
                {
                    objFolder = new DirectoryInfo(pi_sSourceFolderPath);

                    if (!Directory.Exists(pi_sTargetFolderPath))
                    { Directory.CreateDirectory(pi_sTargetFolderPath); }
                    foreach (FileInfo objFile in objFolder.GetFiles("*.*", SearchOption.AllDirectories))
                    {
                        string sTargetFilePath = objFile.FullName.Replace(pi_sSourceFolderPath, pi_sTargetFolderPath);

                        this.CopyFile(objFile.FullName, sTargetFilePath);
                    }
                }
            }

            /// <summary>
            /// 建立檔案
            /// </summary>
            /// <param name="pi_sFolderPath">檔案的資料夾路徑</param>
            /// <param name="pi_sFileName">檔案名稱(含附檔名)</param>
            /// <param name="pi_sContent">文字內容</param>
            /// <param name="pi_bAppend">是否覆蓋檔案內容(False 覆蓋檔案內容，True 則累加檔案內容)</param>
            public void CreateFile(string pi_sFolderPath, string pi_sFileName, string pi_sContent, bool pi_bAppend)
            {
                string sFileFullPath = Path.Combine(new string[] { pi_sFolderPath, pi_sFileName });

                this.CreateFolder(pi_sFolderPath);
                this.CreateFile(sFileFullPath, pi_sContent, pi_bAppend);
            }

            /// <summary>
            /// 建立檔案
            /// </summary>
            /// <param name="pi_sFilePath">檔案路徑</param>
            /// <param name="pi_sContent">文字內容</param>
            /// <param name="pi_bAppend">是否覆蓋檔案內容(False 覆蓋檔案內容，True 則累加檔案內容)</param>
            public void CreateFile(string pi_sFilePath, string pi_sContent, bool pi_bAppend)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pi_sFilePath, pi_bAppend))
                {
                    file.WriteLine(pi_sContent);
                }
            }

            /// <summary>
            /// 建立資料夾
            /// </summary>
            /// <param name="pi_sFolderPath">資料夾路徑</param>
            public void CreateFolder(string pi_sFolderPath)
            {
                if (!Directory.Exists(pi_sFolderPath))
                { Directory.CreateDirectory(pi_sFolderPath); }
            }

            ///// <summary>
            ///// 讀取檔案
            ///// </summary>
            ///// <param name="pi_sFilePath">檔案路徑</param>
            ///// <returns>回傳讀取檔案文字</returns>
            //public string ReadFile(string pi_sFilePath)
            //{
            //    string sContent = string.Empty;

            //    if (File.Exists(pi_sFilePath))
            //    {
            //        try
            //        {
            //            FileParser objParser = ParserFactory.GetParser(pi_sFilePath);
            //            Document objDocument = objParser.Parse();
            //            sContent = objDocument.ToString();
            //        }
            //        catch
            //        {
            //            //出錯代表 DocumentParser 沒有負責這種附檔名，改由直接讀檔取內容
            //            using (System.IO.StreamReader objReader = new System.IO.StreamReader(pi_sFilePath))
            //            {
            //                sContent = objReader.ReadToEnd();
            //            }
            //        }
            //    }

            //    return sContent;
            //}

            /// <summary>
            /// 移動來源資料夾內的檔案到目的地資料夾
            /// </summary>
            /// <param name="pi_sSourceFolderPath">來源資料夾路徑</param>
            /// <param name="pi_sTargetFolderPath">目的地資料夾路徑</param>
            public void MoveTo(string pi_sSourceFolderPath, string pi_sTargetFolderPath)
            {
                System.IO.DirectoryInfo objDirectoryInfo = new DirectoryInfo(pi_sSourceFolderPath);

                foreach (FileInfo objFileInfo in objDirectoryInfo.GetFiles())
                {
                    string sSourceFilePath = Path.Combine(pi_sSourceFolderPath, objFileInfo.Name);
                    string sTargetFilePath = Path.Combine(pi_sTargetFolderPath, objFileInfo.Name);

                    if (System.IO.File.Exists(sTargetFilePath)) { System.IO.File.Delete(sTargetFilePath); }
                    File.Move(sSourceFilePath, sTargetFilePath);
                }
            }

            /// <summary>
            /// 刪除資料夾
            /// </summary>
            /// <param name="pi_sFolderPath">資料夾路徑</param>
            public void DeleteFolder(string pi_sFolderPath)
            {
                DirectoryInfo objFolder = null;

                if (Directory.Exists(pi_sFolderPath))
                {
                    objFolder = new DirectoryInfo(pi_sFolderPath);
                    objFolder.Delete(true);
                }
            }

            /// <summary>
            /// 刪除指定資料夾下的檔案
            /// </summary>
            /// <param name="pi_sFolderPath">資料夾路徑</param>
            /// <param name="pi_objFileNames">檔名清單</param>
            public void DeleteFile(string pi_sFolderPath, List<string> pi_objFileNames)
            {
                foreach (string sFileName in pi_objFileNames)
                {
                    string sFilePath = Path.Combine(pi_sFolderPath, sFileName);
                    this.DeleteFile(sFilePath);
                }
            }

            /// <summary>
            /// 刪除檔案
            /// </summary>
            /// <param name="pi_sFilePath">檔案路徑</param>
            public void DeleteFile(string pi_sFilePath)
            {
                if (File.Exists(pi_sFilePath))
                {
                    FileInfo objFileInfo = new FileInfo(pi_sFilePath);
                    objFileInfo.Delete();
                }
            }

            /// <summary>
            /// 取得 Zip 裡的 FileName
            /// </summary>
            /// <param name="pi_sZipFilePath">壓縮檔路徑</param>
            /// <returns>回傳 Zip 裡的 FileName</returns>
            public String[] GetZipFileNames(string pi_sZipFilePath)
            {

                ArrayList myArrayList = new ArrayList();
                ZipInputStream s = new ZipInputStream(File.OpenRead(pi_sZipFilePath));
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    myArrayList.Add(theEntry.Name);
                }
                s.Close();

                string[] fileNames = (string[])myArrayList.ToArray(typeof(string));

                return fileNames;
            }

            /// <summary>
            /// Zip 解壓縮
            /// </summary>
            /// <param name="pi_sZipFilePath">壓縮檔路徑</param>
            /// <param name="pi_sFolderPath">解壓縮的資料夾路徑</param>
            public void UnZipFile(string pi_sZipFilePath, string pi_sFolderPath)
            {
                ZipInputStream s = new ZipInputStream(File.OpenRead(pi_sZipFilePath));
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    string serverFolder = pi_sFolderPath;

                    // create directory
                    Directory.CreateDirectory(serverFolder + "\\" + directoryName);
                    if (fileName != String.Empty)
                    {
                        FileStream streamWriter = File.Create((serverFolder + "\\" + theEntry.Name));
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
                s.Close();
            }

            /// <summary>
            /// 檔案 Zip 壓縮
            /// </summary>
            /// <param name="pi_sSetZipFolderPath">放進壓縮檔的資料夾路徑</param>
            /// <param name="pi_sCreateZipFolderPath">建立壓縮檔的資料夾路徑</param>
            /// <param name="pi_sZipFileName">壓縮檔檔名(含副檔名)</param>
            public void ZipFiles(string pi_sSetZipFolderPath, string pi_sCreateZipFolderPath, string pi_sZipFileName)
            {
                ZipOutputStream zos = null;
                
                try
                {
                    string zipPath = pi_sCreateZipFolderPath + @"\" + pi_sZipFileName;
                    ArrayList files = new ArrayList();
                    byte[] buffer = new byte[4096];
                    List<string> objFolderNameList = new List<string>();

                    if (Directory.Exists(pi_sSetZipFolderPath))
                    {
                        files.AddRange(Directory.GetFiles(pi_sCreateZipFolderPath, "*.*", SearchOption.AllDirectories));
                    }

                    zos = new ZipOutputStream(File.Create(zipPath));
                    //if (pi_sPassword != null && pi_sPassword != string.Empty) zos.Password = pi_sPassword;
                    //if (pi_sComment != null && pi_sComment != "") zos.SetComment(pi_sComment);
                    zos.SetLevel(9);//Compression level 0-9 (9 is highest)
                    zos.UseZip64 = UseZip64.Off;

                    foreach (string f in files)
                    {
                        FileInfo objFile = new FileInfo(f);
                        string sFilePath = objFile.FullName.Replace(pi_sSetZipFolderPath + @"\", "");
                        ZipEntry entry = new ZipEntry(sFilePath);
                        
                        //objFile.Directory.FullName.Replace(pi_sSetZipFolderPath, "").Replace(@"\", "")
                        if (!string.IsNullOrEmpty(objFile.Directory.FullName.Replace(pi_sSetZipFolderPath, "").Replace(@"\", ""))
                            && !objFolderNameList.Contains(objFile.Directory.Name))
                        {
                            ZipEntry objFolder = new ZipEntry(objFile.Directory.Name + @"\");
                            
                            objFolder.DateTime = DateTime.Now;
                            zos.PutNextEntry(objFolder);
                            objFolderNameList.Add(objFile.Directory.Name);
                        }

                        entry.DateTime = DateTime.Now;
                        zos.PutNextEntry(entry);
                        FileStream fs = File.OpenRead(f);
                        int sourceBytes;

                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            zos.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);

                        fs.Close();
                        fs.Dispose();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    zos.Finish();
                    zos.Close();
                    zos.Dispose();
                }
            }

        #endregion

        #region 內部函式(Private Method)



        #endregion

        #region 屬性(Attribute)



        #endregion
    }
}