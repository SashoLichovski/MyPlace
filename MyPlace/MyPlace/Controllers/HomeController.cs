using Microsoft.AspNetCore.Mvc;
using MyPlace.Models;
using MyPlace.Services.Interfaces;
using System.Collections.Generic;

namespace MyPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageService imageService;

        public HomeController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public IActionResult Index(string email)
        {
            var modelList = new List<ImageViewModel>();
            if (email != null)
            {
                modelList = imageService.GetSearch(email);
            }
            else
            {
                modelList = imageService.GetAll();
            }
            return View(modelList);
        }

        public IActionResult UserImages(string userId)
        {
            List<ImageViewModel> modelList = imageService.GetUserImages(userId);
            return View(modelList);
        }

        public IActionResult ActionMessage(ActionMessage errorMessage)
        {
            return View(errorMessage);
        }
    }
}
