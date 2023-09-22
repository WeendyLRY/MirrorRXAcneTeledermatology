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
    public class DeleteModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DeleteModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserProfile UserProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserProfiles == null)
            {
                return NotFound();
            }

            var userprofile = await _context.UserProfiles.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserProfiles == null)
            {
                return NotFound();
            }
            var userprofile = await _context.UserProfiles.FindAsync(id);

            if (userprofile != null)
            {
                UserProfile = userprofile;
                _context.UserProfiles.Remove(UserProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
