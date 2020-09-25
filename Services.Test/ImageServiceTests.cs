using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Services.Test
{
    public class ImageServiceTests
    {
        private readonly IImageService _imageService;
        private readonly int _userId = 1234;
        public ImageServiceTests()
        {
            _imageService = new ImageService();
        }

        [Fact]
        public async Task Service_Saves_Image()
        {
            // Arrange
            var expected = "image saved";

            var imageStream = new MemoryStream(GenerateImageByteArray());
            var image = new FormFile(imageStream, 0, imageStream.Length, "UnitTest", "UnitTest.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            // Act
            var result = await _imageService.SaveImage(_userId, image);

            // Assert
            Assert.Equal(expected, result);
        }

        private byte[] GenerateImageByteArray(int width = 50, int height = 50)
        {
            Bitmap bitmapImage = new Bitmap(width, height);
            Graphics imageData = Graphics.FromImage(bitmapImage);
            imageData.DrawLine(new Pen(Color.Blue), 0, 0, width, height);

            MemoryStream memoryStream = new MemoryStream();
            byte[] byteArray;

            using (memoryStream)
            {
                bitmapImage.Save(memoryStream, ImageFormat.Jpeg);
                byteArray = memoryStream.ToArray();
            }
            return byteArray;
        }
    }
}