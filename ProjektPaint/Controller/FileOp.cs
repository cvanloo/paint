using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ProjektPaint.Model;
using ProjektPaint.Model.Enums;

namespace ProjektPaint
{
    public class FileOp
    {
        public FileOp() { }

        /// <summary>
        /// Liest ein Bild ein
        /// </summary>
        /// <param name="lForm">Die Shapes aus dem neuen Bild werden darin gespeichert</param>
        /// <param name="path">Pfad von dem zu öffnenden Bild</param>
        /// <returns>Gibt den Pfad oder null zurück</returns>
        public bool OpenFile(ref List<Shape> lForm, string path)
        {
            List<Shape> newForm = new List<Shape>();

            string[] fileText = File.ReadAllLines(path);

            //Das 2-Dimensionale Array shapes wird so gross deklariert wie mindestens nötig
            //um alle Formen richtig darin speichern zu können

            //Grösste Anzahl Daten in einem String suchen
            int longestDimension = 0;
            foreach (string str in fileText)
            {
                int sem = 0;
                foreach (char cVar in str)
                {
                    if (cVar == ';')
                    {
                        sem++;
                    }
                }

                if (sem > longestDimension)
                {
                    longestDimension = sem;
                }
            }

            string[,] shapes = new string[fileText.Length, longestDimension+1];
            
            try
            {
                //Eingelesene Datein an richtige Position in shapes kopieren
                for(int i = 0; i < fileText.Length; i++)
                {
                    string value = "";
                    int j = 0;

                    foreach (char cVar in fileText[i])
                    {
                        if (cVar != ';')
                        {
                            value += cVar;
                        }
                        else
                        {
                            shapes[i, j] = value;

                            value = "";
                            j++;
                        }
                    }
                }

                //Shapes erstellen und zur Form-Liste hinzufügen
                for (int i = 0; i < fileText.Length; i++)
                {
                    Shape shape = null;
                    string type = shapes[i, 0];

                    List<Point> Points = new List<Point>();

                    if (type == "Freehand")
                    {
                        int j = 6;
                        while (shapes[i, j] != null)
                        {
                            Points.Add(new Point(Convert.ToInt32(shapes[i, j++]), Convert.ToInt32(shapes[i, j++])));
                        }
                    }

                    switch (type)
                    {
                        case "Rectangle":
                            shape = new ProjektPaint.Model.Rectangle(Convert.ToInt32(shapes[i, 1]), Color.FromArgb(Convert.ToInt32(shapes[i, 2])), new Point(Convert.ToInt32(shapes[i, 3]), Convert.ToInt32(shapes[i, 4])), getDashType(shapes[i, 5]), Convert.ToInt32(shapes[i, 6]), Convert.ToInt32(shapes[i, 7]), Color.FromArgb(Convert.ToInt32(shapes[i, 8])), Color.FromArgb(Convert.ToInt32(shapes[i, 9])), Color.FromArgb(Convert.ToInt32(shapes[i, 10])), Convert.ToInt32(shapes[i, 11]));
                            break;
                        case "Line":
                            shape = new ProjektPaint.Model.Line(Convert.ToInt32(shapes[i, 1]), Color.FromArgb(Convert.ToInt32(shapes[i, 2])), new Point(Convert.ToInt32(shapes[i, 3]), Convert.ToInt32(shapes[i, 4])), new Point(Convert.ToInt32(shapes[i, 6]), Convert.ToInt32(shapes[i, 7])), getDashType(shapes[i, 5]));
                            break;
                        case "Circle":
                            shape = new ProjektPaint.Model.Circle(Convert.ToInt32(shapes[i, 1]), Color.FromArgb(Convert.ToInt32(shapes[i, 2])), new Point(Convert.ToInt32(shapes[i, 3]), Convert.ToInt32(shapes[i, 4])), getDashType(shapes[i, 5]), Convert.ToInt32(shapes[i, 6]), Color.FromArgb(Convert.ToInt32(shapes[i, 7])), Color.FromArgb(Convert.ToInt32(shapes[i, 8])), Color.FromArgb(Convert.ToInt32(shapes[i, 9])), Convert.ToInt32(shapes[i, 10]));
                            break;
                        case "Square":
                            shape = new ProjektPaint.Model.Square(Convert.ToInt32(shapes[i, 1]), Color.FromArgb(Convert.ToInt32(shapes[i, 2])), new Point(Convert.ToInt32(shapes[i, 3]), Convert.ToInt32(shapes[i, 4])), getDashType(shapes[i, 5]), Convert.ToInt32(shapes[i, 6]), Color.FromArgb(Convert.ToInt32(shapes[i, 7])), Color.FromArgb(Convert.ToInt32(shapes[i, 8])), Color.FromArgb(Convert.ToInt32(shapes[i, 9])), Convert.ToInt32(shapes[i, 10]));
                            break;
                        case "Freehand":
                            shape = new ProjektPaint.Model.Freehand(Convert.ToInt32(shapes[i, 1]), Color.FromArgb(Convert.ToInt32(shapes[i, 2])), getDashType(shapes[i, 5]), Points);
                            break;
                        case "Ellipse":
                            shape = new ProjektPaint.Model.Ellipse(Convert.ToInt32(shapes[i, 1]), Color.FromArgb(Convert.ToInt32(shapes[i, 2])), new Point(Convert.ToInt32(shapes[i, 3]), Convert.ToInt32(shapes[i, 4])), getDashType(shapes[i, 5]), Convert.ToInt32(shapes[i, 6]), Convert.ToInt32(shapes[i, 7]), Color.FromArgb(Convert.ToInt32(shapes[i, 8])), Color.FromArgb(Convert.ToInt32(shapes[i, 9])), Color.FromArgb(Convert.ToInt32(shapes[i, 10])), Convert.ToInt32(shapes[i, 11]));
                            break;
                    }

                    newForm.Add(shape);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Einlesen der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                return false;
            }

            lForm = newForm;

            return true;
        }

        /// <summary>
        /// Gibt den DashType der einem übergebenen String entspricht zurück
        /// </summary>
        /// <param name="dashType">DashType als String</param>
        /// <returns>DashType als DashType</returns>
        public DashType getDashType(string dashType)
        {
            DashType pattern = DashType.Solid;

            if (dashType == "Dotted")
            {
                pattern = DashType.Dotted;
            }
            else if (dashType == "Dashed")
            {
                pattern = DashType.Dashed;
            }

            return pattern;
        }

        /// <summary>
        /// Speichert das Bild als Textdatei
        /// </summary>
        /// <param name="toSaveForms">Beinhaltet alle zu speichernden Formen</param>
        /// <param name="path">Pfad an dem das Bild gespeichert wird</param>
        /// <returns>Gibt den Speicherort oder null zurück</returns>
        public bool SaveFile(List<Shape> FormsToSave, string path)
        {
            if (File.Exists(path))
            {
                string[] fileText = AllFormInfos(FormsToSave);

                try
                {
                    File.WriteAllLines(path, fileText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Speichern der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kopiert alle nötigen Daten aus der Shape-List in ein String-Array
        /// </summary>
        /// <param name="toWriteText">Alle abzuspeichernden Daten werden darin gespeichert</param>
        /// <param name="toSaveForms">Beinhaltet alle Formen die abgespeichert werden sollen</param>
        private string[] AllFormInfos(List<Shape> toSaveForms)
        {
            string[] toWriteText = new string[toSaveForms.Count];

            for (int i = 0; i < toWriteText.Length; i++)
            {
                toWriteText[i] = toSaveForms[i].ConvertDataToString();
            }

            return toWriteText;
        }

        /// <summary>
        /// Exportieren des Bildes als PNG, JPEG oder BMP
        /// </summary>
        /// <param name="bmp">Zu exportierendes Bild</param>
        public void ConvertAndExport(Bitmap bmp)
        {
            bool repeatFunc = false;
            do
            {
                //Dateiformat auswählen
                ExportForm expForm = new ExportForm();
                expForm.ShowDialog();
                int choose = expForm.choose;
                int quality = expForm.qualityIndex;

                //Zu Exportierende Datei anwählen
                SaveFileDialog sfd = new SaveFileDialog();
                if (choose == 0)
                {
                    sfd.Filter = "png (*.png)|*.png";
                }
                else if (choose == 1)
                {
                    sfd.Filter = "jpeg (*.jpeg)|*.jpeg";
                }
                else if (choose == 2)
                {
                    sfd.Filter = "Bitmap (*.bmp)|*.bmp";
                }
                else
                {
                    return;
                }

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //Richtigen Enconder finden
                    ImageCodecInfo fEncoder = GetEncoder(ImageFormat.Jpeg);

                    if (sfd.FileName.Contains(".jpeg"))
                    {
                        fEncoder = GetEncoder(ImageFormat.Jpeg);
                    }
                    else if (sfd.FileName.Contains(".png"))
                    {
                        fEncoder = GetEncoder(ImageFormat.Png);
                    }
                    else if (sfd.FileName.Contains(".bmp"))
                    {
                        fEncoder = GetEncoder(ImageFormat.Bmp);
                    }

                    //Encoder basierend auf dem Quality-Objekt erstellen
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    System.Drawing.Imaging.EncoderParameter myEncoderParameter = null;
                    if (quality == 0)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 50L);
                    }
                    else if (quality == 1)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 100L);
                    }
                    else if (quality == 2)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 150L);
                    }
                    else if (quality == 3)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 200L);
                    }

                    myEncoderParameters.Param[0] = myEncoderParameter;

                    try
                    {
                        bmp.Save(sfd.FileName, fEncoder, myEncoderParameters);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    repeatFunc = true;
                }
            } while (repeatFunc);
        }

        /// <summary>
        /// Gibt den Encoder zum Exportieren im gewählten Format zurück
        /// </summary>
        /// <param name="format">Format in das exportiert werden soll</param>
        /// <returns></returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }
}
