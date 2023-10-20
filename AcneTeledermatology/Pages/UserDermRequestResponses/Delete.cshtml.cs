using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class DeleteModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DeleteModel(AcneTeledermatology.Data.AcneTeleContext context)
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

            var userdermrequestresponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);

            if (userdermrequestresponse == null)
            {
                return NotFound();
            }
            else 
            {
                UserDermRequestResponse = userdermrequestresponse;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserDermRequestResponses == null)
            {
                return NotFound();
            }
            var userdermrequestresponse = await _context.UserDermRequestResponses.FindAsync(id);

            if (userdermrequestresponse != null)
            {
                UserDermRequestResponse = userdermrequestresponse;
                _context.UserDermRequestResponses.Remove(UserDermRequestResponse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
