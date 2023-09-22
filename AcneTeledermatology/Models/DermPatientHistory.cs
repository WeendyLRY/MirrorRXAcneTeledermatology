using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DermPatientHistory
{
    [Key]
    public int IDDermaPatientHistory { get; set; } // Primary Key

    [Required]
    [ForeignKey("Derm")]
    public int IDDerma { get; set; } // Foreign Key to Derm, Unique, Not Null

    [ForeignKey("UserDermRequestResponse")]
    public int? IDUserDermRequestResponse { get; set; } // Foreign Key to UserDermRequestResponse

    public DateTime? DateCreated { get; set; }

    public virtual Derm Derm { get; set; } // Navigation Property for Derm
    public virtual UserDermRequestResponse UserDermRequestResponse { get; set; } // Navigation Property for UserDermRequestResponse
}
