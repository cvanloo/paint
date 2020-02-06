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
            FormMain Main = new FormMain(null, null);
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

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Projekt Paint (*.prjp)|*.prjp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string newPath = fop.OpenFile(ref lForm, ofd.FileName);

                if (newPath != null)
                {
                    FormMain Main = new FormMain(newPath, lForm);
                    Main.Show();
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// Zeichnet das Hintergrundbild in das Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Image img = Resources.startbild;
            Graphics graphics = Graphics.FromImage(img);
            e.Graphics.DrawImage(img, 0, 0);
        }
    }
}
