namespace FileShareApi
{
    public static class FileStorage
    {
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
                return null;
            }
        }

        public static Stream GetFile(string filePath)
        {
            return File.Open(filePath, FileMode.Open);
        }
    }
}
