using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjektPaint.Model.Enums;

namespace ProjektPaint
{
    public partial class ExportForm : Form
    {
        private long qualityIndex;
        private FileFormat choiceFileFormat;

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
            switch(cbJpegQuality.SelectedItem.ToString())
            {
                case "50L":
                    qualityIndex = 50L;
                    break;
                case "100L":
                    qualityIndex = 100L;
                    break;
                case "150L":
                    qualityIndex = 150L;
                    break;
                case "200L":
                    qualityIndex = 200L;
                    break;
            }
        }
    }
}
