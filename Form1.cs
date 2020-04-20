using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L_1_filters
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Color pickedColor;
        Color pickedbadColor;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаём диалог для открытия файла
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image,backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чёрнобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SepiaFilter filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void контрастToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ContrastFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            Bitmap resultImage = filter.processIm(image);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            Bitmap im = new Bitmap(pictureBox1.Image);
            Filters filter1 = new EmbossingFilter(im);
            backgroundWorker1.RunWorkerAsync(filter1);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorldFilter();
            filter.calculateAvg(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void растяжениеКонтрастностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new AutolevelsFilter();
            filter.calculateMinMax(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void задатьВручнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog outercolorDialog = new ColorDialog();
            {
                if (outercolorDialog.ShowDialog() == DialogResult.OK)
                {
                    pickedbadColor = outercolorDialog.Color;
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        pickedColor = colorDialog.Color;
                        BaseColorCorrectionFilter filter = new BaseColorCorrectionFilter();
                        filter.idColor(image,pickedbadColor,pickedColor);
                        backgroundWorker1.RunWorkerAsync(filter);
                    }
                }
            }
        }

        private void сохранитьРезультатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            saveFile.Title = "Сохранить файл";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFile.OpenFile();
                switch(saveFile.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
                fs.Close();
            }
        }
        Bitmap imagetmp;
        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarGraph bargr = new BarGraph();
            imagetmp = (Bitmap)pictureBox1.Image;
            bargr.calculateBarGraphBars(imagetmp);
            pictureBox1.Image = bargr.CreateBarGraph(imagetmp,bargr.resultmas);
            pictureBox1.Refresh();
        }

        private void вернутьсяКИзображениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imagetmp;
            pictureBox1.Refresh();
        }

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningFilter filter = new OpeningFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosingFilter filter = new ClosingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
