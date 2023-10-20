
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AcneTeledermatology.Models
{
    public class FileUploadModel
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}


