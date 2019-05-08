﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace NETCORE.ThoughtWorks.QRCode
{
    class Class1
    {

        public void Button1_Click()
        {
            create_two("SDSS");
        }

        private void create_two(string nr)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(nr);

            string filename = string.Format(DateTime.Now.ToString(), "yyyymmddhhmmss");
            filename = filename.Replace(" ", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("-", "");
            filename = filename.Replace(".", "");
            filename = filename.Replace("/", "");
            CombinImage(image, "f:/123456.jpg").Save("f:/" + filename + ".jpg");

            //this.Image1.ImageUrl = "~/image/" + filename + ".jpg";

        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg);        //照片图片      
            if (img.Height != 65 || img.Width != 65)
            {
                img = KiResizeImage(img, 65, 65, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}