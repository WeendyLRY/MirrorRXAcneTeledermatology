using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.DermProfiles
{
    public class EditDermProfileModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public EditDermProfileModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DermProfile DermProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string uid)
        {
            var dermprofile = await _context.DermProfiles.FirstOrDefaultAsync(m => m.Id == uid);

            int id = dermprofile.IDDermProfile;

            if (id == null || _context.DermProfiles == null)
            {
                return NotFound();
            }

            
            if (dermprofile == null)
            {
                return NotFound();
            }
            DermProfile = dermprofile;

            DermProfile.Id = dermprofile.Id;


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DermProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DermProfileExists(DermProfile.IDDermProfile))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/UserHomeViewModels/DermIndex");
        }

        private bool DermProfileExists(int id)
        {
          return (_context.DermProfiles?.Any(e => e.IDDermProfile == id)).GetValueOrDefault();
        }
    }
}
