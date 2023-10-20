using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    public class Derm 
    {
        [Key]
        public int IDDerm { get; set; } // Primary Key


        public ICollection<UserDermRequestResponse> UserDermRequestResponses;

        public ICollection<DermPatientHistory> DermPatientHistories;

        public ICollection<DermProfile> DermProfile;
    }

}