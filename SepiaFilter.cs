using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            //В следующей строке кода k=16.2 . При увеличении этого значения коричнево-золотые оттенки становятся отчётливее и насыщеннее.
            //При уменьшении - приближаются к ч.-б.
            Color resultColor = Color.FromArgb(Clamp((int)(Intensity + 2*16.2),0,255),Clamp((int)(Intensity + 16.2 * 0.5),0,255),Clamp((int)(Intensity - 16.2),0,255));
            return resultColor;
        }
    }
}
