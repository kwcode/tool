using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageCompression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Application.ExitThread();
            Application.Exit();
        }

        private void btn_YS_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text.Trim();
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("请选择文件");
                return;
            }
            long Quality = Convert.ToInt64(txtQuality.Text);
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
                string name = file.Name;
                var img = CompressionImage(file, Quality);
                string locPath = AppDomain.CurrentDomain.BaseDirectory + @"\temp\" + DateTime.Now.ToString("yyyyMMddHHmmssss") + System.IO.Path.GetExtension(name);
                HasPathDirectory(locPath);
                string path = CreateImageFromBytes(locPath, img);
                watch.Stop();
                txtMsg.Text = path + "\r\n原图大小(" + (Convert.ToDouble(file.Length) / 1024) + ")KB压缩执行时间" + watch.Elapsed;
            }


        }
        #region Directory目录判断检测
        /// <summary>
        /// Directory目录判断检测 并新增
        /// </summary>
        /// <param name="logPath"></param>
        public static void HasPathDirectory(string logPath)
        {
            string dir = System.IO.Path.GetDirectoryName(logPath);
            if (!System.IO.Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
        #endregion
        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;
            //Image image = BytesToImage(buffer);
            //ImageFormat format = image.RawFormat;
            //if (format.Equals(ImageFormat.Jpeg))
            //{
            //    file += ".jpeg";
            //}
            //else if (format.Equals(ImageFormat.Png))
            //{
            //    file += ".png";
            //}
            //else if (format.Equals(ImageFormat.Bmp))
            //{
            //    file += ".bmp";
            //}
            //else if (format.Equals(ImageFormat.Gif))
            //{
            //    file += ".gif";
            //}
            //else if (format.Equals(ImageFormat.Icon))
            //{
            //    file += ".icon";
            //}
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }
        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        /// <summary>
        /// 壓縮圖片 /// </summary>
        /// <param name="fileStream">圖片流</param>
        /// <param name="quality">壓縮質量0-100之間 數值越大質量越高</param>
        /// <returns></returns>
        private byte[] CompressionImage(Stream fileStream, long quality)
        {
            using (System.Drawing.Image img = System.Drawing.Image.FromStream(fileStream))
            {
                using (Bitmap bitmap = new Bitmap(img))
                {
                    ImageCodecInfo CodecInfo = GetEncoder(img.RawFormat);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, CodecInfo, myEncoderParameters);
                        myEncoderParameters.Dispose();
                        myEncoderParameter.Dispose();
                        return ms.ToArray();
                    }
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                { return codec; }
            }
            return null;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }
    }
}
