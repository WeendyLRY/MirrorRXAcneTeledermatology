using AcneTeledermatology.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcneTeledermatology.Models
{
    public class ConsultationState
    {
        public int IDState {  get; set; }
        public string state { get; set; }
    }
}
