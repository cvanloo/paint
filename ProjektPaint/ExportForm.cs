using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektPaint
{
    public partial class ExportForm : Form
    {
        public int choose = -1;
        public int qualityIndex;

        public ExportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Legt die Standartwerte fest, wenn die Form geladen wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportForm_Load(object sender, EventArgs e)
        {
            cbJpegQuality.SelectedIndex = 1;
            qualityIndex = cbJpegQuality.SelectedIndex;
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
                choose = 0;
            }
            else if (sender == btnJpeg)
            {
                choose = 1;
            }
            else if (sender == btnBmp)
            {
                choose = 2;
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
            qualityIndex = cbJpegQuality.SelectedIndex;
        }
    }
}
