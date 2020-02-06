using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using ProjektPaint.Model.Enums;

namespace ProjektPaint.Model
{
    class Freehand : Shape
    {
        public List<Point> Points { get; set; }

        public Freehand(int formThickness, Color color, DashType pattern, List<Point> points)
            : base(formThickness, color, pattern)
        {
            this.Points = points;
        }

        /// <summary>
        /// Zeichnet die Freehand in eine Bitmap
        /// </summary>
        /// <param name="grphx">Beinhaltet die Bitmap</param>
        public override void Draw(Graphics grphx)
        {
            if (this.Points.Count > 1)
            {
                Point[] pArr = new Point[this.Points.Count];
                this.Points.CopyTo(pArr);

                //Form zeichnen
                grphx.DrawLines(this.getPen(this.Color, this.FormThickness), pArr);
            }
            else
            {
                this.Points.Clear();
            }  
        }

        /// <summary>
        /// Gibt die Daten des Shapes als String zurück.
        /// </summary>
        /// <returns> Daten des Shapes mit Semikolons getrennt</returns>
        public override string ConvertDataToString()
        {
            string data = this.GetType().Name + ";";
            data += this.FormThickness + ";";
            data += this.Color.ToArgb() + ";";
            data += this.StartPoint.X + ";";
            data += this.StartPoint.Y + ";";
            data += this.Pattern + ";";

            foreach (Point p in this.Points)
            {
                data += p.X + ";";
                data += p.Y + ";";
            }

            return data;
        }
    }
}
