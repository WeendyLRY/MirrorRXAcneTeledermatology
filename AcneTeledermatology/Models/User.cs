using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AcneTeledermatology.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        public int IDUser { get; set; }
        public DateTime DateCreated { get; set; }

        ICollection<UserDermRequest> UserDermRequests;
        ICollection<UserProfile> UserProfile;
        ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfiles;

        ICollection<UserAssessment> UserAssessments;
    }
}
