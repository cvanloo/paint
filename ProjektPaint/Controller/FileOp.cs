using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ProjektPaint.Model;
using ProjektPaint.Model.Enums;
using Microsoft.VisualBasic.FileIO;

namespace ProjektPaint
{
    public class FileOp
    {
        public FileOp() { }

        /// <summary>
        /// Liest ein als csv gespeichertes Bild ein
        /// </summary>
        /// <param name="lForm">Die Formen werden darin gespeichert</param>
        /// <param name="path">Der Pfad zum zu öffnenden Bild</param>
        /// <returns></returns>
        public bool OpenFile(ref List<Shape> lForm, string path)
        {
            bool fileIsOpen = false;

            string[] fileText = File.ReadAllLines(path);
            List<Shape> newForms = new List<Shape>();

            try
            {
                foreach (string str in fileText)
                {
                    string[] strValue = str.Split(';');

                    Shape shape = null;

                    //Shape erstellen
                    switch (strValue[0])
                    {
                        case "Freehand":
                            List<Point> lPoints = new List<Point>();
                            for (int i = 4; i < strValue.Length; i += 2)
                            {
                                if (strValue[i] != "" && strValue[i + 1] != "")
                                {
                                    lPoints.Add(new Point(Convert.ToInt32(strValue[i]), Convert.ToInt32(strValue[i + 1])));
                                }
                            }

                            shape = new Freehand(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), GetDashType(strValue[3]), lPoints);
                            break;
                        case "Line":
                            shape = new Line(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), new Point(Convert.ToInt32(strValue[6]), Convert.ToInt32(strValue[7])), GetDashType(strValue[5]));
                            break;
                        case "Rectangle":
                            shape = new ProjektPaint.Model.Rectangle(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), GetDashType(strValue[5]), Convert.ToInt32(strValue[6]), Convert.ToInt32(strValue[7]), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Color.FromArgb(Convert.ToInt32(strValue[10])), Convert.ToInt32(strValue[11]));
                            break;
                        case "Square":
                            shape = new Square(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), GetDashType(strValue[5]), Convert.ToInt32(strValue[6]), Color.FromArgb(Convert.ToInt32(strValue[7])), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Convert.ToInt32(strValue[10]));
                            break;
                        case "Ellipse":
                            shape = new Ellipse(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), GetDashType(strValue[5]), Convert.ToInt32(strValue[6]), Convert.ToInt32(strValue[7]), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Color.FromArgb(Convert.ToInt32(strValue[10])), Convert.ToInt32(strValue[11]));
                            break;
                        case "Circle":
                            shape = new Circle(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), GetDashType(strValue[5]), Convert.ToInt32(strValue[6]), Color.FromArgb(Convert.ToInt32(strValue[7])), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Convert.ToInt32(strValue[10]));
                            break;
                    }

                    newForms.Add(shape);
                }

                fileIsOpen = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Einlesen der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            lForm = newForms;    

            return fileIsOpen;
        }

        /// <summary>
        /// Gibt den DashType der einem übergebenen String entspricht zurück
        /// </summary>
        /// <param name="dashType">DashType als String</param>
        /// <returns>DashType als DashType</returns>
        private DashType GetDashType(string dashType)
        {
            DashType pattern = DashType.Solid;

            switch (dashType)
            {
                case "Dotted":
                    pattern = DashType.Dotted;
                    break;
                case "Dashed":
                    pattern = DashType.Dashed;
                    break;
            }

            return pattern;
        }

        /// <summary>
        /// List eine Bilddatei ein
        /// </summary>
        /// <param name="img">Das Bild wird daring gespeichert</param>
        /// <param name="path">Der Pfad zum zu öffnenden Bild</param>
        /// <returns></returns>
        public bool OpenImage(ref Image img, string path)
        {
            bool fileIsOpen = false;

            try
            {
                FileInfo fileInfo = new FileInfo(path);
                string tempPath = SpecialDirectories.Temp + "\\tempPicture" + fileInfo.Extension;
                File.Copy(path, tempPath, true);

                img = Image.FromFile(tempPath);

                fileIsOpen = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Einlesen der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
            return fileIsOpen;
        }

        /// <summary>
        /// Speichert das Bild als Textdatei
        /// </summary>
        /// <param name="toSaveForms">Beinhaltet alle zu speichernden Formen</param>
        /// <param name="path">Pfad an dem das Bild gespeichert wird</param>
        /// <returns>Gibt true zurück, wenn das Speichern erfolgreich war</returns>
        public bool SaveFile(List<Shape> FormsToSave, string path)
        {
            bool savedSuccessful = false;

            if (path != null)
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        //Wenn die Datei nicht existiert, wird eine neue erstellt
                        File.Create(path).Close();
                    }

                    string[] fileText = AllFormInfos(FormsToSave);

                    File.WriteAllLines(path, fileText);

                    savedSuccessful = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Speichern der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            return savedSuccessful;
        }

        /// <summary>
        /// Speichert das Bild als PNG, JPEG oder BMP
        /// </summary>
        /// <param name="bmp">Das zu speichernde Bild</param>
        /// <param name="path">Pfad an dem das Bild gespeichert wird</param>
        /// <returns>Gibt true zurück, wenn das Speichern erfolgreich war</returns>
        public bool SaveImg(Bitmap bmp, string path)
        {
            bool savedSuccessful = false;

            if(path.Contains(".png"))
            {
                savedSuccessful = ConvertAndExport(bmp, path, ImageFormat.Png, 100L);
            }
            else if(path.Contains(".jpg") || path.Contains(".jpeg"))
            {
                savedSuccessful = ConvertAndExport(bmp, path, ImageFormat.Jpeg, 200L);
            }
            else
            {
                savedSuccessful = ConvertAndExport(bmp, path, ImageFormat.Bmp, 100L);
            }

            return savedSuccessful;
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
        public void ExportAs(Bitmap bmp)
        {
            bool repeatFunc = false;
            do
            {
                //Dateiformat auswählen
                ExportForm expForm = new ExportForm();
                expForm.ShowDialog();

                //Zu Exportierende Datei anwählen
                SaveFileDialog sfd = new SaveFileDialog();
                if (expForm.ChoiceFileFormat == FileFormat.PNG)
                {
                    sfd.Filter = "png (*.png)|*.png";
                }
                else if (expForm.ChoiceFileFormat == FileFormat.JPEG)
                {
                    sfd.Filter = "jpeg (*.jpeg)|*.jpeg";
                }
                else if (expForm.ChoiceFileFormat == FileFormat.BMP)
                {
                    sfd.Filter = "Bitmap (*.bmp)|*.bmp";
                }
                else
                {
                    return;
                }

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName.Contains(".jpeg"))
                    {
                        ConvertAndExport(bmp, sfd.FileName, ImageFormat.Jpeg, expForm.QualityIndex);
                    }
                    else if (sfd.FileName.Contains(".png"))
                    {
                        ConvertAndExport(bmp, sfd.FileName, ImageFormat.Png, 200L);
                    }
                    else if (sfd.FileName.Contains(".bmp"))
                    {
                        ConvertAndExport(bmp, sfd.FileName, ImageFormat.Bmp, 100L);
                    }
                }
                else
                {
                    repeatFunc = true;
                }

                expForm.Dispose();
            }
            while (repeatFunc);
        }

        public bool ConvertAndExport(Bitmap bmp, string path, ImageFormat imgFormat, long quality)
        {
            bool exportSuccessful = false;

            //Richtigen Enconder finden
            ImageCodecInfo fEncoder = GetEncoder(imgFormat);
                    
            //Encoder basierend auf dem Quality-Objekt erstellen
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            System.Drawing.Imaging.EncoderParameter myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, quality);
                    
            myEncoderParameters.Param[0] = myEncoderParameter;

            try
            {
                bmp.Save(path, fEncoder, myEncoderParameters);

                exportSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nHinweis: Das Bild kann nicht in dieselbe Datei gespeichert werden, aus der es erstellt wurde.\nSpeichern Sie das Bild unter einem anderen Pfad.", "Fehler beim Exportieren", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            myEncoderParameters.Dispose();

            return exportSuccessful;
        }

        /// <summary>
        /// Gibt den Encoder zum Exportieren im gewählten Format zurück
        /// </summary>
        /// <param name="format">Format in das exportiert werden soll</param>
        /// <returns>Gibt den Encoder oder null zurück</returns>
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
