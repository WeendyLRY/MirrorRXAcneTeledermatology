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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace AcneTeledermatology.Pages.UserDermRequests
{
    public class CreateModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(AcneTeledermatology.Data.AcneTeleContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        //public IActionResult OnGet()
        //{
        //    // Initialize the DateCreated field of the UserDermRequest instance with the current date and time
        //    UserDermRequest = new UserDermRequest
        //    {
        //        DateCreated = DateTime.Now
        //    };

        //    return Page();
        //}

        //async so can populate before validate
        public async Task<IActionResult> OnGetAsync()
        {
            // Initialize the DateCreated field of the UserDermRequest instance with the current date and time
            UserDermRequest = new UserDermRequest
            {
                DateCreated = DateTime.Now,
                hasDerm = false
            };

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the corresponding UserProfile and UserSupplementalAcneProfile records
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == userId);
            var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(u => u.Id == userId);

            // Set UserDermRequest's IDUserProfile and IDUserSupplementalAcneProfile
           // UserDermRequest.IDUserProfile = userProfile != null ? userProfile.IDUserProfile : 0;
            UserDermRequest.IDUserSupplementalAcneProfile = userSupplementalAcneProfile != null ? userSupplementalAcneProfile.IDUserSupplementalAcneProfile : 0;

            // automatically set hasDerm to false
            UserDermRequest.hasDerm = false;

            return Page();
        }



        [BindProperty]
        public UserDermRequest UserDermRequest { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }




            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //// Find the corresponding UserProfile and UserSupplementalAcneProfile records
            //var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == userId);
            //var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(u => u.Id == userId);

            //// Set UserDermRequest's IDUserProfile and IDUserSupplementalAcneProfile
            //UserDermRequest.IDUserProfile = userProfile != null ? userProfile.IDUserProfile : 0;
            //UserDermRequest.IDUserSupplementalAcneProfile = userSupplementalAcneProfile != null ? userSupplementalAcneProfile.IDUserSupplementalAcneProfile : 0;



            _context.UserDermRequests.Add(UserDermRequest);
            await _context.SaveChangesAsync();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return RedirectToPage("./Index", new { uid = userId, isDerm = "false" });

        }

        //check validity later:

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // Find the corresponding UserProfile and UserSupplementalAcneProfile records
        //    var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == userId);
        //    var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(u => u.Id == userId);

        //    // Set UserDermRequest's IDUserProfile and IDUserSupplementalAcneProfile
        //    UserDermRequest.IDUserProfile = userProfile != null ? userProfile.IDUserProfile : 0;
        //    UserDermRequest.IDUserSupplementalAcneProfile = userSupplementalAcneProfile != null ? userSupplementalAcneProfile.IDUserSupplementalAcneProfile : 0;


        //    // Perform any additional model state validation here, after populating the fields
        //    if (!ModelState.IsValid)
        //    {
        //        foreach (var key in ModelState.Keys)
        //        {
        //            foreach (var error in ModelState[key].Errors)
        //            {
        //                Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
        //            }
        //        }
        //        return Page();
        //    }



        //    // If model state is valid, continue with the rest of the logic
        //    _context.UserDermRequests.Add(UserDermRequest);
        //    await _context.SaveChangesAsync();



        //    return RedirectToPage("./Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetIDUserProfile(string userId)
        //{
        //    // Log the incoming userId
        //    _logger.LogInformation($"Received request for userId: {userId}");

        //    var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == userId);

        //    if (userProfile != null)
        //    {
        //        int idUserProfile = userProfile.IDUserProfile;
        //        return new JsonResult(idUserProfile);
        //    }
        //    else
        //    {
        //        // Log a message if the userProfile is not found
        //        _logger.LogWarning($"UserProfile not found for userId: {userId}");
        //        return NotFound();
        //    }
        //}




        [HttpGet]
        public async Task<IActionResult> GetIDUserSupplementalAcneProfile(string userId)
        {
      
            var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(u => u.Id == userId);

            if (userSupplementalAcneProfile != null)
            {
                int idUserSupplementalAcneProfile = userSupplementalAcneProfile.IDUserSupplementalAcneProfile;
                return new JsonResult(userSupplementalAcneProfile.IDUserSupplementalAcneProfile);
            }
            else
            {
                return NotFound();
            }
        }



    }
}
