using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjektPaint.Model;
using System.IO;
using ProjektPaint.Properties;

namespace ProjektPaint
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Erstellt ein neues Bild
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormMain Main = new FormMain(null, null, null);
            Main.Show();
            this.Dispose();
        }

        /// <summary>
        /// Beendet das Programm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbort_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Öffnet ein bestehendes Bild
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            FileOp fop = new FileOp();
            List<Shape> lForm = new List<Shape>();
            Image img = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Alle Dateien|*.prjp;*.jpg;*.png;*.bmp" +
                    "| Projekt Paint (*.prjp)|*.prjp" +
                    "| JPEG (*.jpg)|*.jpg" +
                    "| PNG (*.png)|*.png" +
                    "| Bitmap (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bool succeed = false;

                if (Path.GetExtension(ofd.FileName) == ".prjp")
                {
                    succeed = fop.OpenFile(ref lForm, ofd.FileName);
                }
                else
                {
                    succeed = fop.OpenImage(ref img, ofd.FileName);
                }

                if (succeed)
                {
                    FormMain Main = new FormMain(ofd.FileName, lForm, img);
                    Main.Show();
                    this.Dispose();
                }
            }
        }
    }
}
