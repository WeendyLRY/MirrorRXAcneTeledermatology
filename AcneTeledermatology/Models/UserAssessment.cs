using AcneTeledermatology.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserAssessment
{
    [Key]
    public int IDUserAssessment { get; set; } // Primary Key

    [Required]
    [ForeignKey("User")]
    public int IDUser { get; set; } // Foreign Key to User, Unique, Not Null

    public DateTime DateCreated { get; set; }

    public int Score { get; set; }

    public string Ingredients { get; set; }

    ICollection<UserAssessmentHistory> UserAssessmentHistories;


    ICollection<User> User;
}
