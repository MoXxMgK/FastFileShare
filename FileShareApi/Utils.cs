namespace FileShareApi
{
    public static class Utils
    {
        public static string GetRandomFileName()
        {
            // TODO Make this method more unique
            return Path.GetRandomFileName().Split(".")[0];
        }

        public static double BytesToMb(long bytes)
        {
            return 0;
        }

        public static double ClampExpireTime(double lifeTime)
        {
            double min = TimeSpan.FromHours(1).TotalSeconds;
            double max = TimeSpan.FromHours(24).TotalSeconds;

            return Math.Clamp(lifeTime, min, max);
        }
    }
}
