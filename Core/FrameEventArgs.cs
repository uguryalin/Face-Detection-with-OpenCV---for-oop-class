using System;
using OpenCvSharp;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Event arguments containing a captured frame from the camera.
    /// Passes the OpenCV Mat instance safely to event handlers.
    /// </summary>
    public class FrameEventArgs : EventArgs
    {
        public Mat Frame { get; }

        public FrameEventArgs(Mat frame)
        {
            Frame = frame;
        }
    }
}
