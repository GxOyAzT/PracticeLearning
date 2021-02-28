using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebAppPractice.Controllers
{
    public class ImagesController : Controller
    {
        public ImagesController()
        {

        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View(new ImageDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ImageDTO model)
        {
            if (model.File.Length > 0)
            {
                using (var stream = System.IO.File.Create($@"C:\Data\Projects\PracticeLearning\WebAppPractice\wwwroot\userImages\{Guid.NewGuid()}.jpg"))
                {
                    await model.File.CopyToAsync(stream);
                }
            }

            return View();
        }
    }

    public class ImageDTO
    {
        public IFormFile File { get; set; }
    }
}
