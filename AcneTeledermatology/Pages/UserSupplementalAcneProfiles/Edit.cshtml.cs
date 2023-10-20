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
using System.Security.Claims;

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

        [Route("/UserSupplementalAcneProfiles/Edit")]
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Handle the case where id is null
            }

            // Check if UserSupplementalAcneProfiles collection is null (if needed)
            if (_context.UserSupplementalAcneProfiles == null)
            {
                return NotFound();
            }

            // Query the UserSupplementalAcneProfiles entity by id
            var usersupplementalacneprofile = await _context.UserSupplementalAcneProfiles
                .FirstOrDefaultAsync(m => m.IDUserSupplementalAcneProfile == id);

            if (usersupplementalacneprofile == null)
            {
                return NotFound(); // Handle the case where the entity is not found
            }

            // Set UserSupplementalAcneProfile property to the retrieved entity
            UserSupplementalAcneProfile = usersupplementalacneprofile;

            // Populate ViewData with Id values from _context.Users (if needed)
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.

        // original onpostasync:
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(UserSupplementalAcneProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSupplementalAcneProfileExists(UserSupplementalAcneProfile.IDUserSupplementalAcneProfile))
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

        //*******************************************8
        //*********************************************
        //the alternative onpost. something about modified.

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    // Find the entity you want to update by its primary key
        //    var existingEntity = await _context.UserSupplementalAcneProfiles
        //        .FindAsync(UserSupplementalAcneProfile.IDUserSupplementalAcneProfile);

        //    if (existingEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update the properties you want to change
        //    existingEntity.SleepingPattern = UserSupplementalAcneProfile.SleepingPattern;
        //    existingEntity.SunblockHabit = UserSupplementalAcneProfile.SunblockHabit;
        //    existingEntity.SkincareProducts = UserSupplementalAcneProfile.SkincareProducts;
        //    existingEntity.DietHabit = UserSupplementalAcneProfile.DietHabit;
        //    existingEntity.SunExposure = UserSupplementalAcneProfile.SunExposure;

        //    // Update other properties as needed

        //    try
        //    {
        //        //await _context.SaveChangesAsync();
        //        _context.SaveChanges();
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

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //// Check if the model state is valid (optional)
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return Page();
        //    //}

        //    // Attach the updated UserSupplementalAcneProfile to the context and mark it as modified
        //    _context.Attach(UserSupplementalAcneProfile).State = EntityState.Modified;

        //    try
        //    {
        //        // Save the changes to the database
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        // Handle concurrency conflicts if necessary
        //        if (!UserSupplementalAcneProfileExists(UserSupplementalAcneProfile.IDUserSupplementalAcneProfile))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    // Redirect to the index page after the update is successful
        //    return RedirectToPage("./Index");
        //}


        //change onpost async to stackoverflow tutorial
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    // Find the existing UserSupplementalAcneProfile by its ID
        //    var existingUserSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles
        //        .FindAsync(UserSupplementalAcneProfile.IDUserSupplementalAcneProfile);

        //    if (existingUserSupplementalAcneProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update the properties of the existing entity with the values from the model
        //    existingUserSupplementalAcneProfile.SleepingPattern = UserSupplementalAcneProfile.SleepingPattern;
        //    existingUserSupplementalAcneProfile.SunblockHabit = UserSupplementalAcneProfile.SunblockHabit;
        //    existingUserSupplementalAcneProfile.SkincareProducts = UserSupplementalAcneProfile.SkincareProducts;
        //    existingUserSupplementalAcneProfile.DietHabit = UserSupplementalAcneProfile.DietHabit;
        //    existingUserSupplementalAcneProfile.SunExposure = UserSupplementalAcneProfile.SunExposure;

        //    // Update other properties as needed

        //    try
        //    {
        //        // Save the changes to the database
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

        //the updated onpost to set for the User.Id foreign key
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    // Find the entity you want to update by its primary key
        //    var existingEntity = await _context.UserSupplementalAcneProfiles
        //        .FindAsync(UserSupplementalAcneProfile.IDUserSupplementalAcneProfile);

        //    if (existingEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    // Set the Id property to the user's Id
        //    UserSupplementalAcneProfile.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // Update the properties you want to change
        //    existingEntity.SleepingPattern = UserSupplementalAcneProfile.SleepingPattern;
        //    existingEntity.SunblockHabit = UserSupplementalAcneProfile.SunblockHabit;
        //    existingEntity.SkincareProducts = UserSupplementalAcneProfile.SkincareProducts;
        //    existingEntity.DietHabit = UserSupplementalAcneProfile.DietHabit;
        //    existingEntity.SunExposure = UserSupplementalAcneProfile.SunExposure;

        //    // Update other properties as needed

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




        private bool UserSupplementalAcneProfileExists(int id)
        {
          return (_context.UserSupplementalAcneProfiles?.Any(e => e.IDUserSupplementalAcneProfile == id)).GetValueOrDefault();
        }
    }
}
