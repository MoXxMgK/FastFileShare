using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FileShareApi.Data;
using FileShareApi.DataModels;

namespace FileShareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private FileDataBaseContext _ctx;

        public DownloadController(FileDataBaseContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("{accessString}")]
        public async Task<IActionResult> DownloadFile(string accessString)
        {
            var file = await _ctx.GetFile(accessString);

            if (file == null)
            {
                return NotFound("File not found or may be deleted.");
            }

            try
            {
                var fileContent = FileStorage.GetFile(file.StorageName);
                var fileContentType = "APPLICATION/file"; // TODO Get this from db or other ways

                return File(fileContent, fileContentType, file.FileName);
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is IOException)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return BadRequest("Could not get file from server storage.");
            }
        }
    }
}
