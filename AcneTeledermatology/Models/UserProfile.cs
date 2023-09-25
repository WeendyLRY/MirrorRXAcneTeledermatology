using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace AcneTeledermatology.Models
{
    public class UserProfile
    {
        [Key]
        public int IDUserProfile { get; set; } // Primary Key

        [ForeignKey("User")]
        public int IDUser { get; set; } // Foreign Key

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string? ProfileImagePath { get; set; }

        
        ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfiles;

        ICollection<User> User;
    }
}
