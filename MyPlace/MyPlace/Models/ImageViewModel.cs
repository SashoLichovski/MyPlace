using Microsoft.AspNetCore.Identity;
using System;

namespace MyPlace.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPrivate { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
