using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace GIFMakerAPI
{
    public static class Util
    {
        public static Image PretvoriUImage(string base64)
        {
            if (base64.Contains(","))            
                base64 = base64.Substring(base64.IndexOf(",") + 1);            
                    
            byte[] bytes = Convert.FromBase64String(base64);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))            
                image = Image.FromStream(ms);            
            
            return resizeImage(image, new Size(400, 400));
        }

        //https://www.c-sharpcorner.com/UploadFile/ishbandhu2009/resize-an-image-in-C-Sharp/
        private static System.Drawing.Image resizeImage(Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        public static string NapraviMD5Hash(string naziv)
        {     
            using (var md5 = MD5.Create())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(naziv);
                byte[] hashBytes = md5.ComputeHash(textBytes);

                return BitConverter.ToString(hashBytes).Replace("-", String.Empty);                
            }
        }       
    }
}
