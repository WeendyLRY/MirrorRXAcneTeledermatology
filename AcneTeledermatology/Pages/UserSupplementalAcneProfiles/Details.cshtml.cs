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
    public class DetailsModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DetailsModel(AcneTeledermatology.Data.AcneTeleContext context)
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
