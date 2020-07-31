using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Data
{
    public class Image
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
