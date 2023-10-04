using AcneTeledermatology.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    public class UserAssessment
    {
        [Key]
        public int IDUserAssessment { get; set; } // Primary Key

        [Required]
        [ForeignKey("User")]
        public int IDUser { get; set; } // Foreign Key to User, Unique, Not Null

        public DateTime DateCreated { get; set; }

        public int? Score { get; set; }

        public string? Score_In_text { get; set; }

        public string Ingredients { get; set; }

        public byte[]? image_to_test_path { get; set; }

        public string? ImageToTestPath { get; set; }

        public string? ImageRelativePath { get; set; }

        ICollection<UserAssessmentHistory> UserAssessmentHistory;


        ICollection<User> User;

    }

    public class ApiResponse
    {
        [JsonProperty("acne-severity-name")]
        public string AcneSeverityName { get; set; }

        [JsonProperty("ingredients")]
        public List<string> Ingredients { get; set; }


        [JsonProperty("acne-score")]
        public int AcneScore { get; set; }

    }
}