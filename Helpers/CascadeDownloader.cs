using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceDetectionApp.Helpers
{
    /// <summary>
    /// Utility class to ensure Haar Cascade XML models are downloaded from OpenCV's official repository.
    /// Simplifies deployment by checking and downloading files on-demand.
    /// </summary>
    public static class CascadeDownloader
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Verifies if a cascade file exists locally in the 'Cascades' subfolder; if not, downloads it.
        /// Returns the absolute local path to the file.
        /// </summary>
        public static async Task<string> EnsureCascadeExistsAsync(string filename)
        {
            // Set directory to a subfolder named 'Cascades' in the application base directory
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cascades");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, filename);
            if (File.Exists(filePath))
            {
                return filePath;
            }

            // Download URL from official OpenCV GitHub repository
            string url = $"https://raw.githubusercontent.com/opencv/opencv/master/data/haarcascades/{filename}";
            
            try
            {
                // We use HttpClient to fetch the raw XML model
                byte[] data = await client.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(filePath, data);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to download XML classifier '{filename}' from GitHub. Details: {ex.Message}", ex);
            }

            return filePath;
        }
    }
}
