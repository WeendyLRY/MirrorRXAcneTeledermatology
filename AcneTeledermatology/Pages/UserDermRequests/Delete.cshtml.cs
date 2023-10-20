using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserDermRequests
{
    public class DeleteModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DeleteModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserDermRequest UserDermRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserDermRequests == null)
            {
                return NotFound();
            }

            var userdermrequest = await _context.UserDermRequests.FirstOrDefaultAsync(m => m.IDUserDermRequest == id);

            if (userdermrequest == null)
            {
                return NotFound();
            }
            else 
            {
                UserDermRequest = userdermrequest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserDermRequests == null)
            {
                return NotFound();
            }
            var userdermrequest = await _context.UserDermRequests.FindAsync(id);

            if (userdermrequest != null)
            {
                UserDermRequest = userdermrequest;
                _context.UserDermRequests.Remove(UserDermRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
