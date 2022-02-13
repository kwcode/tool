using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ku.Common
{
    public class FileHelper
    {
        #region 读文件
        /**************************************** 
         * 函数名称：ReadFile 
         * 功能说明：读取文本内容 
         * 参    数：Path:文件路径 
         * 调用示列： 
         *           string Path = Server.MapPath("Default2.aspx");        
         *           string s = DotNet.Utilities.FileOperate.ReadFile(Path); 
        *****************************************/
        /// <summary>  
        /// UTF8读文件  
        /// </summary>  
        /// <param name="Path">文件路径</param>  
        /// <returns></returns>  
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                throw new Exception("不存在相应的目录" + Path);
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.UTF8);
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }
        //, System.Text.Encoding.GetEncoding("gb2312")
        public static string ReadFile(string Path, Encoding encoding)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                throw new Exception("不存在相应的目录" + Path);
            else
            {
                StreamReader f2 = new StreamReader(Path, encoding);
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }
        #endregion

        #region 写文件
        /// <summary>
        /// 写文件-覆盖   
        /// </summary> 
        public static void WriteFile(string path, string content)
        {
            WriteFile(path, content, Encoding.UTF8);
        }

        /// <summary>  
        /// 写文件-覆盖   
        public static void WriteFile(string path, string content, Encoding encoding)
        {
            StreamWriter swr = null;
            try
            {
                swr = new StreamWriter(path, false, encoding);
                swr.Write(content);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (swr != null)
                {
                    swr.Close();
                    swr.Dispose();
                }
            }
        }


        #region 写文件-追加 

        /// <summary>  
        /// 写文件-追加    
        public static void WriteFile_Append(string path, string content, Encoding encoding)
        {
            StreamWriter swr = null;
            try
            {
                swr = new StreamWriter(path, true, encoding);
                swr.Write(content);
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (swr != null)
                {
                    swr.Close();
                    swr.Dispose();
                }
            }
        }
        #endregion

        /// <summary>
        /// 写文件 不存在 添加 存在覆盖
        /// vs 默认urf-8  BOM 格式
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="isBom"></param>
        public static void WriteFile_UTF8(string path, string content, bool isBom = true)
        {
            var utf8WithBom = new System.Text.UTF8Encoding(isBom);  // 用true来指定包含bom
            StreamWriter swr = null;
            try
            {
                swr = new StreamWriter(path, false, utf8WithBom);
                swr.Write(content);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (swr != null)
                {
                    swr.Close();
                    swr.Dispose();
                }
            }
        }
        #endregion

        #region 常用文件转换

        /// <summary>
        /// 将 Stream 转成 byte[] 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始  
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// 将 byte[] 转成 Stream

        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        #endregion

        #region 获得指定路径下所有文件
        public static FileInfo[] GetAllFiles(string path, bool isDistinct = false, params string[] format)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = null;
            if (format == null || format.Length <= 0)
            {
                files = root.GetFiles("*", SearchOption.AllDirectories);

            }
            else
            {//new string[] { "*.xlsx", "*.csv", "*.xls" }
                files = format.SelectMany(i => root.GetFiles(i, SearchOption.AllDirectories)).ToArray();

            }
            if (!isDistinct)
            {
                files = files.Distinct().ToArray();
            }
            return files;
        }
        #endregion

        #region 拷贝文件
        /**************************************** 
         * 函数名称：FileCoppy 
         * 功能说明：拷贝文件 
         * 参    数：OrignFile:原始文件,NewFile:新文件路径 
         * 调用示列： 
         *           string OrignFile = Server.MapPath("Default2.aspx");      
         *           string NewFile = Server.MapPath("Default3.aspx"); 
         *           DotNet.Utilities.FileOperate.FileCoppy(OrignFile, NewFile); 
        *****************************************/
        /// <summary>  
        /// 拷贝文件  
        /// </summary>  
        /// <param name="OrignFile">原始文件</param>  
        /// <param name="NewFile">新文件路径</param>  
        public static void FileCoppy(string OrignFile, string NewFile)
        {
            File.Copy(OrignFile, NewFile, true);
        }

        #endregion

        public static void CreateDirectory(string path)
        {
            var dir = System.IO.Path.GetDirectoryName(path);
            // 判断目标目录是否存在如果不存在则新建之  
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
         
        #region 删除文件
        /**************************************** 
         * 函数名称：FileDel 
         * 功能说明：删除文件 
         * 参    数：Path:文件路径 
         * 调用示列： 
         *           string Path = Server.MapPath("Default3.aspx");     
         *           DotNet.Utilities.FileOperate.FileDel(Path); 
        *****************************************/
        /// <summary>  
        /// 删除文件  
        /// </summary>  
        /// <param name="Path">路径</param>  
        public static void FileDel(string Path)
        {
            File.Delete(Path);
        }
        #endregion

        //#region 获得指定路径下所有文件名
        ///*
        // * 获得指定路径下所有文件名
        // * StreamWriter sw  文件写入流
        // * string path      文件路径
        // * int indent       输出时的缩进量
        // */
        //public static void getFileName(StreamWriter sw, string path, int indent)
        //{
        //    DirectoryInfo root = new DirectoryInfo(path);
        //    foreach (FileInfo f in root.GetFiles())
        //    {
        //        for (int i = 0; i < indent; i++)
        //        {
        //            sw.Write("  ");
        //        }
        //        sw.WriteLine(f.Name);
        //    }
        //}
        //#endregion

        //#region 获得指定路径下所有子目录名
        //public static void getDirectory(StreamWriter sw, string path, int indent)
        //{
        //    getFileName(sw, path, indent);
        //    DirectoryInfo root = new DirectoryInfo(path);
        //    foreach (DirectoryInfo d in root.GetDirectories())
        //    {
        //        for (int i = 0; i < indent; i++)
        //        {
        //            sw.Write("  ");
        //        }
        //        sw.WriteLine("文件夹：" + d.Name);
        //        getDirectory(sw, d.FullName, indent + 2);
        //        sw.WriteLine();
        //    }
        //}
        //#endregion

        //#region 写文件
        //protected void Write_Txt(string FileName, string Content)
        //{
        //    Encoding code = Encoding.GetEncoding("gb2312");

        //    string path = AppDomain.CurrentDomain.BaseDirectory + FileName;　//保存文件的路径  
        //    string str = Content;
        //    StreamWriter sw = null;
        //    {
        //        try
        //        {
        //            sw = new StreamWriter(path, false, code);
        //            sw.Write(str);
        //            sw.Flush();
        //        }
        //        catch { }
        //    }
        //    sw.Close();
        //    sw.Dispose();

        //}
        //#endregion

        //#region 读文件
        //protected string Read_Txt(string filename)
        //{

        //    Encoding code = Encoding.GetEncoding("gb2312");
        //    string path = AppDomain.CurrentDomain.BaseDirectory + filename;　//保存文件的路径
        //    string str = "";
        //    if (File.Exists(path))
        //    {
        //        StreamReader sr = null;
        //        try
        //        {
        //            sr = new StreamReader(path, code);
        //            str = sr.ReadToEnd(); // 读取文件  
        //        }
        //        catch { }
        //        sr.Close();
        //        sr.Dispose();
        //    }
        //    else
        //    {
        //        str = "";
        //    }


        //    return str;
        //}
        //#endregion

        //#region 取得文件后缀名
        ///// <summary>  
        ///// 取后缀名  (.jpg|.png|.html)
        ///// </summary>  
        ///// <param name="filename">文件名或地址</param>  
        ///// <returns>返回如： (.jpg|.png|.html)</returns>  
        //public static string GetPostfixStr(string fileName)
        //{
        //    string postfix = System.IO.Path.GetExtension(fileName);
        //    return postfix;
        //}
        //#endregion


        #region 检测文件是否存在

        public static bool IsExist(string path)
        {
            return System.IO.File.Exists(path);
        }
        #endregion
        //#region 输出错误日志
        ///// <summary>
        ///// 输出错误日志
        ///// </summary>
        //public static void WriteFile_Error(string ex)
        //{
        //    FileStream f = File.OpenWrite("Err.txt");

        //    StreamWriter f2 = new StreamWriter(f);

        //    ex = "时间：" + System.DateTime.Now.ToString() + "\r\n" + ex;

        //    f2.WriteLine(ex);

        //    f2.Close();

        //    f.Close();
        //}
        //#endregion

        //#region 读文件
        ///**************************************** 
        // * 函数名称：ReadFile 
        // * 功能说明：读取文本内容 
        // * 参    数：Path:文件路径 
        // * 调用示列： 
        // *           string Path = Server.MapPath("Default2.aspx");        
        // *           string s = DotNet.Utilities.FileOperate.ReadFile(Path); 
        //*****************************************/
        ///// <summary>  
        ///// UTF8读文件  
        ///// </summary>  
        ///// <param name="Path">文件路径</param>  
        ///// <returns></returns>  
        //public static string ReadFile(string Path)
        //{
        //    string s = "";
        //    if (!System.IO.File.Exists(Path))
        //        throw new Exception("不存在相应的目录" + Path);
        //    else
        //    {
        //        StreamReader f2 = new StreamReader(Path, System.Text.Encoding.UTF8);
        //        s = f2.ReadToEnd();
        //        f2.Close();
        //        f2.Dispose();
        //    }

        //    return s;
        //}
        ////, System.Text.Encoding.GetEncoding("gb2312")
        //public static string ReadFile(string Path, Encoding encoding)
        //{
        //    string s = "";
        //    if (!System.IO.File.Exists(Path))
        //        throw new Exception("不存在相应的目录" + Path);
        //    else
        //    {
        //        StreamReader f2 = new StreamReader(Path, encoding);
        //        s = f2.ReadToEnd();
        //        f2.Close();
        //        f2.Dispose();
        //    }

        //    return s;
        //}
        //#endregion

        //#region 追加文件
        ///**************************************** 
        // * 函数名称：FileAdd 
        // * 功能说明：追加文件内容 
        // * 参    数：Path:文件路径,strings:内容 
        // * 调用示列： 
        // *           string Path = Server.MapPath("Default2.aspx");      
        // *           string Strings = "新追加内容"; 
        // *           DotNet.Utilities.FileOperate.FileAdd(Path, Strings); 
        //*****************************************/
        ///// <summary>  
        ///// 追加文件  
        ///// </summary>  
        ///// <param name="Path">文件路径</param>  
        ///// <param name="strings">内容</param>  
        //public static void FileAdd(string Path, string strings)
        //{
        //    StreamWriter sw = File.AppendText(Path);
        //    sw.Write(strings);
        //    sw.Flush();
        //    sw.Close();
        //    sw.Dispose();
        //}
        //#endregion



        //#region 移动文件
        ///**************************************** 
        // * 函数名称：FileMove 
        // * 功能说明：移动文件 
        // * 参    数：OrignFile:原始路径,NewFile:新文件路径 
        // * 调用示列： 
        // *            string OrignFile = Server.MapPath("../说明.txt");     
        // *            string NewFile = Server.MapPath("../../说明.txt"); 
        // *            DotNet.Utilities.FileOperate.FileMove(OrignFile, NewFile); 
        //*****************************************/
        ///// <summary>  
        ///// 移动文件  
        ///// </summary>  
        ///// <param name="OrignFile">原始路径</param>  
        ///// <param name="NewFile">新路径</param>  
        //public static void FileMove(string OrignFile, string NewFile)
        //{
        //    File.Move(OrignFile, NewFile);
        //}
        //#endregion

        //#region 在当前目录下创建目录
        ///**************************************** 
        // * 函数名称：FolderCreate 
        // * 功能说明：在当前目录下创建目录 
        // * 参    数：OrignFolder:当前目录,NewFloder:新目录 
        // * 调用示列： 
        // *           string OrignFolder = Server.MapPath("test/");     
        // *           string NewFloder = "new"; 
        // *           DotNet.Utilities.FileOperate.FolderCreate(OrignFolder, NewFloder);  
        //*****************************************/
        ///// <summary>  
        ///// 在当前目录下创建目录  
        ///// </summary>  
        ///// <param name="OrignFolder">当前目录</param>  
        ///// <param name="NewFloder">新目录</param>  
        //public static void FolderCreate(string OrignFolder, string NewFloder)
        //{
        //    Directory.SetCurrentDirectory(OrignFolder);
        //    Directory.CreateDirectory(NewFloder);
        //}

        ///// <summary>  
        ///// 创建文件夹  
        ///// </summary>  
        ///// <param name="Path"></param>  
        //public static void FolderCreate(string Path)
        //{
        //    // 判断目标目录是否存在如果不存在则新建之  
        //    if (!Directory.Exists(Path))
        //        Directory.CreateDirectory(Path);
        //}

        //#endregion

        //#region 创建目录
        //public static void FileCreate(string Path)
        //{
        //    FileInfo CreateFile = new FileInfo(Path); //创建文件   
        //    if (!CreateFile.Exists)
        //    {
        //        FileStream FS = CreateFile.Create();
        //        FS.Close();
        //    }
        //}
        //#endregion

        //#region 递归删除文件夹目录及文件
        ///**************************************** 
        // * 函数名称：DeleteFolder 
        // * 功能说明：递归删除文件夹目录及文件 
        // * 参    数：dir:文件夹路径 
        // * 调用示列： 
        // *           string dir = Server.MapPath("test/");   
        // *           DotNet.Utilities.FileOperate.DeleteFolder(dir);        
        //*****************************************/
        ///// <summary>  
        ///// 递归删除文件夹目录及文件  
        ///// </summary>  
        ///// <param name="dir"></param>    
        ///// <returns></returns>  
        //public static void DeleteFolder(string dir)
        //{
        //    if (Directory.Exists(dir)) //如果存在这个文件夹删除之   
        //    {
        //        foreach (string d in Directory.GetFileSystemEntries(dir))
        //        {
        //            if (File.Exists(d))
        //                File.Delete(d); //直接删除其中的文件                          
        //            else
        //                DeleteFolder(d); //递归删除子文件夹   
        //        }
        //        Directory.Delete(dir, true); //删除已空文件夹                   
        //    }
        //}

        //#endregion

        //#region 将指定文件夹下面的所有内容copy到目标文件夹下面 果目标文件夹为只读属性就会报错。
        ///**************************************** 
        // * 函数名称：CopyDir 
        // * 功能说明：将指定文件夹下面的所有内容copy到目标文件夹下面 果目标文件夹为只读属性就会报错。 
        // * 参    数：srcPath:原始路径,aimPath:目标文件夹 
        // * 调用示列： 
        // *           string srcPath = Server.MapPath("test/");   
        // *           string aimPath = Server.MapPath("test1/"); 
        // *           DotNet.Utilities.FileOperate.CopyDir(srcPath,aimPath);    
        //*****************************************/
        ///// <summary>  
        ///// 指定文件夹下面的所有内容copy到目标文件夹下面  
        ///// </summary>  
        ///// <param name="srcPath">原始路径</param>  
        ///// <param name="aimPath">目标文件夹</param>  
        //public static void CopyDir(string srcPath, string aimPath)
        //{
        //    try
        //    {
        //        // 检查目标目录是否以目录分割字符结束如果不是则添加之  
        //        if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
        //            aimPath += Path.DirectorySeparatorChar;
        //        // 判断目标目录是否存在如果不存在则新建之  
        //        if (!Directory.Exists(aimPath))
        //            Directory.CreateDirectory(aimPath);
        //        // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组  
        //        //如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法  
        //        //string[] fileList = Directory.GetFiles(srcPath);  
        //        string[] fileList = Directory.GetFileSystemEntries(srcPath);
        //        //遍历所有的文件和目录  
        //        foreach (string file in fileList)
        //        {
        //            //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件  

        //            if (Directory.Exists(file))
        //                CopyDir(file, aimPath + Path.GetFileName(file));
        //            //否则直接Copy文件  
        //            else
        //                File.Copy(file, aimPath + Path.GetFileName(file), true);
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        throw new Exception(ee.ToString());
        //    }
        //}
        //#endregion

        //#region 获取指定文件夹下所有子目录及文件(树形)
        ///**************************************** 
        // * 函数名称：GetFoldAll(string Path) 
        // * 功能说明：获取指定文件夹下所有子目录及文件(树形) 
        // * 参    数：Path:详细路径 
        // * 调用示列： 
        // *           string strDirlist = Server.MapPath("templates");        
        // *           this.Literal1.Text = DotNet.Utilities.FileOperate.GetFoldAll(strDirlist);   
        //*****************************************/
        ///// <summary>  
        ///// 获取指定文件夹下所有子目录及文件  
        ///// </summary>  
        ///// <param name="Path">详细路径</param>  
        //public static string GetFoldAll(string Path)
        //{

        //    string str = "";
        //    DirectoryInfo thisOne = new DirectoryInfo(Path);
        //    str = ListTreeShow(thisOne, 0, str);
        //    return str;

        //}

        ///// <summary>  
        ///// 获取指定文件夹下所有子目录及文件函数  
        ///// </summary>  
        ///// <param name="theDir">指定目录</param>  
        ///// <param name="nLevel">默认起始值,调用时,一般为0</param>  
        ///// <param name="Rn">用于迭加的传入值,一般为空</param>  
        ///// <returns></returns>  
        //public static string ListTreeShow(DirectoryInfo theDir, int nLevel, string Rn)//递归目录 文件  
        //{
        //    DirectoryInfo[] subDirectories = theDir.GetDirectories();//获得目录  
        //    foreach (DirectoryInfo dirinfo in subDirectories)
        //    {

        //        if (nLevel == 0)
        //        {
        //            Rn += "├";
        //        }
        //        else
        //        {
        //            string _s = "";
        //            for (int i = 1; i <= nLevel; i++)
        //            {
        //                _s += "│ ";
        //            }
        //            Rn += _s + "├";
        //        }
        //        Rn += "<b>" + dirinfo.Name.ToString() + "</b><br />";
        //        FileInfo[] fileInfo = dirinfo.GetFiles();   //目录下的文件  
        //        foreach (FileInfo fInfo in fileInfo)
        //        {
        //            if (nLevel == 0)
        //            {
        //                Rn += "│ ├";
        //            }
        //            else
        //            {
        //                string _f = "";
        //                for (int i = 1; i <= nLevel; i++)
        //                {
        //                    _f += "│ ";
        //                }
        //                Rn += _f + "│ ├";
        //            }
        //            Rn += fInfo.Name.ToString() + " <br />";
        //        }
        //        Rn = ListTreeShow(dirinfo, nLevel + 1, Rn);


        //    }
        //    return Rn;
        //}



        ///**************************************** 
        // * 函数名称：GetFoldAll(string Path) 
        // * 功能说明：获取指定文件夹下所有子目录及文件(下拉框形) 
        // * 参    数：Path:详细路径 
        // * 调用示列： 
        // *            string strDirlist = Server.MapPath("templates");       
        // *            this.Literal2.Text = DotNet.Utilities.FileOperate.GetFoldAll(strDirlist,"tpl",""); 
        //*****************************************/
        ///// <summary>  
        ///// 获取指定文件夹下所有子目录及文件(下拉框形)  
        ///// </summary>  
        ///// <param name="Path">详细路径</param>  
        /////<param name="DropName">下拉列表名称</param>  
        /////<param name="tplPath">默认选择模板名称</param>  
        //public static string GetFoldAll(string Path, string DropName, string tplPath)
        //{
        //    string strDrop = "<select name=\"" + DropName + "\" id=\"" + DropName + "\"><option value=\"\">--请选择详细模板--</option>";
        //    string str = "";
        //    DirectoryInfo thisOne = new DirectoryInfo(Path);
        //    str = ListTreeShow(thisOne, 0, str, tplPath);
        //    return strDrop + str + "</select>";

        //}

        ///// <summary>  
        ///// 获取指定文件夹下所有子目录及文件函数  
        ///// </summary>  
        ///// <param name="theDir">指定目录</param>  
        ///// <param name="nLevel">默认起始值,调用时,一般为0</param>  
        ///// <param name="Rn">用于迭加的传入值,一般为空</param>  
        ///// <param name="tplPath">默认选择模板名称</param>  
        ///// <returns></returns>  
        //public static string ListTreeShow(DirectoryInfo theDir, int nLevel, string Rn, string tplPath)//递归目录 文件  
        //{
        //    DirectoryInfo[] subDirectories = theDir.GetDirectories();//获得目录  

        //    foreach (DirectoryInfo dirinfo in subDirectories)
        //    {

        //        Rn += "<option value=\"" + dirinfo.Name.ToString() + "\"";
        //        if (tplPath.ToLower() == dirinfo.Name.ToString().ToLower())
        //        {
        //            Rn += " selected ";
        //        }
        //        Rn += ">";

        //        if (nLevel == 0)
        //        {
        //            Rn += "┣";
        //        }
        //        else
        //        {
        //            string _s = "";
        //            for (int i = 1; i <= nLevel; i++)
        //            {
        //                _s += "│ ";
        //            }
        //            Rn += _s + "┣";
        //        }
        //        Rn += "" + dirinfo.Name.ToString() + "</option>";


        //        FileInfo[] fileInfo = dirinfo.GetFiles();   //目录下的文件  
        //        foreach (FileInfo fInfo in fileInfo)
        //        {
        //            Rn += "<option value=\"" + dirinfo.Name.ToString() + "/" + fInfo.Name.ToString() + "\"";
        //            if (tplPath.ToLower() == fInfo.Name.ToString().ToLower())
        //            {
        //                Rn += " selected ";
        //            }
        //            Rn += ">";

        //            if (nLevel == 0)
        //            {
        //                Rn += "│ ├";
        //            }
        //            else
        //            {
        //                string _f = "";
        //                for (int i = 1; i <= nLevel; i++)
        //                {
        //                    _f += "│ ";
        //                }
        //                Rn += _f + "│ ├";
        //            }
        //            Rn += fInfo.Name.ToString() + "</option>";
        //        }
        //        Rn = ListTreeShow(dirinfo, nLevel + 1, Rn, tplPath);


        //    }
        //    return Rn;
        //}
        //#endregion

        //#region 获取文件夹大小
        ///**************************************** 
        // * 函数名称：GetDirectoryLength(string dirPath) 
        // * 功能说明：获取文件夹大小 
        // * 参    数：dirPath:文件夹详细路径 
        // * 调用示列： 
        // *           string Path = Server.MapPath("templates");  
        // *           Response.Write(DotNet.Utilities.FileOperate.GetDirectoryLength(Path));        
        //*****************************************/
        ///// <summary>  
        ///// 获取文件夹大小  
        ///// </summary>  
        ///// <param name="dirPath">文件夹路径</param>  
        ///// <returns></returns>  
        //public static long GetDirectoryLength(string dirPath)
        //{
        //    if (!Directory.Exists(dirPath))
        //        return 0;
        //    long len = 0;
        //    DirectoryInfo di = new DirectoryInfo(dirPath);
        //    foreach (FileInfo fi in di.GetFiles())
        //    {
        //        len += fi.Length;
        //    }
        //    DirectoryInfo[] dis = di.GetDirectories();
        //    if (dis.Length > 0)
        //    {
        //        for (int i = 0; i < dis.Length; i++)
        //        {
        //            len += GetDirectoryLength(dis[i].FullName);
        //        }
        //    }
        //    return len;
        //}
        //#endregion

        //#region 获取指定文件详细属性
        ///**************************************** 
        // * 函数名称：GetFileAttibe(string filePath) 
        // * 功能说明：获取指定文件详细属性 
        // * 参    数：filePath:文件详细路径 
        // * 调用示列： 
        // *           string file = Server.MapPath("robots.txt");   
        // *            Response.Write(DotNet.Utilities.FileOperate.GetFileAttibe(file));          
        //*****************************************/
        ///// <summary>  
        ///// 获取指定文件详细属性  
        ///// </summary>  
        ///// <param name="filePath">文件详细路径</param>  
        ///// <returns></returns>  
        //public static string GetFileAttibe(string filePath)
        //{
        //    string str = "";
        //    System.IO.FileInfo objFI = new System.IO.FileInfo(filePath);
        //    str += "详细路径:" + objFI.FullName + "<br>文件名称:" + objFI.Name + "<br>文件长度:" + objFI.Length.ToString() + "字节<br>创建时间" + objFI.CreationTime.ToString() + "<br>最后访问时间:" + objFI.LastAccessTime.ToString() + "<br>修改时间:" + objFI.LastWriteTime.ToString() + "<br>所在目录:" + objFI.DirectoryName + "<br>扩展名:" + objFI.Extension;
        //    return str;
        //}
        //#endregion


        //#region 创建空文件
        ///// <summary>
        ///// 创建空文件
        ///// </summary>
        ///// <param name="FileName">文件名，例：Id.txt</param>
        //public static void CreateFile(string FileName)
        //{
        //    if (!File.Exists(@"文件路径"))
        //    {
        //        //创建文件
        //        FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite);
        //        StreamWriter sw = new StreamWriter(fs);
        //        //写入数据
        //        //sw.WriteLine("0");
        //        sw.Close();
        //        fs.Close();
        //    }

        //}
        //#endregion


    }

}
