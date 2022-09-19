namespace FileShareApi.DataModels
{
    public class UploadedFileInfo
    {
        public string FileName { get; set; }
        public string FileAccessString { get; set; }
        public long FileSize { get; set; }
        public double ExpireTime { get; set; }
        public string DownloadLink { get; set; }

        public UploadedFileInfo(string name, string fileAccessString)
        {
            FileName = name;
            FileAccessString = fileAccessString;
            DownloadLink = $"/api/download/{fileAccessString}";
        }

        public UploadedFileInfo(DataBaseFileInfo dbInfo) : this(dbInfo.FileName, dbInfo.AccessString)
        {
            FileSize = dbInfo.FileSize;
            ExpireTime = dbInfo.ExpireTime;
        }
    }
}
