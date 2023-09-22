using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;

public class Derm
{
    [Key]
    public int IDDerm { get; set; } // Primary Key

    ICollection<UserDermRequestResponse> UserDermRequestResponses;

    ICollection<DermPatientHistory> DermPatientHistories;

    ICollection<DermProfile> DermProfile;
}

