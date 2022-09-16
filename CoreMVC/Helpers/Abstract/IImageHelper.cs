using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Shared.Utilities.Results.Abstract;

namespace CoreMVC.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages");
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
