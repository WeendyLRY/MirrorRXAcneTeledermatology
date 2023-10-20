using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    public class DermProfile
    {
        [Key]
        public int IDDermProfile { get; set; } // Primary Key

        

        //[Required]
        //[ForeignKey("Derm")]
        //public int IDDerm { get; set; } // Foreign Key to Derm, Unique, Not Null

        [ForeignKey("User")]
        public string Id { get; set; } // Foreign Key

        public string? DermName { get; set; }

        public string? DermEmail { get; set; }

        public DateTime? DermDateCreated { get; set; }

        ICollection<Derm> Derm;
        ICollection<User> User;

        ICollection<UserDermRequestResponse> UserDermRequestResponses;
    }
}