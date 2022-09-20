using System;
using System.IO;
using System.Net;

namespace FFSApi
{
    public class FFShareApi
    {
        public string Domain { get; set; } = "https://localhost:7223";

        // Replace this code after deploy
        public FFShareApi(string? newDomain = null)
        {
            if (newDomain != null)
            {
                Domain = newDomain;
            }
        }

        private void MakeRequest()
        {
            // Add code
        }

        public APIResult GetFile(string accessString)
        {
            // Add code
            return new APIResult(true, null);
        }

        public void UploadFile(Stream fileStream)
        {
            // Add code and make overloads
        }

        public void DownloadFile(string accessString)
        {
            // Add code
        }
    }
}
