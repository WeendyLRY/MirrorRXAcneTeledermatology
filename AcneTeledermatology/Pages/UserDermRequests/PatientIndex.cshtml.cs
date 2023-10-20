using System.Collections.Generic;
using System.Linq;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AcneTeledermatology.Pages.UserDermRequests
{
    public class PatientIndexModel : PageModel
    {
        private readonly AcneTeleContext _context;

        public PatientIndexModel(AcneTeleContext context)
        {
            _context = context;
        }

        public List<UserDermRequest> UserDermRequests { get; set; }

        public IActionResult OnGet()
        {
            // Get the currently logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve UserDermRequests where UserID matches the logged-in user's ID
            UserDermRequests = _context.UserDermRequests
                .Where(u => u.Id == userId)
                .ToList();

            return Page();

        }
    }
}
