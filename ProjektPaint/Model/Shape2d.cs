using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ProjektPaint.Model.Enums;

namespace ProjektPaint.Model
{
    public abstract class Shape2d : Shape
    {
        public Color ColorFill { get; set; }
        public Color ColorFrameOut { get; set; }
        public Color ColorFrameIn { get; set; }
        public int FrameThickness { get; set; }

        public Shape2d(int formThickness, Color color, Point startPoint, DashType pattern, Color colorFill, Color colorFrameOut, Color colorFrameIn, int frameThickness)
            : base(formThickness, color, startPoint, pattern)
        {
            this.ColorFill = colorFill;
            this.ColorFrameOut = colorFrameOut;
            this.ColorFrameIn = colorFrameIn;
            this.FrameThickness = frameThickness;
        }
    }
}
