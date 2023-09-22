using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserAssessmentHistory
{
    [Key]
    public int IDUserAssessmentHistory { get; set; } // Primary Key

    [Required]
    [ForeignKey("UserAssessment")]
    public int IDUserAssessment { get; set; } // Foreign Key to UserAssessment, Unique, Not Null

    public DateTime DateCreated { get; set; }

    public int Score { get; set; }

    public string Ingredients { get; set; }

    public virtual UserAssessment UserAssessment { get; set; } // Navigation Property for UserAssessment
}
