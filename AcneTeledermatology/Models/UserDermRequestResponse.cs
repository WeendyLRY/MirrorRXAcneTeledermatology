using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    public class UserDermRequestResponse
    {
        [Key]
        public int IDUserDermRequestResponse { get; set; } // Primary Key

        [Required]
        [ForeignKey("DermProfile")]
        public int IDDermProfile { get; set; } // Foreign Key to Derm, Unique, Not Null

        [ForeignKey("UserDermRequest")]
        public int? IDUserDermRequest { get; set; } // Foreign Key to UserDermRequest

        public string DermComment { get; set; }

        public string DermPrescription { get; set; }

        public string DermSuggestion { get; set; }

        public bool IsVirtualConsultationPossible { get; set; }

        public bool IsPhysicalConsultationRequired { get; set; }

        public bool IsCaseClosed { get; set; }

        



         ICollection<DermPatientHistory> DermPatientHistory;

         DermProfile DermProfile;

         ICollection<UserDermRequest> UserDermRequest;
        //internal bool ContinuePrescribedTreatment;


        
        
        
    }
}