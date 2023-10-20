using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace AcneTeledermatology.Models
{
    public class UserProfile
    {
        [Key]
        public int IDUserProfile { get; set; } // Primary Key

        [ForeignKey("User")]
        public string Id { get; set; } // Foreign Key

        [StringLength(255)]
        public string? ProfileImagePath { get; set; }

        public string UserEmail { get; set; }

        //public string Password { get; set; }
        ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfiles;

        ICollection<User> User;

        ICollection<UserDermRequest> UserDermRequests;
    }

}
