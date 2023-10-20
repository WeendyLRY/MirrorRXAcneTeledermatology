using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcneTeledermatology.Models
{
    public class UserAssessmentHistory
    {
        [Key]
        public int IDUserAssessmentHistory { get; set; } // Primary Key

        [Required]
        [ForeignKey("UserAssessment")]
        public int IDUserAssessment { get; set; } // Foreign Key to UserAssessment, Unique, Not Null


         ICollection<UserAssessment> UserAssessment;
    }
}