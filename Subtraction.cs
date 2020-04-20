using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class Subtraction : Filters
    {
        Bitmap mMinuedImage = null;
        public Subtraction(Bitmap minuendImage)
        {
            mMinuedImage = minuendImage;
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

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color minuedColor = mMinuedImage.GetPixel(x,y);
            Color subtrahendColor = sourceImage.GetPixel(x,y);
            return Color.FromArgb(Clamp(minuedColor.R - subtrahendColor.R, 0, 255),
                                  Clamp(minuedColor.G - subtrahendColor.G, 0, 255),
                                  Clamp(minuedColor.B - subtrahendColor.B, 0, 255));
        }
    }
}
