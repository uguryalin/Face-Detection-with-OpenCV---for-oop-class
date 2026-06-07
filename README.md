# AI Real-Time Face & Eye Detector (OpenCV - OOP Class Project)

Select Language: **[English](#english-version)** | **[Türkçe](#türkçe-versiyon)**

---

## English Version

A modern, high-performance Windows Forms application written in C# (.NET 9.0) that performs real-time face and eye tracking using a connected webcam and OpenCV. This project was developed as a demonstration for Object-Oriented Programming (OOP) principles, illustrating how to wrap native unmanaged libraries within robust C# abstractions.

### 🌟 Key Features
- **Live Webcam Streaming**: Polled on a dedicated background thread for high FPS and complete UI responsiveness.
- **Dual Tracking Modes**: Detects both faces (green bounding boxes) and eyes (blue bounding boxes) simultaneously or individually.
- **Dynamic Configuration**: Adjustable Cascade classifier parameters (Scale Factor and Min Neighbors) dynamically via GUI controls.
- **Snapshot Capture**: Save high-definition snapshots of raw video frames with a timestamp directly to the `Snapshots/` folder.
- **Smart Asset Loader**: Automatically downloads necessary Haar Cascade XML models from the official OpenCV repository on the first run.
- **System Status Console**: Real-time timestamps logging and diagnostic feedback directly inside the UI.
- **Performance HUD**: Real-time display of FPS and frame processing latency (ms).

### 🏗️ Object-Oriented Programming (OOP) Architecture
This project is built from the ground up to showcase professional OOP design patterns in C#:

- **Abstraction (`IDetector.cs`)**: The `IDetector` interface defines a clean contract (`Detect(Mat frame)`) that isolates the consumer from the complex OpenCV image processing.
- **Inheritance (`BaseDetector.cs`, `FaceDetector.cs`, `EyeDetector.cs`)**: The `BaseDetector` abstract class implements the core OpenCV cascade logic. `FaceDetector` and `EyeDetector` inherit from `BaseDetector` and supply their own default parameters (like specific `MinSize` and `ScaleFactor` properties).
- **Polymorphism (`DetectionEngine.cs`)**: The `DetectionEngine` registers a list of `BaseDetector` instances. When processing a frame, it iterates through this list and calls `Detect()` on each, executing face or eye detection depending on the runtime instance type.
- **Encapsulation**: Internal OpenCV configuration handles, camera threads, and parameters are encapsulated. Thresholds are exposed through safe properties with default values, and the `CameraManager` hides raw polling loops.
- **Resource Management (`IDisposable` Pattern)**: Because OpenCV runs on unmanaged C++ memory (`Mat`, `VideoCapture`, `CascadeClassifier`), the project implements the `IDisposable` pattern across all core classes. It ensures that native resources are cleaned up immediately when forms close to prevent memory leaks.

### 🚀 How to Run
1. Open a terminal (PowerShell or Command Prompt) in the repository folder.
2. Run the following command:
   ```bash
   dotnet run --project FaceDetectionApp
   ```
3. Alternatively, open `FaceDetectionApp.sln` inside Visual Studio 2022 and click **Run**.

---

## Türkçe Versiyon

OpenCV ve bağlı bir web kamerası kullanarak gerçek zamanlı yüz ve göz takibi gerçekleştiren, C# (.NET 9.0) ve Windows Forms ile yazılmış modern, yüksek performanslı bir masaüstü uygulamasıdır. Bu proje, Nesne Yönelimli Programlama (NYP / OOP) prensiplerini göstermek ve yönetilmeyen (unmanaged) C++ kütüphanelerinin C# soyutlamalarıyla nasıl güvenli bir şekilde sarmalanacağını örneklemek amacıyla geliştirilmiştir.

### 🌟 Önemli Özellikler
- **Gerçek Zamanlı Kamera Akışı**: Yüksek FPS ve tamamen akıcı bir arayüz için özel bir arka plan iş parçacığında (background thread) çalışır.
- **Çiftli Takip Modu**: Yüzleri (yeşil çerçeve) ve gözleri (mavi çerçeve) eş zamanlı veya isteğe bağlı olarak tek tek algılar.
- **Dinamik Parametre Ayarı**: Algılama parametreleri (Ölçek Çarpanı ve Minimum Komşu Sayısı) GUI paneli üzerinden çalışma zamanında dinamik olarak değiştirilebilir.
- **Fotoğraf Kaydı (Snapshot)**: Kameradaki anlık ham kareyi zaman damgasıyla doğrudan `Snapshots/` klasörüne yüksek çözünürlüklü JPEG olarak kaydeder.
- **Otomatik Model Yükleyici**: İlk çalıştırmada gerekli olan Haar Cascade XML modellerini resmi OpenCV deposundan otomatik olarak indirir.
- **Sistem Durum Günlüğü (Console)**: Arayüz içinde zaman damgalı sistem olaylarını ve hata bildirimlerini gösteren canlı konsol.
- **Performans Göstergeleri**: FPS ve milisaniye (ms) cinsinden görüntü işleme gecikmesini anlık olarak takip eden ekran göstergeleri.

### 🏗️ Nesne Yönelimli Programlama (OOP) Mimarisi
Proje, C# dilindeki temel OOP tasarım desenlerini ve temiz kod standartlarını yansıtacak şekilde yapılandırılmıştır:

- **Soyutlama (`IDetector.cs`)**: `IDetector` arayüzü (`Detect(Mat frame)`) fonksiyonunu tanımlayarak kullanıcıyı karmaşık OpenCV görüntü işleme adımlarından yalıtır.
- **Kalıtım (`BaseDetector.cs`, `FaceDetector.cs`, `EyeDetector.cs`)**: `BaseDetector` soyut sınıfı, OpenCV sınıflandırma mantığını ve parametre yönetimini üstlenir. `FaceDetector` ve `EyeDetector` sınıfları ise `BaseDetector` sınıfından miras alarak kendilerine has varsayılan eşik değerlerini belirler.
- **Çok Biçimlilik (`DetectionEngine.cs`)**: `DetectionEngine` (Algılama Motoru), sisteme kayıtlı `BaseDetector` listesini barındırır. Yeni bir kare geldiğinde, listenin elemanları üzerinde dönerek her birinin `Detect()` metodunu çağırır.
- **Kapsülleme**: OpenCV nesneleri, arka plan thread yapıları ve dedektör parametreleri sınıf içinde gizlenmiş olup dış dünyaya yalnızca geçerli aralıkları kontrol eden özellikler (Properties) aracılığıyla sunulur.
- **Kaynak Yönetimi (`IDisposable` Yapısı)**: OpenCV yerel C++ belleği kullandığından (`Mat`, `VideoCapture`, `CascadeClassifier`), bellek sızıntılarını önlemek amacıyla tüm çekirdek sınıflarda `IDisposable` arayüzü uygulanmıştır. Program veya pencere kapatıldığında yerel kaynaklar anında temizlenir.

### 🚀 Çalıştırma Talimatı
1. Proje ana klasöründe bir terminal (PowerShell veya Komut İstemi) açın.
2. Aşağıdaki komutu çalıştırın:
   ```bash
   dotnet run --project FaceDetectionApp
   ```
3. Alternatif olarak, `FaceDetectionApp.sln` çözüm dosyasını Visual Studio 2022 ile açıp doğrudan **Run (Çalıştır)** düğmesine basabilirsiniz.
