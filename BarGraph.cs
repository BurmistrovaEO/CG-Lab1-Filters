using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace L_1_filters
{
    class BarGraph
    {
        public long[] resultmas = new long[256];
        public void calculateBarGraphBars(Bitmap sourceImage)
        {
            Color color;

            for(int i=0;i<sourceImage.Width;i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    color = sourceImage.GetPixel(i, j);
                    resultmas[(int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11)]++;
                }
            }
        }
        public Bitmap CreateBarGraph(Bitmap sourceImage,long[] mas)
        {
            int k = 0;
            Bitmap resultImage = new Bitmap(256, 75);
            for (int i = 0; i < resultImage.Width; i++)
            {
                long countQuant;
                if (mas[k] != 0)
                    countQuant = ((sourceImage.Width*sourceImage.Height)/mas[k])/resultImage.Height;
                else
                    countQuant = 0;
                k++;
                for (int j = resultImage.Height-1; j >=0; j--)
                {
                    if (countQuant != 0)
                    {
                        resultImage.SetPixel(i, j, Color.IndianRed);
                        countQuant--;
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, Color.Gray);
                    }
                }
            }
            return resultImage;
        }
    }
}
