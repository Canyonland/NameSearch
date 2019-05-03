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

        public static async Task SaveFile(Stream someStream, string fileFullPath)
        {
            someStream.Position = 0;
            using (FileStream fs = new FileStream(fileFullPath, FileMode.Create))
            {
                await someStream.CopyToAsync(fs);
            }

        }

    }
}
