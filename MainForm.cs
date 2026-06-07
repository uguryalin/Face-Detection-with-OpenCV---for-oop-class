using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using FaceDetectionApp.Core;
using FaceDetectionApp.Helpers;
using FaceDetectionApp.Models;

namespace FaceDetectionApp
{
    public partial class MainForm : Form
    {
        private CameraManager? cameraManager;
        private DetectionEngine detectionEngine;
        private FaceDetector? faceDetector;
        private EyeDetector? eyeDetector;

        private readonly object snapshotLock = new object();
        private Mat? latestRawFrame;

        // FPS and stats tracking variables
        private int frameCount = 0;
        private double fps = 0.0;
        private DateTime lastFpsUpdate = DateTime.Now;

        public MainForm()
        {
            InitializeComponent();
            
            // Instantiate core OOP components
            detectionEngine = new DetectionEngine();
            cameraManager = new CameraManager();

            // Hook up frame event handler
            cameraManager.FrameReady += OnCameraFrameReady;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Log("Application initialized.");
            
            // Populate camera indices
            comboCameras.Items.Clear();
            comboCameras.Items.Add("Camera 0 (Default / Primary)");
            comboCameras.Items.Add("Camera 1");
            comboCameras.Items.Add("Camera 2");
            comboCameras.SelectedIndex = 0;

            // Lock controls during Haar Cascade downloads
            SetControlsEnabled(false);
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            try
            {
                Log("Loading Haar Cascade models (checking local assets or downloading from OpenCV GitHub)...");
                
                // Asynchronously ensure cascade models are available
                string faceCascadePath = await CascadeDownloader.EnsureCascadeExistsAsync("haarcascade_frontalface_default.xml");
                string eyeCascadePath = await CascadeDownloader.EnsureCascadeExistsAsync("haarcascade_eye.xml");

                Log($"Face classifier loaded: {Path.GetFileName(faceCascadePath)}");
                Log($"Eye classifier loaded: {Path.GetFileName(eyeCascadePath)}");

                // Initialize concrete detectors (Inheritance & Polymorphism)
                faceDetector = new FaceDetector(faceCascadePath);
                eyeDetector = new EyeDetector(eyeCascadePath);

                // Register detectors to engine (Composition & Polymorphic list)
                detectionEngine.RegisterDetector(faceDetector);
                detectionEngine.RegisterDetector(eyeDetector);

                // Sync GUI settings with detector configurations
                chkFace.Checked = faceDetector.Enabled;
                chkEye.Checked = eyeDetector.Enabled;
                numScaleFactor.Value = (decimal)faceDetector.ScaleFactor;
                numMinNeighbors.Value = faceDetector.MinNeighbors;

                Log("System initialized and ready for video streaming.");
                btnStart.Enabled = true;
                SetControlsEnabled(true);
            }
            catch (Exception ex)
            {
                Log($"[ERROR] Initialization failed: {ex.Message}");
                MessageBox.Show($"Failed to download or load Haar Cascade XML models.\nEnsure you have an active internet connection on the first run.\n\nError: {ex.Message}", 
                    "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCameraFrameReady(object? sender, FrameEventArgs e)
        {
            // Lock and store latest raw frame for snapshot usage
            lock (snapshotLock)
            {
                latestRawFrame?.Dispose();
                latestRawFrame = e.Frame.Clone();
            }

            // Clone frame for processing and drawing
            using Mat processedFrame = e.Frame.Clone();

            // Run core OOP Detection Engine
            var (detectedObjects, processTimeMs) = detectionEngine.ProcessFrame(processedFrame);

            // Draw bounding boxes on the frame using OpenCV (fast native drawing)
            foreach (var obj in detectedObjects)
            {
                Scalar boxColor = obj.TypeName == "Face" 
                    ? Scalar.FromRgb(46, 204, 113) // Green
                    : Scalar.FromRgb(52, 152, 219); // Blue

                // Draw rectangle bounds
                Cv2.Rectangle(processedFrame, obj.Bounds, boxColor, 2);

                // Label tag text
                string label = $"{obj.TypeName}";
                int fontFace = (int)HersheyFonts.HersheySimplex;
                double fontScale = 0.5;
                int thickness = 1;
                
                int baseline = 0;
                OpenCvSharp.Size textSize = Cv2.GetTextSize(label, (HersheyFonts)fontFace, fontScale, thickness, out baseline);
                
                // Draw a small filled label background rectangle for text readability
                var labelBgRect = new Rect(obj.Bounds.X, obj.Bounds.Y - textSize.Height - 6, textSize.Width + 6, textSize.Height + 6);
                if (labelBgRect.Y > 0)
                {
                    Cv2.Rectangle(processedFrame, labelBgRect, boxColor, Cv2.FILLED);
                    Cv2.PutText(processedFrame, label, new OpenCvSharp.Point(obj.Bounds.X + 3, obj.Bounds.Y - 4), 
                        (HersheyFonts)fontFace, fontScale, Scalar.White, thickness, LineTypes.AntiAlias);
                }
                else
                {
                    Cv2.PutText(processedFrame, label, new OpenCvSharp.Point(obj.Bounds.X, obj.Bounds.Y + 15), 
                        (HersheyFonts)fontFace, fontScale, boxColor, thickness, LineTypes.AntiAlias);
                }
            }

            // Convert OpenCV Mat to GDI+ Bitmap to render in WinForms PictureBox
            Bitmap frameBitmap;
            try
            {
                frameBitmap = processedFrame.ToBitmap();
            }
            catch (Exception)
            {
                return;
            }

            // Invoke UI thread to render bitmap and update labels
            if (this.IsDisposed || this.Disposing)
            {
                frameBitmap.Dispose();
                return;
            }

            this.BeginInvoke(new Action(() =>
            {
                if (this.IsDisposed || this.Disposing)
                {
                    frameBitmap.Dispose();
                    return;
                }

                // Render in PictureBox and dispose old frame bitmap to avoid massive GDI memory leaks
                var oldImg = pictureBoxView.Image;
                pictureBoxView.Image = frameBitmap;
                oldImg?.Dispose();

                // Update performance statistics
                UpdateMetrics(detectedObjects, processTimeMs);
            }));
        }

        private void UpdateMetrics(List<DetectedObject> objects, long processTimeMs)
        {
            frameCount++;
            var now = DateTime.Now;
            var elapsed = (now - lastFpsUpdate).TotalSeconds;

            if (elapsed >= 1.0)
            {
                fps = frameCount / elapsed;
                frameCount = 0;
                lastFpsUpdate = now;
            }

            int facesCount = 0;
            int eyesCount = 0;

            foreach (var obj in objects)
            {
                if (obj.TypeName == "Face") facesCount++;
                else if (obj.TypeName == "Eye") eyesCount++;
            }

            lblFaceCount.Text = $"Detected Faces: {facesCount}";
            lblEyeCount.Text = $"Detected Eyes: {eyesCount}";
            lblFps.Text = $"FPS: {fps:F1}";
            lblProcessTime.Text = $"Latency: {processTimeMs} ms";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int deviceIndex = comboCameras.SelectedIndex;
            if (deviceIndex < 0) deviceIndex = 0;

            Log($"Starting webcam capture on device index {deviceIndex}...");
            try
            {
                cameraManager?.Start(deviceIndex);
                
                // UI visual transitions
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnSnapshot.Enabled = true;
                comboCameras.Enabled = false;

                Log($"Webcam stream started successfully ({cameraManager?.FrameWidth}x{cameraManager?.FrameHeight}).");
            }
            catch (Exception ex)
            {
                Log($"[ERROR] Failed to start camera: {ex.Message}");
                MessageBox.Show($"Could not connect to selected camera.\n\nError: {ex.Message}", 
                    "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Log("Stopping camera feed...");
            
            cameraManager?.Stop();
            
            // Release GUI image
            var oldImg = pictureBoxView.Image;
            pictureBoxView.Image = null;
            oldImg?.Dispose();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnSnapshot.Enabled = false;
            comboCameras.Enabled = true;

            // Reset labels
            lblFaceCount.Text = "Detected Faces: 0";
            lblEyeCount.Text = "Detected Eyes: 0";
            lblFps.Text = "FPS: 0.0";
            lblProcessTime.Text = "Latency: 0 ms";

            Log("Camera feed stopped.");
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            Mat? frameToSave = null;
            lock (snapshotLock)
            {
                if (latestRawFrame != null && !latestRawFrame.Empty())
                {
                    frameToSave = latestRawFrame.Clone();
                }
            }

            if (frameToSave != null)
            {
                try
                {
                    string snapshotFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Snapshots");
                    if (!Directory.Exists(snapshotFolder))
                    {
                        Directory.CreateDirectory(snapshotFolder);
                    }

                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string fileName = $"Snapshot_{timestamp}.jpg";
                    string fullPath = Path.Combine(snapshotFolder, fileName);

                    // Save using OpenCV file writer
                    frameToSave.SaveImage(fullPath);
                    Log($"Snapshot saved: {fileName} under {Path.GetFileName(snapshotFolder)}/");
                }
                catch (Exception ex)
                {
                    Log($"[ERROR] Failed to save snapshot: {ex.Message}");
                }
                finally
                {
                    frameToSave.Dispose();
                }
            }
            else
            {
                Log("[WARNING] No active camera feed available for capture.");
            }
        }

        private void chkFace_CheckedChanged(object sender, EventArgs e)
        {
            if (faceDetector != null)
            {
                faceDetector.Enabled = chkFace.Checked;
                Log($"Face Detection set to: {faceDetector.Enabled}");
            }
        }

        private void chkEye_CheckedChanged(object sender, EventArgs e)
        {
            if (eyeDetector != null)
            {
                eyeDetector.Enabled = chkEye.Checked;
                Log($"Eye Detection set to: {eyeDetector.Enabled}");
            }
        }

        private void numScaleFactor_ValueChanged(object sender, EventArgs e)
        {
            double scale = (double)numScaleFactor.Value;
            if (faceDetector != null) faceDetector.ScaleFactor = scale;
            if (eyeDetector != null) eyeDetector.ScaleFactor = scale;
            Log($"Cascade Scale Factor adjusted to: {scale}");
        }

        private void numMinNeighbors_ValueChanged(object sender, EventArgs e)
        {
            int neighbors = (int)numMinNeighbors.Value;
            if (faceDetector != null) faceDetector.MinNeighbors = neighbors;
            if (eyeDetector != null) eyeDetector.MinNeighbors = neighbors;
            Log($"Cascade Min Neighbors adjusted to: {neighbors}");
        }

        private void SetControlsEnabled(bool enabled)
        {
            chkFace.Enabled = enabled;
            chkEye.Enabled = enabled;
            numScaleFactor.Enabled = enabled;
            numMinNeighbors.Enabled = enabled;
        }

        private void Log(string message)
        {
            if (this.IsDisposed || this.Disposing) return;

            if (txtLogConsole.InvokeRequired)
            {
                txtLogConsole.BeginInvoke(new Action(() => Log(message)));
                return;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            txtLogConsole.AppendText($"[{timestamp}] {message}{Environment.NewLine}");
            txtLogConsole.SelectionStart = txtLogConsole.Text.Length;
            txtLogConsole.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Log("Cleaning up resources on application exit...");
            
            // Stop camera stream
            cameraManager?.Stop();
            cameraManager?.Dispose();

            // Dispose detection engine (and registered classifiers)
            detectionEngine.Dispose();

            lock (snapshotLock)
            {
                latestRawFrame?.Dispose();
            }

            base.OnFormClosing(e);
        }
    }
}
