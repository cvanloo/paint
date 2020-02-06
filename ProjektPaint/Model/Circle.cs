using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using ProjektPaint.Model.Enums;

namespace ProjektPaint.Model
{
    class Circle : Shape2d
    {
        public int Length { get; set; }

        public Circle(int formThickness, Color color, Point startPoint, DashType pattern, int length, Color colorFill, Color colorFrameOut, Color colorFrameIn, int frameThickness)
            : base(formThickness, color, startPoint, pattern, colorFill, colorFrameOut, colorFrameIn, frameThickness)
        {
            this.Length = length;
        }

        /// <summary>
        /// Zeichnet den Kreis in eine Bitmap
        /// </summary>
        /// <param name="grphx">Beinhaltet die Bitmap</param>
        public override void Draw(Graphics grphx)
        {
            //Füllung
            SolidBrush brush = new SolidBrush(this.ColorFill);
            grphx.FillEllipse(brush, this.StartPoint.X + ((float)this.FormThickness / 2), this.StartPoint.Y + ((float)this.FormThickness / 2), this.Length - this.FormThickness, this.Length - this.FormThickness);

            //Kreis zeichnen
            grphx.DrawEllipse(this.getPen(this.Color, this.FormThickness), new System.Drawing.Rectangle(this.StartPoint.X, this.StartPoint.Y, this.Length, this.Length));

            //Rahmen Aussen zeichnen
            grphx.DrawEllipse(this.getPen(this.ColorFrameOut, this.FrameThickness), this.StartPoint.X - ((float)this.FormThickness / 2) - ((float)this.FrameThickness / 2), this.StartPoint.Y - ((float)this.FormThickness / 2) - ((float)this.FrameThickness / 2), this.Length + FormThickness + FrameThickness, this.Length + FormThickness + FrameThickness);

            //Rahmen Innen zeichnen
            grphx.DrawEllipse(this.getPen(this.ColorFrameIn, this.FrameThickness), this.StartPoint.X + ((float)this.FormThickness / 2) + ((float)this.FrameThickness / 2), this.StartPoint.Y + ((float)this.FormThickness / 2) + ((float)this.FrameThickness / 2), this.Length - FormThickness - FrameThickness, this.Length - FormThickness - FrameThickness);
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
            data += this.Length + ";";
            data += this.ColorFill.ToArgb() + ";";
            data += this.ColorFrameOut.ToArgb() + ";";
            data += this.ColorFrameIn.ToArgb() + ";";
            data += this.FrameThickness + ";";

            return data;
        }
    }
}
