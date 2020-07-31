using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyPlace.Data
{
    public class EntityImage
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public bool IsPrivate { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
