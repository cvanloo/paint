using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ProjektPaint.Model.Enums;

namespace ProjektPaint
{
    public partial class ExportForm : Form
    {
        private long qualityIndex = 100L;
        private Bitmap Bmp;

        public ExportForm(Bitmap bmp)
        {
            InitializeComponent();

            cbJpegQuality.SelectedIndex = 1;
            this.Bmp = bmp;
        }

        /// <summary>
        /// Legt das Format zum Exportieren fest
        /// </summary>
        /// <param name="sender">Bestimmt das Format</param>
        /// <param name="e"></param>
        private void btnChooseType_Click(object sender, EventArgs e)
        {
            if (sender == btnPng)
            {
                Export("png (*.png)|*.png");
            }
            else if (sender == btnJpeg)
            {
                Export("jpeg (*.jpeg)|*.jpeg");
            }
            else if (sender == btnBmp)
            {
                Export("Bitmap (*.bmp)|*.bmp");
            }
        }

        /// <summary>
        /// Legt bei Jpeg die Stärke der Qualitätskompression fest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbJpegQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbJpegQuality.SelectedIndex)
            {
                case 0:
                    qualityIndex = 50L;
                    break;
                case 1:
                    qualityIndex = 100L;
                    break;
                case 2:
                    qualityIndex = 150L;
                    break;
                case 3:
                    qualityIndex = 200L;
                    break;
            }
        }

        private void Export(string fileFormat)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = fileFormat;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileOp fop = new FileOp();

                switch (fileFormat)
                {
                    case "png (*.png)|*.png":
                        fop.ConvertAndExport(Bmp, sfd.FileName, ImageFormat.Png, qualityIndex);
                        break;
                    case "jpeg (*.jpeg)|*.jpeg":
                        fop.ConvertAndExport(Bmp, sfd.FileName, ImageFormat.Jpeg, qualityIndex);
                        break;
                    case "Bitmap (*.bmp)|*.bmp":
                        fop.ConvertAndExport(Bmp, sfd.FileName, ImageFormat.Bmp, qualityIndex);
                        break;
                }

                this.Close();
            }
        }
    }
}
