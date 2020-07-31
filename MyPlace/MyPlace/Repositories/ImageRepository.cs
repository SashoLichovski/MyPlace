using Microsoft.EntityFrameworkCore;
using MyPlace.Data;
using MyPlace.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyPlace.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext context;

        public ImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(EntityImage newImage)
        {
            context.Images.Add(newImage);
            context.SaveChanges();
        }

        public void Delete(EntityImage image)
        {
            context.Images.Remove(image);
            context.SaveChanges();
        }

        public List<EntityImage> GetAll()
        {
            return context.Images
                .Include(x => x.User)
                .Where(x => x.IsPrivate.Equals(false))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        public List<EntityImage> GetAllUserImages(string userId)
        {
            return context.Images
                .Include(x => x.User)
                .Where(x => x.UserId.Equals(userId))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        public EntityImage GetById(int imageId)
        {
            return context.Images.FirstOrDefault(x => x.Id.Equals(imageId));
        }

        public List<EntityImage> GetUserImages(string userId)
        {
            return context.Images
                .Include(x => x.User)
                .Where(x => x.UserId.Equals(userId) && x.IsPrivate.Equals(false))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        public void Update(EntityImage dbImage)
        {
            context.Images.Update(dbImage);
            context.SaveChanges();
        }
    }
}
