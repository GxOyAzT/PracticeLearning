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

        [HttpGet]
        public async Task<IActionResult> Download(string id)
        {
            var path = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "wwwroot\\userImages", "e33aa0ea-5df0-4590-9f5e-d3c1cda353ac.jpg");

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpeg", Path.GetFileName(path));
        }
    }

    public class ImageDTO
    {
        public IFormFile File { get; set; }
    }
}
