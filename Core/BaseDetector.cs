using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Abstract base class for cascade-based object detectors.
    /// Demonstrates Inheritance, Encapsulation of detection parameters,
    /// and Resource Management (IDisposable) for unmanaged OpenCV structures.
    /// </summary>
    public abstract class BaseDetector : IDetector, IDisposable
    {
        protected CascadeClassifier? classifier;
        private readonly string cascadePath;
        private bool isDisposed = false;

        public string Name { get; }
        public bool Enabled { get; set; } = true;

        // Encapsulated parameters for the OpenCV Cascade Detection
        public double ScaleFactor { get; set; } = 1.1;
        public int MinNeighbors { get; set; } = 3;
        public OpenCvSharp.Size MinSize { get; set; } = new OpenCvSharp.Size(30, 30);
        public OpenCvSharp.Size MaxSize { get; set; } = new OpenCvSharp.Size(0, 0);

        protected BaseDetector(string name, string cascadePath)
        {
            Name = name;
            this.cascadePath = cascadePath;
            InitializeClassifier();
        }

        /// <summary>
        /// Loads the CascadeClassifier from the provided file path.
        /// </summary>
        private void InitializeClassifier()
        {
            try
            {
                if (System.IO.File.Exists(cascadePath))
                {
                    classifier = new CascadeClassifier(cascadePath);
                }
                else
                {
                    // Will be handled gracefully or downloaded via CascadeDownloader
                    classifier = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing classifier '{Name}': {ex.Message}");
                classifier = null;
            }
        }

        /// <summary>
        /// Reloads the classifier if the file becomes available.
        /// </summary>
        public void Reload()
        {
            if (classifier == null)
            {
                InitializeClassifier();
            }
        }

        /// <summary>
        /// Runs detection on the provided image frame.
        /// </summary>
        public virtual List<Rect> Detect(Mat frame)
        {
            if (isDisposed)
                throw new ObjectDisposedException(nameof(BaseDetector));

            if (!Enabled || classifier == null || classifier.IsDisposed || frame == null || frame.Empty())
            {
                return new List<Rect>();
            }

            // OpenCV classifier runs faster on grayscale images
            using var grayFrame = new Mat();
            Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);
            Cv2.EqualizeHist(grayFrame, grayFrame);

            // Run detection
            Rect[] detectedObjects = classifier.DetectMultiScale(
                grayFrame,
                ScaleFactor,
                MinNeighbors,
                 HaarDetectionTypes.ScaleImage,
                MinSize,
                MaxSize
            );

            return new List<Rect>(detectedObjects);
        }

        #region Disposable Pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Clean up managed resources if any
                }

                // Clean up unmanaged resources (OpenCV CascadeClassifier)
                if (classifier != null)
                {
                    classifier.Dispose();
                    classifier = null;
                }

                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~BaseDetector()
        {
            Dispose(disposing: false);
        }
        #endregion
    }
}
