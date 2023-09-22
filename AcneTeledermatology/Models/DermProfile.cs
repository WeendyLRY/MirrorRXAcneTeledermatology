using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DermProfile
{
    [Key]
    public int IDDermaProfile { get; set; } // Primary Key

    [Required]
    [ForeignKey("Derm")]
    public int IDDerma { get; set; } // Foreign Key to Derm, Unique, Not Null

    public string DermName { get; set; }

    public string DermEmail { get; set; }

    public string DermPassword { get; set; }

    public DateTime DermDateCreated { get; set; }

    public virtual Derm Derm { get; set; } // Navigation Property for Derm
}
