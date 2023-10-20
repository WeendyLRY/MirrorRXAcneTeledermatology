using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserSupplementalAcneProfiles
{
    public class DeleteModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DeleteModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserSupplementalAcneProfiles == null)
            {
                return NotFound();
            }
            var usersupplementalacneprofile = await _context.UserSupplementalAcneProfiles.FindAsync(id);

            if (usersupplementalacneprofile != null)
            {
                UserSupplementalAcneProfile = usersupplementalacneprofile;
                _context.UserSupplementalAcneProfiles.Remove(UserSupplementalAcneProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
