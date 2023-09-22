using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserSupplementalAcneProfile
{
    [Key]
    public int IDUserSupplementalAcneProfile { get; set; } // Primary Key

    [Required]
    [ForeignKey("User")]
    public int IDUser { get; set; } // Foreign Key to User, Unique, Not Null

    [Range(1, 3)]
    public int SleepingPattern { get; set; } // Dropdown: 1-3

    [Range(1, 3)]
    public int SunblockHabit { get; set; } // Dropdown: 1-3

    [Range(1, 3)]
    public int DietHabit { get; set; } // Dropdown: 1-3

    public string SkincareProducts { get; set; } // Free text input

    [Range(1, 3)]
    public int SunExposure { get; set; } // Dropdown: 1-3


    ICollection<User> User;
}
