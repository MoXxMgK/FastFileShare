namespace FileShareApi.DataModels
{
    public class UploadedFileInfo
    {
        public string FileName { get; set; }
        public string AccessString { get; set; }
        public long FileSize { get; set; }
        public double ExpireTime { get; set; }
        public string DownloadLink { get; set; }

        public UploadedFileInfo(string name, string accessString)
        {
            FileName = name;
            AccessString = accessString;
            DownloadLink = $"/api/download/{accessString}";
        }

        public UploadedFileInfo(DataBaseFileInfo dbInfo) : this(dbInfo.FileName, dbInfo.AccessString)
        {
            FileSize = dbInfo.FileSize;
            ExpireTime = dbInfo.ExpireTime;
        }
    }
}
