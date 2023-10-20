namespace AcneTeledermatology.Models
{
    public class PatientUserDermViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<UserProfile> UserProfiles { get; set; }
        public IEnumerable<UserSupplementalAcneProfile> UserSupplementalAcneProfiles { get; set; }

    }
}
