namespace FileShareApi.DataModels
{
    public class UploadedFileInfo
    {
        public string FileName { get; set; }
        public string FileAccessString { get; set; }
        public long FileSize { get; set; }
        public double ExpireTime { get; set; }

        public UploadedFileInfo(string name, string fileAccessString)
        {
            FileName = name;
            FileAccessString = fileAccessString;
        }

        public UploadedFileInfo(DataBaseFileInfo dbInfo)
        {
            FileName = dbInfo.FileName;
            FileAccessString = dbInfo.AccessString;
            FileSize = dbInfo.FileSize;
            ExpireTime = dbInfo.ExpireTime;
        }
    }
}
