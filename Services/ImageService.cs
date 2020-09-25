using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImage(int userId, IFormFile uploadedImage)
        {
            // convert IFormFile to Image and validate
            using (var image = Image.FromStream(uploadedImage.OpenReadStream()))
            {
                if (image.Width > 640 || image.Height > 480)
                {
                    // do some resizing and then save image
                }
                else
                {
                    // save original image for user
                }
            }

            return "image saved";
        }
    }
}