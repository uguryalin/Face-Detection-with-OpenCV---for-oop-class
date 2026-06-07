using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenCvSharp;
using FaceDetectionApp.Models;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Coordinates and runs multiple detectors (Face, Eye, etc.) on video frames.
    /// Demonstrates Composition (contains detectors) and Polymorphism (calls Detect on various BaseDetector subclasses).
    /// </summary>
    public class DetectionEngine : IDisposable
    {
        private readonly List<BaseDetector> detectors = new List<BaseDetector>();
        private bool isDisposed = false;

        public IReadOnlyList<BaseDetector> Detectors => detectors;

        /// <summary>
        /// Registers a detector (e.g. FaceDetector, EyeDetector) into the engine.
        /// </summary>
        public void RegisterDetector(BaseDetector detector)
        {
            detectors.Add(detector);
        }

        /// <summary>
        /// Processes a single image frame through all active detectors and measures elapsed time.
        /// </summary>
        public (List<DetectedObject> Objects, long ProcessingTimeMs) ProcessFrame(Mat frame)
        {
            if (isDisposed)
                throw new ObjectDisposedException(nameof(DetectionEngine));

            var results = new List<DetectedObject>();
            var stopwatch = Stopwatch.StartNew();

            // Run registered detectors.
            // This demonstrates Polymorphism: the engine processes each detector identically 
            // via the BaseDetector interface, but each executes its own specific algorithm configuration.
            foreach (var detector in detectors)
            {
                if (detector.Enabled)
                {
                    try
                    {
                        var rects = detector.Detect(frame);
                        foreach (var rect in rects)
                        {
                            results.Add(new DetectedObject(detector.Name, rect));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error running detector '{detector.Name}': {ex.Message}");
                    }
                }
            }

            stopwatch.Stop();
            return (results, stopwatch.ElapsedMilliseconds);
        }

        #region Disposable Pattern
        public void Dispose()
        {
            if (!isDisposed)
            {
                foreach (var detector in detectors)
                {
                    detector.Dispose();
                }
                detectors.Clear();
                isDisposed = true;
            }
        }
        #endregion
    }
}
