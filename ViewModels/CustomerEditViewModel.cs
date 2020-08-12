using CustomerManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.ViewModels
{
    public class CustomerEditViewModel 
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Characters cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(pattern: @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Personal Email")]
        public string Email { get; set; }
        public IFormFile Photo { get; set; }

    }
}
