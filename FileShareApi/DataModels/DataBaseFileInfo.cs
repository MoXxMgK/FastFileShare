using Microsoft.EntityFrameworkCore.Metadata;

namespace FileShareApi.DataModels
{
    public class DataBaseFileInfo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public string AccessString { get; set; }
        public long FileSize { get; set; }
        public double ExpireTime { get; set; }
        public string FileHash { get; set; }
        public string StorageName { get; set; }
        public bool PublicFile { get; set; }

        public DataBaseFileInfo(string fileName, string accessString, string fileHash, string storageName, bool publicFile = false)
        {
            FileName = fileName;
            FileExtention = new FileInfo(fileName).Extension;
            AccessString = accessString;
            FileHash = fileHash;
            StorageName = storageName;
            PublicFile = publicFile;
        }
    }
}
