using MyPlace.Data;
using System.Collections.Generic;

namespace MyPlace.Repositories.Interfaces
{
    public interface IImageRepository
    {
        List<EntityImage> GetAll();
        List<EntityImage> GetUserImages(string userId);
        List<EntityImage> GetAllUserImages(string userId);
        void Add(EntityImage newImage);
        void Delete(EntityImage image);
        EntityImage GetById(int imageId);
        void Update(EntityImage dbImage);
    }
}
