using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DermPatientHistory
{
    [Key]
    public int IDDermPatientHistory { get; set; } // Primary Key

    [Required]
    [ForeignKey("Derm")]
    public int IDDerm { get; set; } // Foreign Key to Derm, Unique, Not Null

    [ForeignKey("UserDermRequestResponse")]
    public int? IDUserDermRequestResponse { get; set; } // Foreign Key to UserDermRequestResponse

    public DateTime? DateCreated { get; set; }


    ICollection<Derm> Derm;

    ICollection<UserDermRequestResponse> UserDermRequestResponses;
}
