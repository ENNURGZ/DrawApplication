using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawApplication.Classes
{
    public class CircleShape : Shape
    {
        public CircleShape(Point startPoint,Size dimensions,Color shapeColor)
        :base(startPoint,dimensions,shapeColor){ }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush=new SolidBrush(ShapeColor))
            {
                g.FillEllipse(brush, new Rectangle(StartPoint, Dimensions));
            }

            if(IsSelected)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawEllipse(pen, new Rectangle(StartPoint, Dimensions));
                }
            }
        }
    }
}
