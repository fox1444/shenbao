﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace QJY.API
{
    public class ImageCLass
    {


        #region 生成缩略图

        /// <summary>
        /// 根据大图找到缩略图路径
        /// </summary>
        /// <param name="imgPath">大图路径</param>
        /// <returns></returns>
        public static string GetSmallImg(string imgPath)
        {
            return imgPath.Substring(0, imgPath.LastIndexOf('.') - 2) + System.IO.Path.GetExtension(imgPath);
        }

        /// <summary>
        /// 根据大图生成缩略图
        /// </summary>
        /// <param name="savePath">原始图片路径</param>
        /// <param name="picFilePath">原始图片</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        public static void GenSmallImg(string imgPath, int width, int height)
        {
            string smallPath = imgPath.Substring(0, imgPath.LastIndexOf('.')) + "s1" + System.IO.Path.GetExtension(imgPath);

            System.Drawing.Image img = System.Drawing.Image.FromFile(imgPath);
            Bitmap tempBitmap = new Bitmap(width, height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(tempBitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, width, height);
            g.DrawImage(img, rectDestination, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
            KiSaveAsJPEG(tempBitmap, smallPath, 90);
            if (img != null)
                img.Dispose();
            if (tempBitmap != null)
                tempBitmap.Dispose();
        }
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType)
                    return ici;
            }
            return null;
        }

        /// <summary>
        /// 保存为JPEG格式，支持压缩质量选项
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="FileName"></param>
        /// <param name="Qty"></param>
        /// <returns></returns>
        private static bool KiSaveAsJPEG(Bitmap bmp, string FileName, int Qty)
        {
            try
            {
                EncoderParameter p;
                EncoderParameters ps;

                ps = new EncoderParameters(1);

                p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Qty);
                ps.Param[0] = p;
                bmp.Save(FileName, GetCodecInfo("image/jpeg"), ps);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string md5(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            string result = string.Empty;
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(source));

            result = BitConverter.ToString(s).Replace("-", string.Empty);
            return result.ToLower();
        }




    }
}
