using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserDermRequest
{
    [Key]
    public int IDUserDermRequest { get; set; } // Primary Key

    [Required]
    [ForeignKey("User")]
    public int IDUser { get; set; } // Foreign Key to User, Unique, Not Null

    [ForeignKey("UserSupplementalAcneProfile")]
    public int? IDUserSupplementalAcneProfile { get; set; } // Foreign Key to UserSupplementalAcneProfile

    public string Comments { get; set; }


    ICollection<User> User;

    ICollection<UserSupplementalAcneProfile> UserSupplementalAcneProfile;


}
