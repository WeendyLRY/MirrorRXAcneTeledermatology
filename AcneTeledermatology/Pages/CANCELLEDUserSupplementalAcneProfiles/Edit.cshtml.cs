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

namespace AcneTeledermatology.Pages.UserSupplementalAcneProfiles
{
    public class EditModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public EditModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserSupplementalAcneProfile UserSupplementalAcneProfile { get; set; } = default!;

        //modified from the original ongetasync to add the logic to redirect user to
        //create page if there are no records for the given user.
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid userIdGuid))
            {
                return NotFound();
            }

            // Find the user based on the provided GUID
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);


            if (user == null)
            {
                // Redirect to Create page if the user does not exist
                return RedirectToPage("./Create", new { id });
            }

            // Check if there are any records for the given user's Id (int)
            var hasRecords = await _context.UserSupplementalAcneProfiles
                .AnyAsync(m => m.Id == user.Id);

            if (!hasRecords)
            {
                // Redirect to Create page if no records exist
                return RedirectToPage("./Create", new { id });
            }

            // Fetch the UserSupplementalAcneProfile if it exists
            var usersupplementalacneprofile = await _context.UserSupplementalAcneProfiles
                .FirstOrDefaultAsync(m => m.Id == user.Id);

            if (usersupplementalacneprofile == null)
            {
                return NotFound();
            }

            UserSupplementalAcneProfile = usersupplementalacneprofile;
            return Page();
        }




        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.UserSupplementalAcneProfiles == null)
        //    {
        //        return NotFound();
        //    }

        //    var usersupplementalacneprofile =  await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(m => m.IDUserSupplementalAcneProfile == id);
        //    if (usersupplementalacneprofile == null)
        //    {
        //        return NotFound();
        //    }
        //    UserSupplementalAcneProfile = usersupplementalacneprofile;
        //    return Page();
        //}

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return Page();
        //    //}

        //    _context.Attach(UserSupplementalAcneProfile).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserSupplementalAcneProfileExists(UserSupplementalAcneProfile.IDUserSupplementalAcneProfile))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //another on post handler to handle the exception error.

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the ModelState is valid
            if (!ModelState.IsValid)
            {
                // If there are validation errors, return to the edit page with error messages
                return Page();
            }

            // Fetch the existing UserSupplementalAcneProfile record by ID
            var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles
                .FirstOrDefaultAsync(m => m.Id == UserSupplementalAcneProfile.Id);

            if (userSupplementalAcneProfile == null)
            {
                // Handle the case where the record doesn't exist (e.g., return to an error page)
                return NotFound();
            }

            // Update the UserSupplementalAcneProfile properties with the form data
            userSupplementalAcneProfile.SleepingPattern = UserSupplementalAcneProfile.SleepingPattern;
            userSupplementalAcneProfile.SunblockHabit = UserSupplementalAcneProfile.SunblockHabit;
            // Add similar lines for other properties

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Redirect to a success page or the details page
            return RedirectToPage("./Details", new { id = UserSupplementalAcneProfile.Id });
        }


        private bool UserSupplementalAcneProfileExists(int id)
        {
          return (_context.UserSupplementalAcneProfiles?.Any(e => e.IDUserSupplementalAcneProfile == id)).GetValueOrDefault();
        }
    }
}
