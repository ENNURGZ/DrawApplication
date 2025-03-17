using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawApplication.Classes
{
    public class RectangleShape : Shape
    {
        public RectangleShape(Point startPoint, Size dimensions, Color shapeColor)
        : base(startPoint, dimensions, shapeColor) { }   //yapıcı metod

        public override void Draw(Graphics g)   
        {
            using (SolidBrush brush=new SolidBrush(ShapeColor))  
            {
                g.FillRectangle(brush, new Rectangle(StartPoint, Dimensions));
            }

            if(IsSelected)                                                  //seçiliyse
            {
                using (Pen pen= new Pen(Color.Black,2))
                {
                    g.DrawRectangle(pen, new Rectangle(StartPoint,Dimensions));
                }
            }
        }

    }
}
