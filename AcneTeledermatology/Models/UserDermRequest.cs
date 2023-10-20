using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    //public class UserDermRequest
    //{
    //    [Key]
    //    public int IDUserDermRequest { get; set; } // Primary Key

    //    //[Required]
    //    //[ForeignKey("UserProfile")]
    //    //public int IDUserProfile { get; set; } // Foreign Key to User, Unique, Not Null



    //    [ForeignKey("UserSupplementalAcneProfile")]
    //    public int? IDUserSupplementalAcneProfile { get; set; } // Foreign Key to UserSupplementalAcneProfile

    //    [Required]
    //    [ForeignKey("User")]
    //    public string Id { get; set; } // Foreign Key to User, Unique, Not Null

    //    public string Comments { get; set; }

    //    public DateTime DateCreated { get; set; }

    //    public bool hasDerm { get; set; }


    //     User User { get; set; }

    //    ICollection <UserSupplementalAcneProfile> UserSupplementalAcneProfile { get; set; }

    //     ICollection<User> Users { get; set; }


    //}
    public class UserDermRequest
    {
        [Key]
        public int IDUserDermRequest { get; set; } // Primary Key

        //[Required]
        //[ForeignKey("UserProfile")]
        //public int IDUserProfile { get; set; } // Foreign Key to User, Unique, Not Null

        [ForeignKey("UserSupplementalAcneProfile")]
        public int? IDUserSupplementalAcneProfile { get; set; } // Foreign Key to UserSupplementalAcneProfile

        [Required]
        [ForeignKey("User")]
        public string Id { get; set; } // Foreign Key to User, Unique, Not Null

        public string Comments { get; set; }

        public DateTime DateCreated { get; set; }

        public bool hasDerm { get; set; }


        ICollection<User> User;

        ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfile;

        ICollection<UserProfile> UserProfile;


    }
}