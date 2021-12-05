using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace WinFormTesseract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSlcImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if(open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);

                // image file path
                txtBoxImagePath.Text = open.FileName;
            }
        }

        private void btnConvertToText_Click(object sender, EventArgs e)
        {
            //IronTesseract IronOcr = new IronTesseract();

            //var r = IronOcr.Read(txtBoxImagePath.Text);

            //richTextBox1.Text = r.Text;

            // -- use tesseract -- //
            try
            {
                var ocrengine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
                var img = Pix.LoadFromFile(txtBoxImagePath.Text);
                var res = ocrengine.Process(img);
                richTextBox1.Text = res.GetText();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            
        }
    }
}
