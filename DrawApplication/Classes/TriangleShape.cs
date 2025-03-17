using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawApplication.Classes
{
    public class TriangleShape : Shape
    {
        public TriangleShape(Point startPoint, Size dimensions, Color shapeColor)
        : base(startPoint, dimensions, shapeColor) { }

        public override void Draw(Graphics g)
        {
            Point[] points =
            {
                new Point(StartPoint.X+Dimensions.Width/2,StartPoint.Y),                    //tepe
                new Point(StartPoint.X,StartPoint.Y+Dimensions.Height),                     //sol alt
                new Point(StartPoint.X+Dimensions.Width,StartPoint.Y+Dimensions.Height)     //sağ alt
            };

            using (SolidBrush brush = new SolidBrush(ShapeColor))
            {
                g.FillPolygon(brush, points);
            }

            if (IsSelected)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawPolygon(pen, points);
                }
            }
        }

    }
}
