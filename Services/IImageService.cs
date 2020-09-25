using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageService
    {
        Task<string> SaveImage(int userId, IFormFile image);
    }
}