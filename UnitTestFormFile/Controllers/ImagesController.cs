using Microsoft.AspNetCore.Mvc;
using Services;
using System.Linq;
using System.Threading.Tasks;
using UnitTestFormFile.Models;

namespace UnitTestFormFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // POST api/images
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] ImageDetailsDto imageDetails)
        {
            var requestImage = Request.Form.Files.FirstOrDefault();

            var result = await _imageService.SaveImage(imageDetails.UserId, requestImage);

            // save user details in some other service

            return Ok(result);
        }
    }
}
