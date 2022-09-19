namespace FileShareApi.Exctentions
{
    public static class StreamExtentions
    {
        public static string GetStreamChecksum(this Stream stream)
        {
            using (var sha256 = System.Security.Cryptography.HashAlgorithm.Create("SHA256"))
            {
                if (sha256 == null)
                    throw new InvalidOperationException("SHA256 is NULL");

                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
