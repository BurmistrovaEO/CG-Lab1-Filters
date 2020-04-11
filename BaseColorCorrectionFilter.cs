using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class BaseColorCorrectionFilter : Filters
    {
        protected Color colPicked;
        protected Color badcolPicked;
        public void idColor(Bitmap sourceImage,Color bad,Color c)
        {
            badcolPicked = bad;
            colPicked = c;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x,y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R*colPicked.R/badcolPicked.R,0,255), Clamp(sourceColor.G * colPicked.G / badcolPicked.G, 0, 255), Clamp(sourceColor.B * colPicked.B / badcolPicked.B, 0, 255));
            return resultColor;
        }
    }
}
