﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using ProjektPaint.Model;

namespace ProjektPaint
{
    public class ImageDrawing
    {
        private Graphics Grphx { get; set; }
        private SplitContainer SplitCon { get; set; }
        private Bitmap Bmp { get; set; }

        public ImageDrawing(Graphics grphx, SplitContainer splitCon, Bitmap bmp)
        {
            this.Grphx = grphx;
            this.SplitCon = splitCon;
            this.Bmp = bmp;
        }

        /// <summary>
        /// Alle Formen in die Bitmap zeichnen
        /// </summary>
        /// <param name="fElement">Beinhaltet alle zu zeichnenden Formen</param>
        public void DrawImage(List<Shape> fElement, Image img)
        {
            //Ganze Bitmap weiss zeichnen
            Grphx.FillRectangle(Brushes.White, 0, 0, SplitCon.Panel2.Width, SplitCon.Panel2.Height);

            if (img != null)
            {
                //Das Bild in die Bitmap zeichnen
                Grphx.DrawImage(img, new System.Drawing.Rectangle(new Point(0, 0), ConvertImageSize(img)));
            }

            //Alle Shapes in die Bitmap zeichnen
            for (int i = 0; i < fElement.Count; i++)
            {
                fElement.ElementAt(i).Draw(Grphx);
            }

            //Bitmap neu zeichnen
            Graphics gr = SplitCon.Panel2.CreateGraphics();
            gr.DrawImage(Bmp, 0, 0);
            gr.Dispose();
        }

        /// <summary>
        /// Passt die Grösse des Bildes der Grösse der Bitmap an
        /// </summary>
        /// <param name="img">Das anzupassende Bild</param>
        /// <returns>Die neue Grösse</returns>
        public Size ConvertImageSize(Image img)
        {
            //Grösse der Bitmap
            double bmpWidth = Bmp.Width;
            double bmpHeigth = Bmp.Height;

            //Grösse des Bildes 
            double imgHeigth = img.Height;
            double imgWidth = img.Width;

            //Grösse des Bildes an Grösse der Bitmap anpassen
            if (imgWidth > bmpWidth)
            {
                double sizeFactor = bmpWidth / imgWidth;
                imgHeigth = sizeFactor * imgHeigth;
                imgWidth = bmpWidth;
            }

            if (imgHeigth > bmpHeigth)
            {
                double sizeFactor = bmpHeigth / imgHeigth;
                imgWidth = sizeFactor * imgWidth;
                imgHeigth = bmpHeigth;
            }

            Size size = new Size(Convert.ToInt32(imgWidth), Convert.ToInt32(imgHeigth));

            return size;
        }
        

        /// <summary>
        /// Verändert Start- und Endpunkte und berechnet Länge und Höhe, damit eine Figur gezeichnet werden kann
        /// </summary>
        /// <param name="startPoint">Ausgangspunkt der zu zeichnenden Form</param>
        /// <param name="endPoint">Endpunkt der zu zeichnenden Form</param>
        /// <param name="hasEqualLengthAndWidth">Hat die Form gleiche Länge und Breite?</param>
        /// <returns></returns>
        public int[] ConvertPointsToLengthAndWidth(Point startPoint, Point endPoint, bool hasEqualLengthAndWidth)
        {
            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            int length = 0;
            int height = 0;

            //Startpunkt berechnen, Endpunkt wird nur für die Längen- und Breitenberechnung gebraucht
            if (startPoint.X < endPoint.X)
            {
                startX = startPoint.X;
                endX = endPoint.X;
            }
            else
            {
                startX = endPoint.X;
                endX = startPoint.X;
            }

            if (startPoint.Y < endPoint.Y)
            {
                startY = startPoint.Y;
                endY = endPoint.Y;
            }
            else
            {
                startY = endPoint.Y;
                endY = startPoint.Y;
            }

            //Für Quadrat und Kreis
            if (startPoint.X < endPoint.X && endPoint.Y < startPoint.Y && hasEqualLengthAndWidth)
            {
                int squareLength = endPoint.X - startPoint.X;
                startY = startPoint.Y - squareLength;
            }

            if (endPoint.X < startPoint.X && endPoint.Y < startPoint.Y && hasEqualLengthAndWidth)
            {
                int squareLength = startPoint.X - endPoint.X;
                startX = startPoint.X - squareLength;
                startY = startPoint.Y - squareLength;
            }

            //Länge und Breite berechnen
            length = endX - startX;
            height = endY - startY;

            int[] iArr = new int[] { length, height, startX, startY};

            return iArr;
        }

        /// <summary>
        /// Zuletzt gezeichnete Form löschen
        /// </summary>
        /// <param name="lForms">Beinhaltet alle gezeichneten Formen</param>
        /// <param name="rForms">Beinhaltet alle gelöschten Formen</param>
        public void Undo(ref List<Shape> lForms, ref List<Shape> rForms)
        {
            rForms.Add(lForms.ElementAt(lForms.Count - 1));
            lForms.RemoveAt(lForms.Count - 1);
        }

        /// <summary>
        /// Zuletzt gelöschte Form wiederherstellen
        /// </summary>
        /// <param name="lForms">Beinhaltet alle gezeichneten Formen</param>
        /// <param name="rForms">Beinhaltet alle gelöschten Formen</param>
        public void Redo(ref List<Shape> lForms, ref List<Shape> rForms)
        {
            lForms.Add(rForms.ElementAt(rForms.Count - 1));
            rForms.RemoveAt(rForms.Count - 1);
        }
    }
}
