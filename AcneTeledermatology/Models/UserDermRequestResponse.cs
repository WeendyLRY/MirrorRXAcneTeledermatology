using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserDermRequestResponse
{
    [Key]
    public int IDUserDermRequestResponse { get; set; } // Primary Key

    [Required]
    [ForeignKey("Derm")]
    public int IDDerm { get; set; } // Foreign Key to Derm, Unique, Not Null

    [ForeignKey("UserDermRequest")]
    public int? IDUserDermRequest { get; set; } // Foreign Key to UserDermRequest

    public string DermComment { get; set; }

    public string DermPrescription { get; set; }

    public string DermSuggestion { get; set; }

    ICollection<Derm> Derm;

    ICollection<DermPatientHistory> DermPatientHistory;

}
