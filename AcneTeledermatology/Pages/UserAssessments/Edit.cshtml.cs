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

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class EditModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public EditModel(AcneTeledermatology.Data.AcneTeleContext context)
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

            var userassessment =  await _context.UserAssessments.FirstOrDefaultAsync(m => m.IDUserAssessment == id);
            if (userassessment == null)
            {
                return NotFound();
            }
            UserAssessment = userassessment;
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

            _context.Attach(UserAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAssessmentExists(UserAssessment.IDUserAssessment))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserAssessmentExists(int id)
        {
          return (_context.UserAssessments?.Any(e => e.IDUserAssessment == id)).GetValueOrDefault();
        }
    }
}
