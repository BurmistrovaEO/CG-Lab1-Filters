using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class TopHatFilter:MatrixFilter
    {
        public TopHatFilter()
        {
            this.kernel = null;
        }
        public TopHatFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            OpeningFilter opening;
            if(this.kernel == null)
            {
                opening = new OpeningFilter();
            }
            else
            {
                opening = new OpeningFilter(this.kernel);
            }
            Subtraction subtraction = new Subtraction(sourceImage);
            return subtraction.processImage(opening.processImage(sourceImage,worker),worker);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
