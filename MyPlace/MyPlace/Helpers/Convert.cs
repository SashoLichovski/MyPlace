using MyPlace.Data;
using MyPlace.Models;

namespace MyPlace.Helpers
{
    public static class Convert
    {
        public static ImageViewModel ToImageViewModel(this EntityImage image)
        {
            return new ImageViewModel
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                DateCreated = image.DateCreated,
                IsPrivate = image.IsPrivate,
                UserId = image.UserId,
                User = image.User
            };
        }
    }
}
