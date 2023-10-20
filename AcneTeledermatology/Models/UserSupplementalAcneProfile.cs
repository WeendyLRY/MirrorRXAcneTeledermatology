using AcneTeledermatology.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    public class UserSupplementalAcneProfile
    {
        [Key]
        public int IDUserSupplementalAcneProfile { get; set; } // Primary Key

        [Required]
        [ForeignKey("User")]
        public string Id { get; set; } // Foreign Key to User, Unique, Not Null

        public virtual User User { get; set; } // Assuming User is the related entity

        [Range(1, 3)]
        public int SleepingPattern { get; set; } // Dropdown: 1-3

        [Range(1, 5)]
        public int SunblockHabit { get; set; } // Dropdown: 1-5

        [Range(1, 5)]
        public int DietHabit { get; set; } // Dropdown: 1-5

        public string SkincareProducts { get; set; } // Free text input

        [Range(1, 5)]
        public int SunExposure { get; set; } // Dropdown: 1-5

         ICollection<UserProfile> UserProfile { get; set; }
         ICollection<UserDermRequest> UserDermRequests { get; set; }
    }

}
