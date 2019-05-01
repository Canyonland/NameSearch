using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NameSearchCore
{
    public class FileSaver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FileSaver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Save(IFormFile file)
        {
            string fileName = $"{Guid.NewGuid().ToString()}.jpg";
            string fileFullPath = $@"{Directory.GetCurrentDirectory()}\wwwroot\Photos\{fileName}";
            using (FileStream fs = new FileStream(fileFullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return $@"{ _httpContextAccessor.HttpContext.Request.Scheme.ToString()}://{_httpContextAccessor.HttpContext.Request.Host.ToString()}/photos/{fileName}";
        }
    }
}
