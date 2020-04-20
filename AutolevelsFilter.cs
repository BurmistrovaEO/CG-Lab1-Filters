using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace L_1_filters
{
    class AutolevelsFilter : Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x,y);
            Color resultColor = Color.FromArgb(Clamp((color.R-minR)*(255-0)/(maxR-minR),0,255), Clamp((color.G - minG) * (255-0) / (maxG - minG), 0, 255), Clamp((color.B - minB) * (255-0) / (maxB - minB), 0, 255));
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
