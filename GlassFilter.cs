using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_1_filters
{
    class GlassFilter : MatrixFilter
    {
        public GlassFilter()
        {
            kernel = new float[3, 3];
        }
        public GlassFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker) //////3333333
        {
            Random rnd = new Random();
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / sourceImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp((int)(i + k + (rnd.Next(-radiusX, radiusX) - 0.5) * 8), 0, sourceImage.Width - 1);
                            int idY = Clamp((int)(j + l + (rnd.Next(-radiusX, radiusX) - 0.5) * 8), 0, sourceImage.Height - 1);
                            resultImage.SetPixel(idX , idY, calculateNewPixelColor(sourceImage, i, j));
                        }

                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color returnColor = sourceImage.GetPixel(x, y);
            return returnColor;
        }
    }
}
