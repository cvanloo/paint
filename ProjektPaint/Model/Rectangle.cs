using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ProjektPaint.Model.Enums;
using System.Reflection;

namespace ProjektPaint.Model
{
    class Rectangle : Square
    {
        public int Width { get; set; }

        public Rectangle(int formThickness, Color color, Point startPoint, DashType pattern, int length, int width, Color colorFill, Color colorFrameOut, Color colorFrameIn, int frameThickness)
            : base(formThickness, color, startPoint, pattern, length, colorFill, colorFrameOut, colorFrameIn, frameThickness)
        {
            this.Width = width;
        }

        /// <summary>
        /// Zeichnet das Rechteck in eine Bitmap
        /// </summary>
        /// <param name="grphx">Beinhaltet die Bitmap</param>
        public override void Draw(Graphics grphx)
        {
            //Rechteck zeichnen
            grphx.DrawRectangle(this.getPen(this.Color, this.FormThickness), this.StartPoint.X, this.StartPoint.Y, this.Length, this.Width);

            //Füllung zeichnen
            SolidBrush brush = new SolidBrush(this.ColorFill);
            grphx.FillRectangle(brush, this.StartPoint.X + ((float)this.FormThickness / 2), this.StartPoint.Y + ((float)this.FormThickness / 2), this.Length - this.FormThickness, this.Width - this.FormThickness);

            //Rahmen Aussen zeichnen
            grphx.DrawRectangle(this.getPen(this.ColorFrameOut, this.FrameThickness), this.StartPoint.X - ((float)this.FormThickness / 2) - ((float)this.FrameThickness / 2), this.StartPoint.Y - ((float)this.FormThickness / 2) - ((float)this.FrameThickness / 2), this.Length + FormThickness + FrameThickness, this.Width + FormThickness + FrameThickness);

            //Rahmen Innen zeichnen
            grphx.DrawRectangle(this.getPen(this.ColorFrameIn, this.FrameThickness), this.StartPoint.X + ((float)this.FormThickness / 2) + ((float)this.FrameThickness / 2), this.StartPoint.Y + ((float)this.FormThickness / 2) + ((float)this.FrameThickness / 2), this.Length - FormThickness - FrameThickness, this.Width - FormThickness - FrameThickness);
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
            data += this.Width + ";";
            data += this.ColorFill.ToArgb() + ";";
            data += this.ColorFrameOut.ToArgb() + ";";
            data += this.ColorFrameIn.ToArgb() + ";";
            data += this.FrameThickness + ";"; 

            return data;
        }
    }
}
