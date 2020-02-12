﻿using System;
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

                            shape = new Freehand(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), getDashType(strValue[3]), lPoints);
                            break;
                        case "Line":
                            shape = new Line(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), new Point(Convert.ToInt32(strValue[6]), Convert.ToInt32(strValue[7])), getDashType(strValue[5]));
                            break;
                        case "Rectangle":
                            shape = new ProjektPaint.Model.Rectangle(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), getDashType(strValue[5]), Convert.ToInt32(strValue[6]), Convert.ToInt32(strValue[7]), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Color.FromArgb(Convert.ToInt32(strValue[10])), Convert.ToInt32(strValue[11]));
                            break;
                        case "Square":
                            shape = new Square(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), getDashType(strValue[5]), Convert.ToInt32(strValue[6]), Color.FromArgb(Convert.ToInt32(strValue[7])), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Convert.ToInt32(strValue[10]));
                            break;
                        case "Ellipse":
                            shape = new Ellipse(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), getDashType(strValue[5]), Convert.ToInt32(strValue[6]), Convert.ToInt32(strValue[7]), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Color.FromArgb(Convert.ToInt32(strValue[10])), Convert.ToInt32(strValue[11]));
                            break;
                        case "Circle":
                            shape = new Circle(Convert.ToInt32(strValue[1]), Color.FromArgb(Convert.ToInt32(strValue[2])), new Point(Convert.ToInt32(strValue[3]), Convert.ToInt32(strValue[4])), getDashType(strValue[5]), Convert.ToInt32(strValue[6]), Color.FromArgb(Convert.ToInt32(strValue[7])), Color.FromArgb(Convert.ToInt32(strValue[8])), Color.FromArgb(Convert.ToInt32(strValue[9])), Convert.ToInt32(strValue[10]));
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
        /// List eine Bilddatei ein
        /// </summary>
        /// <param name="img">Das Bild wird daring gespeichert</param>
        /// <param name="path">Der Pfad zum zu öffnenden Bild</param>
        /// <returns></returns>
        public bool OpenFile(ref Image img, string path)
        {
            bool fileIsOpen = false;

            try
            {
                img = Image.FromFile(path);

                fileIsOpen = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Einlesen der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            return fileIsOpen;
        }

        /// <summary>
        /// Gibt den DashType der einem übergebenen String entspricht zurück
        /// </summary>
        /// <param name="dashType">DashType als String</param>
        /// <returns>DashType als DashType</returns>
        public DashType getDashType(string dashType)
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
        /// Speichert das Bild als Textdatei
        /// </summary>
        /// <param name="toSaveForms">Beinhaltet alle zu speichernden Formen</param>
        /// <param name="path">Pfad an dem das Bild gespeichert wird</param>
        /// <returns>Gibt den Speicherort oder null zurück</returns>
        public bool SaveFile(List<Shape> FormsToSave, string path)
        {
            bool savedSuccessful = false;

            if (path != null)
            {
                try
                {
                    if (!File.Exists(path))
                    {
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
                    if (expForm.QualityIndex == 0)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 50L);
                    }
                    else if (expForm.QualityIndex == 1)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 100L);
                    }
                    else if (expForm.QualityIndex == 2)
                    {
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 150L);
                    }
                    else if (expForm.QualityIndex == 3)
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
