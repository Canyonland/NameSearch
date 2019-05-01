using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NameSearchCore
{
    public static class Utilities
    {

        public static async Task SaveFile(Stream fileStream, string fileFullPath)
        {

            using (FileStream fs = new FileStream(fileFullPath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fs);
            }

        }

    }
}
