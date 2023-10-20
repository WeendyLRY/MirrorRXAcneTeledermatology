using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AcneTeledermatology.Models
{
    //public class User : IdentityUser<string>
    //{ 
    //   // [Key]
    //    //public int IDUser { get; set; }

    //    public string? CustomTag { get; set; }
    //    public DateTime DateCreated { get; set; }

    //    public bool isPatient { get; set; }

    //    public bool isDerm { get; set; }


    //    ICollection<UserDermRequest> UserDermRequests;

    //    ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfile;

    //    ICollection<UserProfile> UserProfiles;
    //    ICollection<UserAssessment> UserAssessments;
    //}
    public class User : IdentityUser<string>
    {
        // [Key]
        //public int IDUser { get; set; }

        public string? CustomTag { get; set; }
        public DateTime DateCreated { get; set; }



        [Required]
        [StringLength(255)]

        public bool isPatient { get; set; }

        public bool isDerm { get; set; }


         ICollection<UserDermRequest> UserDermRequests;

         ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfiles;

          ICollection<UserProfile> UserProfile;

         ICollection<UserAssessment> UserAssessments;
    }
}
