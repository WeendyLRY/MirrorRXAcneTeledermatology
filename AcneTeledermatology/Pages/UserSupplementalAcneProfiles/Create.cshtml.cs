using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using System.Security.Claims;

namespace AcneTeledermatology.Pages.UserSupplementalAcneProfiles
{
    public class CreateModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public CreateModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return Page();

        }

        [BindProperty]
        public UserSupplementalAcneProfile UserSupplementalAcneProfile { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.UserSupplementalAcneProfiles == null || UserSupplementalAcneProfile == null)
            //{
            //    return Page();
            //}

            //if (!ModelState.IsValid)
            //{
            //    foreach (var modelStateEntry in ModelState.Values)
            //    {
            //        foreach (var error in modelStateEntry.Errors)
            //        {
            //            Console.WriteLine(error.ErrorMessage);
            //        }
            //    }
            //    return Page();
            //}


            //var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (string.IsNullOrEmpty(userId))
            //{
            //    // Handle the case where userId is null or empty.
            //    // You might want to return an error message to the user or redirect to an error page.
            //    // In this example, we'll add a model error and return to the create page.
            //    ModelState.AddModelError(string.Empty, "User ID is missing or invalid.");
            //    return Page();
            //}
            //else
            //{
            //    UserSupplementalAcneProfile.Id = userId;
            //}



            _context.UserSupplementalAcneProfiles.Add(UserSupplementalAcneProfile);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
