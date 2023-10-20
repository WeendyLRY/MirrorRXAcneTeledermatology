using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserProfiles
{
    public class PatientProfileModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public PatientProfileModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

      public UserProfile UserProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id, string? uid)
        {
            if (_context.UserProfiles == null)
            {
                return NotFound();
            }

            if (uid != null)
            {
                var userprofile = await _context.UserProfiles.FirstOrDefaultAsync(m => m.Id == uid);
                if (userprofile == null)
                {
                    return NotFound();
                }
                else
                {
                    UserProfile = userprofile;
                }
                return Page();
            }

            if (id != null)
            {
                var userprofile = await _context.UserProfiles.FirstOrDefaultAsync(m => m.IDUserProfile == id);
                if (userprofile == null)
                {
                    return NotFound();
                }
                else
                {
                    UserProfile = userprofile;
                }
                return Page();
            }





            return NotFound();


        }
    }
}
