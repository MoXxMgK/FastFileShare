using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FileShareApi.Data;
using FileShareApi.DataModels;
using FileShareApi.Exctentions;

namespace FileShareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private FileDataBaseContext _ctx;
        public FilesController(FileDataBaseContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("{accessString}")]
        public async Task<ApiResult> GetFile(string accessString)
        {
            var data = await _ctx.GetFile(accessString);
            if (data != null)
            {
                return new ApiResult(true, new UploadedFileInfo(data));
            }
            else
            {
                return new ApiResult(false, null);
            }
        }

        [HttpPost()]
        public async Task<UploadedFileInfo?> PostFileUpload(IFormFile file)
        {
            // TODO Check file size befor loading
            // TODO If file match all requirement, add file data to DB and return FileInfo Object
            // TODO Add generator for FileAccessString

            string fileChecksum = file.OpenReadStream().GetStreamChecksum();

            var f = await _ctx.CheckFile(fileChecksum);

            // File already in database, return info
            if (f != null)
            {
                return new UploadedFileInfo(f);
            }

            // Make query to db to ensure this is new file
            string fileName = new FileInfo(file.FileName).Name;
            string storageName = Utils.GetRandomFileName(); // Now this is also access string
            double expireTime = TimeSpan.FromHours(1).TotalSeconds;  // Defautl exspireTime is 1 hour, get this from query

            string? storagePath = await FileStorage.SaveFile(file, storageName);

            if (storagePath == null)
            {
                return null;
            }

            DataBaseFileInfo dbData = new DataBaseFileInfo(fileName, storageName, fileChecksum, storagePath)
            {
                FileSize = file.Length,
                ExpireTime = expireTime
            };

            _ctx.Add(dbData);
            await _ctx.SaveChangesAsync();

            return new UploadedFileInfo(dbData);
        }
    }
}
