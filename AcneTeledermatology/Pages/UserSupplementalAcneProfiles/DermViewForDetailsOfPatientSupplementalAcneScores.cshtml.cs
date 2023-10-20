using AcneTeledermatology.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AcneTeledermatology.Pages.UserSupplementalAcneProfiles
{
    public class DermViewForDetailsOfPatientSupplementalAcneScoresModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DermViewForDetailsOfPatientSupplementalAcneScoresModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public UserSupplementalAcneProfile UserSupplementalAcneProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.UserSupplementalAcneProfiles == null)
            {
                return NotFound();
            }

            var usersupplementalacneprofile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(m => m.IDUserSupplementalAcneProfile == id);
            if (usersupplementalacneprofile == null)
            {
                return NotFound();
            }
            else
            {
                UserSupplementalAcneProfile = usersupplementalacneprofile;
            }
            return Page();
        }
    }
}
