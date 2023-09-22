using System.ComponentModel.DataAnnotations;

namespace AcneTeledermatology.Models
{
    public class User
    {
        [Key]
        public int IDUser { get; set; }

        ICollection<UserDermRequest> UserDermRequests;
        ICollection<UserProfile> UserProfile;
        ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfiles;

        ICollection<UserAssessment> UserAssessments;
    }
}
