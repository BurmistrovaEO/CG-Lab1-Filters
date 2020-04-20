using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class BlackHatFilter:MatrixFilter
    {
        public BlackHatFilter()
        {
            this.kernel = null;
        }
        public BlackHatFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            ClosingFilter closing;
            if(this.kernel ==null)
            {
                closing = new ClosingFilter();
            }
            else
            {
                closing = new ClosingFilter(this.kernel);
            }
            Subtraction subtraction = new Subtraction(closing.processImage(sourceImage,worker));
            return subtraction.processImage(sourceImage,worker);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotFiniteNumberException();
        }
    }
}
