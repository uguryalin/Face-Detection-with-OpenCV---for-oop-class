using OpenCvSharp;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Contract for object detectors. Demonstrates Abstraction by hiding
    /// the specific detection algorithms behind a clean interface.
    /// </summary>
    public interface IDetector
    {
        string Name { get; }
        bool Enabled { get; set; }
        List<Rect> Detect(Mat frame);
    }
}
