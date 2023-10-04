using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AcneTeledermatology.Models
{
    public class Derm : IdentityUser<int>
    {
        [Key]
        public int IDDerm { get; set; } // Primary Key

        ICollection<UserDermRequestResponse> UserDermRequestResponses;

        ICollection<DermPatientHistory> DermPatientHistories;

        ICollection<DermProfile> DermProfile;
    }

}