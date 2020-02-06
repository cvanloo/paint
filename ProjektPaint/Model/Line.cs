using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using ProjektPaint.Model.Enums;

namespace ProjektPaint.Model
{
    class Line : Shape
    {
        public Point EndPoint { get; set; }

        public Line(int formThickness, Color color, Point startPoint, Point endPoint, DashType pattern)
            : base(formThickness, color, startPoint, pattern)
        {
            this.EndPoint = endPoint;
        }

        /// <summary>
        /// Zeichnet die Linie in eine Bitmap
        /// </summary>
        /// <param name="grphx">Beinhaltet die Bitmap</param>
        public override void Draw(Graphics grphx)
        {
            //Form zeichnen
            grphx.DrawLine(this.getPen(this.Color, this.FormThickness), this.StartPoint, this.EndPoint);
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
            data += this.EndPoint.X + ";";
            data += this.EndPoint.Y + ";";

            return data;
        }
    }
}
