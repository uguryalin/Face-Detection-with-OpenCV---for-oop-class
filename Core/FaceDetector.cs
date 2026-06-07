using OpenCvSharp;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Concrete subclass for detecting human faces.
    /// Inherits from BaseDetector to reuse OpenCV classification logic.
    /// </summary>
    public class FaceDetector : BaseDetector
    {
        public FaceDetector(string cascadePath) : base("Face", cascadePath)
        {
            // Set specialized default values optimized for faces
            ScaleFactor = 1.15;
            MinNeighbors = 4;
            MinSize = new OpenCvSharp.Size(50, 50);
        }
    }
}
