namespace FileShareApi
{
    public static class Utils
    {
        public static string GetStorageFilePath(string storageName)
        {
            return "";
        }

        public static string GetRandomFileName()
        {
            // TODO Make this method more unique
            return Path.GetRandomFileName().Split(".")[0];
        }

        public static double BytesToMb(long bytes)
        {
            return 0;
        }
    }
}
