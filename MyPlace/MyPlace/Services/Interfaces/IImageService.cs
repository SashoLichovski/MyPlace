using MyPlace.Models;
using System.Collections.Generic;

namespace MyPlace.Services.Interfaces
{
    public interface IImageService
    {
        List<ImageViewModel> GetAll();
        List<ImageViewModel> GetUserImages(string userId);
        List<ImageViewModel> GetAllUserImages(string userId);
        void AddImage(AddImageViewModel model, string userId);
        ActionMessage Delete(int imageId);
        ImageViewModel GetById(int imageId);
        ActionMessage Update(AddImageViewModel model);
        List<ImageViewModel> GetSearch(string email);
    }
}
