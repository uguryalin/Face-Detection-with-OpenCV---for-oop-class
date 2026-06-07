using OpenCvSharp;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Concrete subclass for detecting human eyes.
    /// Inherits from BaseDetector to reuse OpenCV classification logic.
    /// </summary>
    public class EyeDetector : BaseDetector
    {
        public EyeDetector(string cascadePath) : base("Eye", cascadePath)
        {
            // Set specialized default values optimized for eye detection
            ScaleFactor = 1.1;
            MinNeighbors = 6;
            MinSize = new OpenCvSharp.Size(20, 20);
        }
    }
}
