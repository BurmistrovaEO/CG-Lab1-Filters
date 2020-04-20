using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace L_1_filters
{
    class GrayWorldFilter:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {           
            Color sourceColor = sourceImage.GetPixel(x,y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R*avg/sumR,0,255), Clamp(sourceColor.G * avg / sumG, 0, 255), Clamp(sourceColor.B *avg / sumB, 0, 255));
            return resultColor;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker) //////3333333
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / sourceImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
    }
}
