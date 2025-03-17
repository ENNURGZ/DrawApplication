using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;                        //temel grafik işlevlerine erişim

namespace DrawApplication.Classes
{
    public abstract class Shape
    {
        public Point StartPoint { get; set; }  //başlangıç noktası
        public Size Dimensions { get; set; }  //boyutlar
        public Color ShapeColor { get; set; }  //şeklin rengi
        public bool IsSelected { get; set; }   //seçili olup olmadığı

        public Shape(Point startPoint,Size dimensions,Color shapeColor)  //yapıcı metod
        {
            StartPoint = startPoint;
            Dimensions = dimensions;
            ShapeColor = shapeColor;
        }

        public abstract void Draw(Graphics g);

    }
}
