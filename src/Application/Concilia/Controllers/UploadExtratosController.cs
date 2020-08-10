using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Concilia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadExtratosController : ControllerBase
    {
        //[HttpPost]
        //[Route("upload")]
        //public IActionResult Upload(List<IFormFile> files)
        //{
        //    foreach (IFormFile file in files)
        //    {
        //        if (file == null || file.Length == 0)
        //        {
        //            return NoContent();
        //        }

        //        if (file.Length > 0)
        //        {
        //            var filePath = @"./OfxFiles";

        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                file.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //[Route("upload")]
        //public IActionResult Upload(IFormFile file)
        //{

        //    if (file == null || file.Length == 0)
        //    {
        //        return NoContent();
        //    }

        //    if (file.Length > 0)
        //    {
        //        var filePath = @"./OfxFiles";

        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            file.CopyToAsync(stream);
        //        }
        //    }


        //    return Ok();
        //}

        [HttpPost]
        [Route("upload")]
        public ActionResult Upload()
        {           
            return Ok();
        }

    }
}
