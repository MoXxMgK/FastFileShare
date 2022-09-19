namespace FileShareApi.DataModels
{
    public class ApiResult
    {
        public bool Ok { get; set; }
        public object? Data { get; set; }

        public ApiResult(bool ok, object? data)
        {
            Ok = ok;
            Data = data;
        }
    }
}
