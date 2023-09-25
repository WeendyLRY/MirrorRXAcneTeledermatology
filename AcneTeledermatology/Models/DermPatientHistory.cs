using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcneTeledermatology.Models
{
    public class DermPatientHistory
    {
        [Key]
        public int IDDermPatientHistory { get; set; } // Primary Key


        [ForeignKey("UserDermRequestResponse")]
        public int? IDUserDermRequestResponse { get; set; } // Foreign Key to UserDermRequestResponse

        public DateTime? DateCreated { get; set; }


        ICollection<Derm> Derm;

        ICollection<UserDermRequestResponse> UserDermRequestResponses;
    }
}