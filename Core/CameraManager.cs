using System;
using System.Threading;
using OpenCvSharp;

namespace FaceDetectionApp.Core
{
    /// <summary>
    /// Manages webcam initialization and frame polling on a background thread.
    /// Demonstrates Encapsulation of webcam state and IDisposable resource management.
    /// </summary>
    public class CameraManager : IDisposable
    {
        private VideoCapture? capture;
        private Thread? captureThread;
        private bool isRunning = false;
        private bool isDisposed = false;
        private readonly object lockObject = new object();

        /// <summary>
        /// Fires when a new camera frame has been retrieved.
        /// </summary>
        public event EventHandler<FrameEventArgs>? FrameReady;

        public bool IsRunning
        {
            get { lock (lockObject) { return isRunning; } }
            private set { lock (lockObject) { isRunning = value; } }
        }

        public int FrameWidth { get; private set; } = 640;
        public int FrameHeight { get; private set; } = 480;

        /// <summary>
        /// Starts capturing frames from the specified webcam device index.
        /// </summary>
        public void Start(int deviceIndex = 0)
        {
            if (IsRunning) return;

            capture = new VideoCapture(deviceIndex);
            if (!capture.IsOpened())
            {
                capture.Dispose();
                capture = null;
                throw new Exception($"Could not open webcam device index {deviceIndex}.");
            }

            // Set custom properties if supported by webcam
            capture.Set(VideoCaptureProperties.FrameWidth, FrameWidth);
            capture.Set(VideoCaptureProperties.FrameHeight, FrameHeight);

            // Read back actual values
            FrameWidth = (int)capture.Get(VideoCaptureProperties.FrameWidth);
            FrameHeight = (int)capture.Get(VideoCaptureProperties.FrameHeight);

            IsRunning = true;
            captureThread = new Thread(CaptureLoop)
            {
                IsBackground = true,
                Name = "CameraCaptureThread"
            };
            captureThread.Start();
        }

        /// <summary>
        /// Stops the webcam stream and clean up threads.
        /// </summary>
        public void Stop()
        {
            if (!IsRunning) return;

            IsRunning = false;

            // Wait for thread to finish
            if (captureThread != null && captureThread.IsAlive)
            {
                captureThread.Join(1000); // Wait up to 1 second
            }

            lock (lockObject)
            {
                if (capture != null)
                {
                    capture.Release();
                    capture.Dispose();
                    capture = null;
                }
            }
        }

        /// <summary>
        /// Background loop for continuously fetching frames.
        /// </summary>
        private void CaptureLoop()
        {
            using var frame = new Mat();

            while (IsRunning)
            {
                try
                {
                    bool success = false;
                    lock (lockObject)
                    {
                        if (capture != null && capture.IsOpened())
                        {
                            success = capture.Read(frame);
                        }
                    }

                    if (success && !frame.Empty())
                    {
                        // Pass the frame clone to avoid threading conflicts with native memory
                        using var frameClone = frame.Clone();
                        FrameReady?.Invoke(this, new FrameEventArgs(frameClone));
                    }
                    else
                    {
                        // If reading fails, sleep a bit to not burn CPU
                        Thread.Sleep(30);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in capture loop: {ex.Message}");
                    Thread.Sleep(100);
                }

                // Throttle to target roughly 30 FPS to avoid high CPU load
                Thread.Sleep(15);
            }
        }

        #region Disposable Pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Clean up managed resources
                }

                Stop();
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~CameraManager()
        {
            Dispose(disposing: false);
        }
        #endregion
    }
}
