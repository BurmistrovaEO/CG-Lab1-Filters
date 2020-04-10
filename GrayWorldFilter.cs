﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


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
    }
}
