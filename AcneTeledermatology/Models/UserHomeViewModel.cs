using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AcneTeledermatology.Models
{
    public class UserHomeViewModel

    {     
        public IEnumerable <UserProfile> UserProfiles { get; set; }

        public IEnumerable <UserAssessment> UserAssessments { get; set; }

    }
}
