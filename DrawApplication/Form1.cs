using System;
using System.Collections.Generic;
using System.Drawing;            
using System.Windows.Forms;      
using DrawApplication.Classes;  


namespace DrawApplication
{
    public partial class DrawCase : Form
    {
        private DrawingManager drawingManager = new DrawingManager();       //yönetim
        private Color selectedColor = Color.Black;                          //varsayılan
        private string selectedShapeType = "Rectangle";

        private Shape? movingShape = null;                                //sürüklenen şekli tutar
        private Point FirstMousePosition;                                 //önceki mouse pozisyonu

        private void ButtonStyle(Button clickedButton)                     //seçilen buton için özel stil, gerekli yerlerde çağırılıyor
        {
            clickedButton.FlatStyle = FlatStyle.Flat;
            clickedButton.FlatAppearance.BorderSize = 3;
            clickedButton.FlatAppearance.BorderColor = Color.Black;
        }
        public DrawCase()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",                   //ekran titremesini önledim
            System.Reflection.BindingFlags.SetProperty
            | System.Reflection.BindingFlags.Instance
            | System.Reflection.BindingFlags.NonPublic,
            null, panelDrawing, new object[] { true });
        }

        private void panelDrawing_Paint(object sender, PaintEventArgs e)
        {
            drawingManager.DrawAll(e.Graphics);
        }
        // Çizim İşlemi
        private Point startPoint;
        private bool isDrawing = false;
        private bool isSelectMode = false;

        private void panelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingShape != null && e.Button == MouseButtons.Left)    //şekil seçilmişse hareket
            {
                int dx = e.X - FirstMousePosition.X;                       //değişimi hesapla
                int dy = e.Y - FirstMousePosition.Y;

                int newX = movingShape.StartPoint.X + dx;              //yeni şekil konumu
                int newY = movingShape.StartPoint.Y + dy;

                if (newX < 0) newX = 0;                                     //panel sınırları kontrolü
                if (newY < 0) newY = 0;
                if (newX + movingShape.Dimensions.Width > panelDrawing.Width - OperationsGroup.Width)
                    newX = panelDrawing.Width - movingShape.Dimensions.Width - OperationsGroup.Width;
                if (newY + movingShape.Dimensions.Height > panelDrawing.Height)
                    newY = panelDrawing.Height - movingShape.Dimensions.Height;

                movingShape.StartPoint = new Point(newX, newY);         //yeni konumu güncelle
                ShapePositionLabel();
                FirstMousePosition = e.Location;                        //güncelledi
                panelDrawing.Invalidate();

            }
        }
        private void panelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isSelectMode)                                        //seçme modu aktifse 
                {
                    drawingManager.SelectShape(e.Location);
                    movingShape = drawingManager.SelectedShapeNow();
                    if (movingShape != null)
                    {
                        FirstMousePosition = e.Location;
                    }
                }
                else
                {
                    drawingManager.DeselectAllShapes();
                    ResetButtonStyles();
                    startPoint = e.Location;
                    isDrawing = true;
                }
            }
        }
        private void panelDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            if (isSelectMode)                                                //sadece seçme modu aktifse
            {
                drawingManager.DeselectAllShapes();                         // Önce tüm şekillerin seçili durumunu kaldır
                drawingManager.SelectShape(e.Location);                     // Eğer tıklanan yerde bir şekil varsa onu seç
                RefreshButtonStyles();                         // Butonları belirginleştir

                if (drawingManager.SelectedShapeControl())                  // Seçili bir şekil varsa konum bilgisini göster, yoksa temizle
                {
                    ShapePositionLabel();
                }
                else
                {
                    ShapePosition.Text = "";
                }
            }
            panelDrawing.Invalidate();
        }
        private void panelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (movingShape != null)
            {
                movingShape = null;
            }
            else if (isDrawing)
            {
                int centerX = startPoint.X;
                int centerY = startPoint.Y;

                int width = Math.Abs(e.X - centerX) * 2;
                int height = Math.Abs(e.Y - centerY) * 2;

                int startX = centerX - width / 2;                           //başlangıç noktası merkez
                int startY = centerY - height / 2;

                //panel sınırlarını kontrol etme
                if (startX < 0) startX = 0;
                if (startY < 0) startY = 0;
                if (startX + width > panelDrawing.Width - OperationsGroup.Width)
                    width = panelDrawing.Width - OperationsGroup.Width - startX;
                if (startY + height > panelDrawing.Height)height = panelDrawing.Height - startY;

                Shape? newShape = null;
                switch (selectedShapeType)
                {
                    case "Rectangle":
                        newShape = new RectangleShape(new Point(startX, startY), new Size(width, height), selectedColor);
                        break;
                    case "Circle":
                        newShape = new CircleShape(new Point(startX, startY), new Size(width, height), selectedColor);
                        break;
                    case "Triangle":
                        newShape = new TriangleShape(new Point(startX, startY), new Size(width, height), selectedColor);
                        break;
                    case "Hexagon":
                        newShape = new HexagonShape(new Point(startX, startY), new Size(width, height), selectedColor);
                        break;
                }

                if (newShape != null)
                {
                    drawingManager.AddShape(newShape);
                }

                isDrawing = false;

                // Çizim tamamlandıktan sonra butonları sıfırla
                ResetButtonStyles();
            }

            panelDrawing.Invalidate();
        }
        private void ResetButtonStyles()
        {

            // Geçerli seçili şekil ve rengi sakla
            string lastShapeType = selectedShapeType;
            Color lastColor = selectedColor;

            // Şekil butonlarını sıfırla
            List<Button> shapeButtons = new List<Button>
            { btnRectangle, btnCircle, btnTriangle, btnHexagon };

            foreach (var btn in shapeButtons)
            {
                btn.FlatStyle = FlatStyle.Standard;
                btn.FlatAppearance.BorderSize = 1;
            }

            // Renk butonlarını sıfırla
            List<Button> colorButtons = new List<Button>
            { btnRed, btnBlue,btnGreen,btnOrange,btnBlack,btnYellow, btnPurple,btnBrown,btnWhite };

            foreach (var btn in colorButtons)
            {
                btn.FlatStyle = FlatStyle.Standard;
                btn.FlatAppearance.BorderSize = 1;
            }
        }
        private void RefreshButtonStyles()
        {
            ResetButtonStyles();

            if (drawingManager.SelectedShapeControl()) // Eğer bir şekil seçiliyse
            {
                Shape? selectedShape = drawingManager.SelectedShapeNow();

                if (selectedShape is null)
                    return;                             //şekil null ise fonksiyondan çık

                // Şeklin türüne göre butonu belirginleştir
                switch (selectedShape.GetType().Name)
                {
                    case "RectangleShape":
                        ButtonStyle(btnRectangle);
                        break;
                    case "CircleShape":
                        ButtonStyle(btnCircle);
                        break;
                    case "TriangleShape":
                        ButtonStyle(btnTriangle);
                        break;
                    case "HexagonShape":
                        ButtonStyle(btnHexagon);
                        break;
                }

                // Renk butonlarının da kenarlığını belirginleştir
                if (selectedShape.ShapeColor == Color.Red)
                {
                    ButtonStyle(btnRed);
                }
                else if (selectedShape.ShapeColor == Color.Blue)
                {
                    ButtonStyle(btnBlue);
                }
                else if (selectedShape.ShapeColor == Color.Green)
                {
                    ButtonStyle(btnGreen);
                }
                else if (selectedShape.ShapeColor == Color.Orange)
                {
                    ButtonStyle(btnOrange);
                }
                else if (selectedShape.ShapeColor == Color.Black)
                {
                    ButtonStyle(btnBlack);
                }
                else if (selectedShape.ShapeColor == Color.Yellow)
                {
                    ButtonStyle(btnYellow);
                }
                else if (selectedShape.ShapeColor == Color.Purple)
                {
                    ButtonStyle(btnPurple);
                }
                else if (selectedShape.ShapeColor == Color.Brown)
                {
                    ButtonStyle(btnBrown);
                }
                else if (selectedShape.ShapeColor == Color.White)
                {
                    ButtonStyle(btnWhite);
                }
            }
        }
        private void ShapePositionLabel()                                 //labelda konum
        {
            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                ShapePosition.Text = $"Konum(X,Y):{selectedShape.StartPoint.X},{selectedShape.StartPoint.Y}";
            }
            else
            {
                ShapePosition.Text = ""; // Seçim bırakılınca temizle
            }
        }
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            selectedShapeType = "Rectangle";
            ButtonStyle(btnRectangle);
            panelDrawing.Invalidate();
        }
        private void btnTriangle_Click(object sender, EventArgs e)
        {
            selectedShapeType = "Triangle";
            ButtonStyle(btnTriangle);
            panelDrawing.Invalidate();
        }
        private void btnCircle_Click(object sender, EventArgs e)
        {
            selectedShapeType = "Circle";
            ButtonStyle(btnCircle);
            panelDrawing.Invalidate();
        }
        private void btnHexagon_Click(object sender, EventArgs e)
        {
            selectedShapeType = "Hexagon";
            ButtonStyle(btnHexagon);
            panelDrawing.Invalidate();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Red;
            
            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);  //renk değiştirme
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnRed);
        }
        private void btnBlue_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Blue;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnBlue);
        }
        private void btnGreen_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Green;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnGreen);
        }
        private void btnOrange_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Orange;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnOrange);
        }
        private void btnBlack_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Black;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnBlack);
        }
        private void btnYellow_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Yellow;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnYellow);
        }
        private void btnPurple_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Purple;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnPurple);
        }
        private void btnBrown_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Brown;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnBrown);
        }
        private void btnWhite_Click(object sender, EventArgs e)
        {
            selectedColor = Color.White;

            Shape? selectedShape = drawingManager.SelectedShapeNow();
            if (selectedShape != null)
            {
                drawingManager.SetSelectedShapeColor(selectedColor);
                panelDrawing.Invalidate();
            }

            ButtonStyle(btnWhite);
        }

        //aç kapa özelliği ekledim
        private void btnSelect_Click(object sender, EventArgs e)
        {
            isSelectMode = !isSelectMode;  
            panelDrawing.Cursor = isSelectMode ? Cursors.Hand : Cursors.Default;

            List<Button> buttons = new List<Button>
            {
                btnRectangle, btnCircle, btnTriangle, btnHexagon 
            };

            if (isSelectMode)
            {
                ButtonStyle(btnSelect);
                RefreshButtonStyles();                         // seçili şekil varsa butonları belirginleştir
                buttons.ForEach(b => b.Enabled = false);
            }
            else
            {
                btnSelect.FlatStyle = FlatStyle.Standard;
                btnSelect.FlatAppearance.BorderSize = 1;
                drawingManager.DeselectAllShapes();           // seçme işlemi kapatılınca seçili şekli kaldır
                ResetButtonStyles();                          // seçme modundan çıkıldığında butonları eski haline döndür
                buttons.ForEach(b => b.Enabled = true);
                ShapePosition.Text = "";                     // seçme kapatılınca Label'ı temizle
                panelDrawing.Invalidate(); 
            }

            this.ActiveControl = null;                       //özellikleri kaldırır
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            drawingManager.RemoveSelectedShape();
            ResetButtonStyles();
            ShapePosition.Text = "";
            panelDrawing.Invalidate();
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            drawingManager.ClearShapes(); 
            ResetButtonStyles(); 
            isSelectMode = false; 
            btnSelect.FlatStyle = FlatStyle.Standard; 
            btnSelect.FlatAppearance.BorderSize = 1;
            panelDrawing.Cursor = Cursors.Default;                        //imleç
            ShapePosition.Text = "";
            panelDrawing.Invalidate(); 
        }
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Çizim Dosyaları (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileManager.SaveFile(saveFileDialog.FileName, drawingManager.GetShapes());
            }
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Çizim Dosyaları (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingManager.GetShapes().Clear();
                drawingManager.GetShapes().AddRange(FileManager.OpenFile(openFileDialog.FileName));
                panelDrawing.Invalidate();
            }
        }
    }
}
