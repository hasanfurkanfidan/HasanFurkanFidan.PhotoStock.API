using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoStock.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoStock.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult>SavePhoto(IFormFile image,CancellationToken token)
        {
            if (image == null)
            {
                return BadRequest();
            }
            var pathStream = CreateFileHelper.StreamFactory(image, "/images");
            await image.CopyToAsync(pathStream.Stream, token);
            return Ok(image);
        }
        [HttpGet]
        public async Task<IActionResult>DeletePhoto(string imageUrl)
        {
            var url = Path.Combine("wwwroot/",imageUrl);
            if (System.IO.File.Exists(url))
            {
                System.IO.File.Delete(url);
                return NoContent();
            }
            return BadRequest();

        }
    }
}
