using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AcneTeledermatology.Models
{
    public class UserLoginViewModel
    {
        public class LoginViewModel
        {
            
            #region Properties  

            /// <summary>  
            /// Gets or sets to username address.  
            /// </summary>  
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            /// <summary>  
            /// Gets or sets to password address.  
            /// </summary>  
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            public User user { get; set; }
            public UserProfile UserProfile { get; set; }

            #endregion
        }
    }
}
