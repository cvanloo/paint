using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using ProjektPaint.Model.Enums;

namespace ProjektPaint.Model
{
    public abstract class Shape
    {
        public int FormThickness { get; set; }
        public Color Color { get; set; }
        public Point StartPoint { get; set; }
        public DashType Pattern { get; set; }

        public Shape(int formThickness, Color color, DashType pattern)
        {
            this.FormThickness = formThickness;
            this.Color = color;
            this.Pattern = pattern;
        }

        public Shape(int formThickness, Color color, Point startPoint, DashType pattern)
        {
            this.FormThickness = formThickness;
            this.Color = color;
            this.StartPoint = startPoint;
            this.Pattern = pattern;
        }

        /// <summary>
        /// Gibt einen Pen mit Farbe und DashStyle zurück
        /// </summary>
        /// <returns>Pen mit Farbe und DashStyle</returns>
        public Pen getPen(Color color, int thickness)
        {
            Pen pen = new Pen(color, thickness);

            if (this.Pattern == DashType.Solid)
            {
                pen.DashStyle = DashStyle.Solid;
            }
            else if (this.Pattern == DashType.Dashed)
            {
                pen.DashStyle = DashStyle.Dash;
            }
            else if (this.Pattern == DashType.Dotted)
            {
                pen.DashStyle = DashStyle.Dot;
            }

            return pen;
        }

        public abstract void Draw(Graphics grphx);

        public abstract string ConvertDataToString();
    }
}
