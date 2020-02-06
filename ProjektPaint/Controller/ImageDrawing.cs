using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
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
        public void DrawImage(List<Shape> fElement)
        {
            //Bild leeren
            Grphx.FillRectangle(Brushes.White, 0, 0, SplitCon.Panel2.Width, SplitCon.Panel2.Height);

            for (int index = 0; index < fElement.Count; index++)
            {
                //Typ des Form-Elementes herausfinden
                Type type = fElement.ElementAt(index).GetType();

                if (type.ToString() == "ProjektPaint.Model.Freehand")
                {
                    //Element in eine Freihandzeichnung casten
                    ProjektPaint.Model.Freehand freehand = (ProjektPaint.Model.Freehand)fElement.ElementAt(index);

                    freehand.Draw(Grphx);
                }
                else if (type.ToString() == "ProjektPaint.Model.Line")
                {
                    //Element in eine Linie casten
                    ProjektPaint.Model.Line line = (ProjektPaint.Model.Line)fElement.ElementAt(index);

                    line.Draw(Grphx);
                }
                else if (type.ToString() == "ProjektPaint.Model.Rectangle")
                {
                    //Element in ein Rechteck casten
                    ProjektPaint.Model.Rectangle rect = (ProjektPaint.Model.Rectangle)fElement.ElementAt(index);

                    rect.Draw(Grphx);
                }
                else if (type.ToString() == "ProjektPaint.Model.Square")
                {
                    //Element in ein Quadrat casten
                    ProjektPaint.Model.Square rect = (ProjektPaint.Model.Square)fElement.ElementAt(index);

                    rect.Draw(Grphx);
                }
                else if (type.ToString() == "ProjektPaint.Model.Ellipse")  //Element ist eine Ellipse
                {
                    //Element in eine Ellipse casten
                    ProjektPaint.Model.Ellipse ellipse = (ProjektPaint.Model.Ellipse)fElement.ElementAt(index);

                    ellipse.Draw(Grphx);
                }
                else if (type.ToString() == "ProjektPaint.Model.Circle")
                {
                    //Element in einen Kreis casten
                    ProjektPaint.Model.Circle circle = (ProjektPaint.Model.Circle)fElement.ElementAt(index);

                    circle.Draw(Grphx);
                }
            }

            //Bitmap neu zeichnen
            Graphics gr = SplitCon.Panel2.CreateGraphics();
            gr.DrawImage(Bmp, 0, 0);
            gr.Dispose();
        }

        

        /// <summary>
        /// Verändert Start- und Endpunkte und berechnet Länge und Höhe, damit eine Figur gezeichnet werden kann
        /// </summary>
        /// <param name="startPoint">Ausgangspunkt der zu zeichnenden Form</param>
        /// <param name="endPoint">Endpunkt der zu zeichnenden Form</param>
        /// <param name="hasEqualLengthAndWidth">Hat die Form gleiche Länge und Breite?</param>
        /// <returns></returns>
        public int[] convertPointsToLengthAndWidth(Point startPoint, Point endPoint, bool hasEqualLengthAndWidth)
        {
            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            int length = 0;
            int height = 0;

            //Startpunkt berechnen, Endpunkt wird nur für die Längen- und Breitenberechnung gebraucht
            //Für Rechteck
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
