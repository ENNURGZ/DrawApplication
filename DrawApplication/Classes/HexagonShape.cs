using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawApplication.Classes
{
    public class HexagonShape : Shape
    {
        public HexagonShape(Point startPoint, Size dimensions, Color shapeColor)
        : base(startPoint, dimensions, shapeColor) { }

        public override void Draw(Graphics g)
        {
            //6 köşe var
            Point[] points ={
                new Point(StartPoint.X + Dimensions.Width / 2, StartPoint.Y),                           //Üst nokta
                new Point(StartPoint.X + Dimensions.Width, StartPoint.Y + Dimensions.Height / 3),       //Sağ üst nokta
                new Point(StartPoint.X + Dimensions.Width, StartPoint.Y + 2 * Dimensions.Height / 3),   //Sağ alt nokta
                new Point(StartPoint.X + Dimensions.Width / 2, StartPoint.Y + Dimensions.Height),       //Alt nokta
                new Point(StartPoint.X, StartPoint.Y + 2 * Dimensions.Height / 3),                      //Sol alt nokta
                new Point(StartPoint.X, StartPoint.Y + Dimensions.Height / 3),                          //Sol üst nokta


            };

            using (SolidBrush brush=new SolidBrush(ShapeColor))
            {
                g.FillPolygon(brush, points);
            }

            if(IsSelected)
            {
                using (Pen pen=new Pen(Color.Black,2))
                {
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
