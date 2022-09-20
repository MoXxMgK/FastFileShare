using System;
using System.Collections.Generic;
using System.Text;

namespace FFSApi
{
    public class APIResult
    {
        public bool Ok { get; set; }
        public object? Data { get; set; }

        public APIResult(bool ok, object? data)
        {
            Ok = ok;
            Data = data;
        }
    }
}
