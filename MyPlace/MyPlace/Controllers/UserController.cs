using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPlace.Models;
using MyPlace.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyPlace.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IImageService imageService;

        public UserController(IImageService imageService)
        {
            this.imageService = imageService;
        }
        public IActionResult Overview(string userId)
        {
            List<ImageViewModel> modelList = imageService.GetAllUserImages(userId);
            return View(modelList);
        }

        public IActionResult AddImage()
        {
            var model = new AddImageViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddImage(AddImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                imageService.AddImage(model, userId);
                return RedirectToAction("Overview", new { UserId = userId });
            }
            return View(model);
        }

        public IActionResult Delete(int imageId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var response = imageService.Delete(imageId);
            if (string.IsNullOrEmpty(response.Error))
            {
                return RedirectToAction("Overview", new { UserId = userId });
            }
            else
            {
                return RedirectToAction("ActionMessage", "Home", response.Error);
            }
        }

        public IActionResult Edit(int imageId)
        {
            ImageViewModel imageModel = imageService.GetById(imageId);
            var model = new AddImageViewModel()
            {
                ImageUrl = imageModel.ImageUrl,
                Id = imageModel.Id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(AddImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var response = imageService.Update(model);
                if (string.IsNullOrEmpty(response.Error))
                {
                    return RedirectToAction("Overview", new { UserId = userId });
                }
                return RedirectToAction("ActionMessage", "Home", response.Error);
            }
            return View(model);
        }
    }
}
