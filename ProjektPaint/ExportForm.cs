using System;
using System.Windows.Forms;
using ProjektPaint.Model.Enums;

namespace ProjektPaint
{
    public partial class ExportForm : Form
    {
        private long qualityIndex = 100L;
        private FileFormat choiceFileFormat = FileFormat.PNG;

        public long QualityIndex
        {
            get { return qualityIndex; }
        }

        public FileFormat ChoiceFileFormat
        {
            get { return choiceFileFormat; }
        }

        public ExportForm()
        {
            InitializeComponent();

            cbJpegQuality.SelectedIndex = 1;
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
                choiceFileFormat = FileFormat.PNG;
            }
            else if (sender == btnJpeg)
            {
                choiceFileFormat = FileFormat.JPEG;
            }
            else if (sender == btnBmp)
            {
                choiceFileFormat = FileFormat.BMP;
            }

            this.Close();
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
    }
}
