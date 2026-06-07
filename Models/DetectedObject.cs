using OpenCvSharp;

namespace FaceDetectionApp.Models
{
    /// <summary>
    /// Represents a single detected object in a frame, storing its type and bounding rectangle.
    /// Demonstrates Encapsulation by holding the detection result properties together.
    /// </summary>
    public class DetectedObject
    {
        public string TypeName { get; }
        public Rect Bounds { get; }

        public DetectedObject(string typeName, Rect bounds)
        {
            TypeName = typeName;
            Bounds = bounds;
        }
    }
}
