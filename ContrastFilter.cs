using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class ContrastFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x,y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + 30,0,255),Clamp(sourceColor.G + 30,0,255), Clamp(sourceColor.B +30,0,255));
            return resultColor;
        }
    }
}
