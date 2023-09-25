using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class DeleteModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DeleteModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserAssessment UserAssessment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserAssessments == null)
            {
                return NotFound();
            }

            var userassessment = await _context.UserAssessments.FirstOrDefaultAsync(m => m.IDUserAssessment == id);

            if (userassessment == null)
            {
                return NotFound();
            }
            else 
            {
                UserAssessment = userassessment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserAssessments == null)
            {
                return NotFound();
            }
            var userassessment = await _context.UserAssessments.FindAsync(id);

            if (userassessment != null)
            {
                UserAssessment = userassessment;
                _context.UserAssessments.Remove(UserAssessment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
