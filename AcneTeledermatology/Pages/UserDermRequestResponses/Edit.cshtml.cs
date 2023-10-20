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

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class EditModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public EditModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserDermRequestResponse UserDermRequestResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserDermRequestResponses == null)
            {
                return NotFound();
            }

            var userdermrequestresponse =  await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);
            if (userdermrequestresponse == null)
            {
                return NotFound();
            }
            UserDermRequestResponse = userdermrequestresponse;
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

            _context.Attach(UserDermRequestResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDermRequestResponseExists(UserDermRequestResponse.IDUserDermRequestResponse))
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

        private bool UserDermRequestResponseExists(int id)
        {
          return (_context.UserDermRequestResponses?.Any(e => e.IDUserDermRequestResponse == id)).GetValueOrDefault();
        }
    }
}
