using System;
using System.Collections.Generic;
using System.Text;

namespace FFSApi
{
    public class APIFile
    {
        public string FileName { get; set; }
        public string AccessString { get; set; }
        public string DownloadLink { get; set; }
        public long FileSize { get; set; }
        public double ExpireTime { get; set; }

        // General constructor
        public APIFile(string fileName, string accessString, string downloadLink, long fileSize, double expireTime)
        {
            FileName = fileName;
            AccessString = accessString;
            DownloadLink = downloadLink;
            FileSize = fileSize;
            ExpireTime = expireTime;
        }

        // Constructor to make object from web response
        internal APIFile()
        {

        }
    }
}
