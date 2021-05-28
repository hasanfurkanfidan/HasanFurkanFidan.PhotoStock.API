using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStock.WebApi.Helpers
{
    public class CreateFileHelper
    {
        public static PathStream StreamFactory(IFormFile file, string location)
        {

            var imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Directory.GetCurrentDirectory() + "/wwwroot/" + location + imageName;
            var stream = new FileStream(path, FileMode.Create);
            return new PathStream
            {
                Path = "/" + location + imageName,
                Stream = stream
            };
        }
        public class PathStream
        {
            public FileStream Stream { get; set; }
            public string Path { get; set; }
        }
    }
}
