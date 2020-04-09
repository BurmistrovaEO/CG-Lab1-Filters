﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace L_1_filters
{
    abstract class Filters
    {   public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker) //////3333333
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width,sourceImage.Height);
            for(int i=0;i<sourceImage.Width;i++)
            {
                worker.ReportProgress((int)((float)i/sourceImage.Width*100));
                for(int j=0;j<sourceImage.Height;j++)
                {
                    resultImage.SetPixel(i,j,calculateNewPixelColor(sourceImage,i,j));
                }
            }
            return resultImage;            
        }
        public Bitmap processIm(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
    }
}
