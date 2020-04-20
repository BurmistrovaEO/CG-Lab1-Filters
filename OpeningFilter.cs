using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace L_1_filters
{
    class OpeningFilter:MatrixFilter
    {
        public OpeningFilter()
        {
            this.kernel = null;
        }

        public OpeningFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage,BackgroundWorker worker)
        {
            Dilation dilation;
            Erosion erosion;
            if (kernel != null)
            {
                dilation = new Dilation(this.kernel);
                erosion = new Erosion(this.kernel);
            }
            else
            {
                dilation = new Dilation();
                erosion = new Erosion();
            }
            return dilation.processImage(erosion.processImage(sourceImage, worker), worker);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
