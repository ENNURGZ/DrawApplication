using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawApplication.Classes
{
    public class DrawingManager
    {

        private List<Shape> shapes = new List<Shape>();
        private Shape? selectedShape = null;

        public void AddShape(Shape shape) //yeni şekil ekleme
        {
            shapes.Add(shape);
        }
        public void DrawAll(Graphics g)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);                  //her şeklin kendi Draw() metodu 
            }
        }
        public void DeselectAllShapes()         //seçili şeklin seçimini kaldırma
        {
            foreach (var shape in shapes)
            {
                shape.IsSelected = false;
            }
            selectedShape = null;
        }
        public void SelectShape(Point clickPoint)       //seçme
        {
            DeselectAllShapes();

            foreach (var shape in shapes)
            {
                if (new Rectangle(shape.StartPoint, shape.Dimensions).Contains(clickPoint))
                {
                    shape.IsSelected = true;
                    selectedShape = shape;
                }
                else
                {
                    shape.IsSelected= false;
                }
            }
        }
        public void ClearShapes()
        {
            shapes.Clear();
        }
        public void RemoveSelectedShape()  //silme
        {
            if (selectedShape != null)
            {
                shapes.Remove(selectedShape);
                selectedShape = null;
            }
        }
        public void SetSelectedShapeColor(Color newColor)   //seçili şeklin rengini değiştirme
        {
            if (selectedShape!=null)
            {
                selectedShape.ShapeColor = newColor;
            }
        }
        public bool SelectedShapeControl()
        {
            return selectedShape != null;                  //şekil seçiliyse true
        }
        public Shape? SelectedShapeNow()
        {
            return selectedShape;                          //şu anda seçili şekil
        }
        public List<Shape> GetShapes() => shapes;
    } 
}
