using EducationPlatform.Application.CommonAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.DTOs
{
    public class AddStudentDTO
    {
        [Required(ErrorMessage ="Password is Required.")]
        [MinLength(6,ErrorMessage = "Password must be 6 character at least.")]
        public string  Password { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage="Email invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is Required.")]
        [MaxLength(30, ErrorMessage = "Length Name should be Maximum 30 character.")]
        [MinLength(3, ErrorMessage = "Length Name should be Minmum 3 character.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required.")]
        [Range(8, 100, ErrorMessage = "Age should be between 8 and 100.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Grade is Required")]
        [Range(0, 100, ErrorMessage = "Grade should be between 0 and 100")]
        public int Grade { get; set; }
        [Required(ErrorMessage = "Please Upload Img Student.")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Only .jpg, .jpeg and .png are allowed")]
        public IFormFile Img { get; set; }
    }

}
