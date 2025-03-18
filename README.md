# DrawApplication

Proje, Nesneye Dayalı Programlama prensiplerini (Soyutlama, Kalıtım, Çok biçimlilik, Kapsülleme) etkin bir şekilde kullandığım Windows Forms ile geliştirdiğim çizim uygulaması. 
Dört farklı şekil (Dikdörtgen, Daire, Üçgen, Altıgen) seçip çizim alanına ekleyebilir, şekilleri taşıyabilir, rengini değiştirebilir, silebilir ve çizim bir dosyaya kaydedip tekrar açılabilir.
OOP'nin tüm temel prensiplerini kullandım. 
- Soyutlama, Shape sınıfı ile tüm şekillerin ortak özelliklerini kapsayarak sağladım.
-  Kalıtım, Shape sınıfından türetilen alt sınıflarla gerçekleştirdim.
-  Çok biçimlilik, her şeklin Draw() metodunu farklı şekilde implemente etmesiyle sağladım.
-  Kapsülleme, DrawingManager ve FileManager sınıflarında verileri dış erişime kapattım.

# Dosya Yapısı

## DrawApplication (Ana proje klasörü)

## Classes (işlemleri içeren sınıflar)

### Shape.cs

Tüm şekillerin ortak özelliklerini tanımlamak için soyut (abstract) sınıfı oluşturdum. Amaç, tüm şekillerin (dikdörtgen, daire, üçgen, altıgen) ortak bir şablona sahip olmasını sağlamak ve kod tekrarını önlemek.

Properties
- StartPoint :Şeklin başlangıç noktasını saklamak 
- Dimensions :Şeklin genişliği ve yüksekliği
- ShapeColor :Her şeklin kendine ait bir rengi olması 
- IsSelected :Şekil seçili mi

Methods
- Soyut Draw(Graphics g); Metodu Bu metodu soyut olarak tanımladım çünkü her şeklin çizim işlemi farklı.Bu yüzden her şekil, bu metodu kendine uygun şekilde override ederek kullanacak.

### RectangleShape.cs

Shape sınıfından miras alıyor.

RectangleShape(Point startPoint, Size dimensions, Color shapeColor).Dikdörtgenin başlangıç noktası, boyutları ve rengini parametre olarak aldım ve Shape sınıfına gönderdim.

Draw(Graphics g) Metodunu Override Ettim.Şekli doldurmak için FillRectangle() metodunu kullandım.Eğer şekil seçiliyse (IsSelected true ise), DrawRectangle() ile bir çerçeve çizdim.

### CircleShape.cs

Draw(Graphics g) Metodunu Override Ettim

Daireyi doldurmak için FillEllipse() metodunu kullandım.

Eğer şekil seçiliyse, DrawEllipse() ile siyah bir çerçeve çizerek seçili olduğunu belirttim.

### TriangleShape.cs

TriangleShape sınıfı, Shape sınıfının (base class) özelliklerini ve metotlarını devralıyor, Sadece üçgen çizmek için Draw metodunu özelleştirir.

Draw(Graphics g) Metodunu Override Ettim.

Üç noktadan oluşan bir Point[] dizisi tanımladım.Noktaları belirledim.

Bu noktaları FillPolygon() metoduyla boyadım.

Eğer şekil seçiliyse, DrawPolygon() ile kenarlara siyah çerçeve çizdim.

### HexagonShape.cs

Draw(Graphics g) Metodunu Override Ettim.

Altı köşe noktasını belirleyerek bir Point[] dizisi oluşturdum.

Bu noktaları FillPolygon() ile doldurdum.

Eğer şekil seçiliyse, DrawPolygon() ile siyah bir çerçeve çizdim.

### DrawingManager.cs

Şekilleri tek tek takip etmek yerine, bunları bir liste içinde yönetmek için oluşturdum.Şekillerin yönetimini sağlıyorum.

Bu sınıf, şekilleri ekleme, çizme, seçme,silme ve renk değiştirme işlemlerinden sorumlu.
- AddShape(Shape shape):Yeni bir şekil eklemek için kullandım. 
- DrawAll(Graphics g):Listedeki tüm şekilleri Draw() metodunu çağırarak çizdim.
- DeselectAllShapes():Şekilleri seçili durumdan çıkardım.
- SelectShape(Point clickPoint):Kullanıcının tıkladığı noktada bir şekil olup olmadığını kontrol ettim.
- ClearShapes():Tüm şekilleri listeden siliyorum. 
- RemoveSelectedShape():Seçili şekli listeden kaldırarak sildim. 
- SetSelectedShapeColor(Color newColor):Kullanıcı seçili şeklin rengini değiştirdiğinde güncellemeyi buradan yaptım.
- SelectedShapeControl():Bir şeklin seçili olup olmadığını kontrol ettim.
- SelectedShapeNow():O an seçili olan şekli.
- GetShapes():Şekillerin listesini döndürüyor.

### FileManager.cs

Çizimlerin kaydedebilmesi ve tekrar açabilmesi için FileManager sınıfını oluşturdum.

- SaveFile(string filePath, List<Shape> shapes) Metodu

Dosyaya yazma işlemi için StreamWriter kullandım.

Her şeklin türünü, koordinatlarını, boyutlarını ve rengini bir satır olarak kaydettim.(Örneğin: RectangleShape,10,10,100,50,-65536 string olarak)

- OpenFile(string filePath) Metodu

Dosyadan okuma işlemi için StreamReader kullandım.

Her satırı parçalayarak uygun şekil nesnesini oluşturup listeye ekledim.

## Form1.cs(ana form)

Çizim yöneticisi (DrawingManager) nesnesini kullanarak şekilleri kontrol ediyorum.

Fare olayları (MouseDown, MouseMove, MouseClick, MouseUp) için ekledim.
### Çizim,Seçim Yönetimi,Taşıma,Güncelleme 
- panelDrawing_MouseDown 
Fareye sol tıkladığında çalışır.Seçim modu kapalıysa, yeni bir şekil çizmek için başlangıç noktası belirlerim. Seçim modu açıksa, tıklanan noktadaki bir şekli seçebilir ve hareket ettirebiliriz.  
- panelDrawing_MouseMove   
Fareyi hareket ettirdiğimde çalışır.Eğer bir şekil sürükleniyorsa,movingShape nesnesinin konumu güncellenir.Şeklin panel sınırları içinde kalmasını sağlamak için kontroller yaptım.
- panelDrawing_MouseUp
Fareyi bıraktığımda çalışır. Çizim tamamlandığında şeklin konumu ve boyutu hesaplanır. Şekil oluşturulduktan sonra DrawingManager.AddShape() metoduyla listeye ekleniyor.
- panelDrawing_MouseClick 
Şekle tıklarsa, önce tüm seçimler kaldırılıyo (DeselectAllShapes). Tıklanan noktada bir şekil olup olmadığı kontrol ediyorum. Eğer varsa, şekil seçiliyor ve şeklin bilgileri ekranda gösteriliyor.
- SetSelectedShapeColor(Color newColor)
Seçili şeklin rengini değiştirir. Renk butonlarından seçilen renk şekle uygulanıyor.
- ShapePositionLabel()  
Seçili şeklin X, Y koordinatlarını ekranda gösteriyorum.(labelda)

### Kullanıcı Arayüzü ve Buton Yönetimi
- ButtonStyle  
Kullanıcının seçtiği butonu belirginleştirmek için özel bir stil uyguladım.
- ResetButtonStyles()  
Tüm butonları varsayılan stile döndürüyor.
- RefreshButtonStyles()
Seçili şekle göre ilgili butonu belirginleştiriyor. Seçili şekil bir dikdörtgense, btnRectangle butonu.

### Dosya İşlemleri (Kaydetme & Açma)
- btnSaveFile_Click
Çizimi kaydetmek istediğimizde çalışır. SaveFileDialog kullanarak bir .txt dosyasına kaydettim.
- btnOpenFile_Click
Önceden kaydedilmiş bir çizimi açmak. OpenFileDialog kullanılarak .txt dosyasından çizim yüklenir.DrawingManager.GetShapes().AddRange() ile yeni şekiller listeye eklenir.




