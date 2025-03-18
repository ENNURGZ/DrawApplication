using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawApplication.Classes
{
    public class FileManager
    {
        public static void SaveFile(string filePath, List<Shape> shapes)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var shape in shapes)
                {
                    sw.WriteLine($"{shape.GetType().Name},{shape.StartPoint.X},{shape.StartPoint.Y}," +
                                 $"{shape.Dimensions.Width},{shape.Dimensions.Height},{shape.ShapeColor.ToArgb()}");
                }
            }
        }

        public static List<Shape> OpenFile(string filePath)
        {
            List<Shape> shapes = new List<Shape>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string? line;                                       //satır
                while ((line = sr.ReadLine()) != null)              //satır satır okuma
                {
                    string[] parts = line.Split(',');
                    string shapeType = parts[0];
                    Point startPoint = new Point(int.Parse(parts[1]), int.Parse(parts[2]));
                    Size dimensions = new Size(int.Parse(parts[3]), int.Parse(parts[4]));
                    Color shapeColor = Color.FromArgb(int.Parse(parts[5]));

                    Shape? shape = shapeType switch
                    {
                        "RectangleShape" => new RectangleShape(startPoint, dimensions, shapeColor),
                        "CircleShape" => new CircleShape(startPoint, dimensions, shapeColor),
                        "TriangleShape" => new TriangleShape(startPoint, dimensions, shapeColor),
                        "HexagonShape" => new HexagonShape(startPoint, dimensions, shapeColor),
                        _ => null
                    };

                    if (shape != null) shapes.Add(shape);                       //listeye ekle
                }
            }
            return shapes;
        }
    }
}
