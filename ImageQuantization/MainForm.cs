using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImageQuantization
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
                
                txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
                txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
                DistColBox.Text = "";
                MSTSumBox.Text = "";
                timeBox.Text = "";
                operationsSWBox.Text = "";
            }
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            double sigma = double.Parse(txtGaussSigma.Text);
            int maskSize = (int)nudMaskSize.Value;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void btnQuantize_Click(object sender, EventArgs e)
        {
            // get k from input box
            int k = int.Parse(KClustBox.Text);

            // quantizer instance, will be used to get MSTSum and number of DistinctColors
            var quantizer = new ImageOperations.Quantizer();

            // measure time taken to quantize image
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // start quantization functions chain
            quantizer.quantize(ImageMatrix,k);
            sw.Stop();

            // get MSTSum and number of DistinctColors for displaying in form
            MSTSumBox.Text = quantizer.getMSTSum().ToString();
            DistColBox.Text = quantizer.getDistinctColoursCount().ToString();
            timeBox.Text = sw.Elapsed.ToString("mm\\:ss\\.ff");

            // time for distinct colors
            operationsSWBox.Text = quantizer.operationsSW.Elapsed.ToString("mm\\:ss\\.ff");

            // get quantized Image for displaying in form
            RGBPixel[,] QuantizedImage = quantizer.getImage();
            ImageOperations.DisplayImage(QuantizedImage, pictureBox2);
        }

    }
}