using MyPlace.Data;
using MyPlace.Helpers;
using MyPlace.Models;
using MyPlace.Repositories.Interfaces;
using MyPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPlace.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepo;

        public ImageService(IImageRepository imageRepo)
        {
            this.imageRepo = imageRepo;
        }

        public void AddImage(AddImageViewModel model, string userId)
        {
            var newImage = new EntityImage()
            {
                ImageUrl = model.ImageUrl,
                UserId = userId,
                DateCreated = DateTime.Now
            };
            if (model.IsPrivate == "false")
            {
                newImage.IsPrivate = true;
            }
            imageRepo.Add(newImage);
        }

        public ActionMessage Update(AddImageViewModel model)
        {

            var dbImage = imageRepo.GetById(model.Id);
            if (dbImage != null)
            {
                dbImage.ImageUrl = model.ImageUrl;
                if (model.IsPrivate != "false")
                {
                    dbImage.IsPrivate = false;
                }
                else
                {
                    dbImage.IsPrivate = true;
                }
                imageRepo.Update(dbImage);
                return new ActionMessage();
            }
            else
            {
                return new ActionMessage()
                {
                    Error = "Image does not exists"
                };
            }
        }

        public ActionMessage Delete(int imageId)
        {
            var image = imageRepo.GetById(imageId);
            if (image != null)
            {
                imageRepo.Delete(image);
                return new ActionMessage();
            }
            else
            {
                return new ActionMessage()
                {
                    Error = "Image does not exists"
                };
            }
        }

        public List<ImageViewModel> GetAll()
        {
            var dbImages = imageRepo.GetAll();

            var modelList = dbImages.Select(x => x.ToImageViewModel()).ToList();

            return modelList;
        }

        public List<ImageViewModel> GetSearch(string email)
        {
            var dbImages = imageRepo.GetAll();

            var modelList = dbImages.Where(x => x.User.Email.Contains(email)).Select(x => x.ToImageViewModel()).ToList();

            return modelList;
        }

        public List<ImageViewModel> GetAllUserImages(string userId)
        {
            var dbImages = imageRepo.GetAllUserImages(userId);

            var modelList = dbImages.Select(x => x.ToImageViewModel()).ToList();

            return modelList;
        }

        public ImageViewModel GetById(int imageId)
        {
            var dbImage = imageRepo.GetById(imageId);

            var model = dbImage.ToImageViewModel();

            return model;
        }

        public List<ImageViewModel> GetUserImages(string userId)
        {
            List<EntityImage> dbImages = imageRepo.GetUserImages(userId);

            var modelList = dbImages.Select(x => x.ToImageViewModel()).ToList();

            return modelList;
        }

        
    }
}
