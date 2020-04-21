using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class Transition : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker) //////3333333
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / sourceImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(Clamp(i+50,0,sourceImage.Width-1), Clamp(j,0,sourceImage.Height-1), calculateNewPixelColor(sourceImage, Clamp(i, 0, sourceImage.Height-1), Clamp(j, 0, sourceImage.Height-1)));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color returnColor = sourceImage.GetPixel(x,y);
            return returnColor;
        }
    }
}
