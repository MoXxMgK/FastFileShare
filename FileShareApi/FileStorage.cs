using System.IO.Compression;

namespace FileShareApi
{
    public static class FileStorage
    {
        // TODO Creame methoods for file compression
        public static string StorageFolder { get; set; } = "Files";

        public static void Init()
        {
            if (!Directory.Exists(StorageFolder))
            {
                Directory.CreateDirectory(StorageFolder);
            }          
        }

        public static bool FileExists(string fileName) => File.Exists(Path.Combine(StorageFolder, fileName));

        public static string GetFilePath(string fileName) => Path.Combine(StorageFolder, fileName);

        public static async Task<string?> SaveFile(IFormFile file, string fileName)
        {
            string filePath = GetFilePath(fileName);

            try
            {
                using (var fs = File.Create(filePath))
                {
                    await file.CopyToAsync(fs);
                    System.Diagnostics.Debug.WriteLine($"File saved to {filePath}");
                    return filePath;
                }
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is IOException)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex);
#endif
                return null;
            }
        }

        public static async Task<Stream> GetFile(string filePath)
        {
            Stream fs = File.Open(filePath, FileMode.Open);

            return await Task.FromResult(fs);
        }
    }
}
