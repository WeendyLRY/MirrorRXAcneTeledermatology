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
using Tensorflow;

namespace AcneTeledermatology.Pages.UserDermRequests
{
    public class AcneOKModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;
        private readonly ILogger<AcneOKModel> _logger;

        public AcneOKModel(AcneTeledermatology.Data.AcneTeleContext context, ILogger<AcneOKModel> logger)
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

        public bool ShowWarningPopup { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {


            // check if the idr that leads to this page has a value of "HasFollowUp.False" first. 

            // find the previous UserDermRequest that leads to this page by the queryparameter idqueryparameter

            // Retrieve IDUserDermRequest from query parameter
            string queryParamValueUDR = HttpContext.Request.Query["idudr"];

            // check if  UserDermRequest.HasFollowUp is true
            if (int.TryParse(queryParamValueUDR, out int idudr))
            {
                var previousUserDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(udr => udr.IDUserDermRequest == idudr);
                if (previousUserDermRequest.HasFollowUp == true)
                {
                    ShowWarningPopup = true;
                    var theuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    return RedirectToPage("./Index", new { uid = theuserId, isDerm = "false", message = "tryingToSubmitFollowUpToRequestWithFollowUp" });

                }
            }



            // Initialize the DateCreated field of the UserDermRequest instance with the current date and time
            UserDermRequest = new UserDermRequest
            {
                DateCreated = DateTime.Now,
                hasDerm = true,
                IDState = 4,
                IsFollowUp = true,
                IsAcneConditionHealing = true,
                IsInConsultation = true,
                HasFollowUp = false
            };


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            // Find the corresponding UserProfile and UserSupplementalAcneProfile records
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == userId);
            var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(u => u.Id == userId);

            // Set UserDermRequest's IDUserProfile and IDUserSupplementalAcneProfile
            // UserDermRequest.IDUserProfile = userProfile != null ? userProfile.IDUserProfile : 0;
            UserDermRequest.IDUserSupplementalAcneProfile = userSupplementalAcneProfile != null ? userSupplementalAcneProfile.IDUserSupplementalAcneProfile : 0;

            //// automatically set hasDerm to false
            //UserDermRequest.hasDerm = false;

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

            // find the previous UserDermRequest that leads to this page by the queryparameter idqueryparameter

            // Retrieve IDUserDermRequest from query parameter
            string queryParamValue = HttpContext.Request.Query["idudr"];

            // Update UserDermRequest.HasFollowUp to true
            if (int.TryParse(queryParamValue, out int idudr))
            {
                var userDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(udr => udr.IDUserDermRequest == idudr);
                if (userDermRequest != null)
                {
                    userDermRequest.HasFollowUp = true;
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // auto initialize the fields of the user derm response instance

            // retrieve the UserDermRequestResponse first

            var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(udr => udr.IDUserDermRequest == idudr);

            // then get the IDDermProfile
            var idDermProfile = userDermRequestResponse.IDDermProfile;



            // create a new UserDermRequestResponse for the corresponding patient
            UserDermRequestResponse newResponse = new UserDermRequestResponse
            {
                IDDermProfile = idDermProfile,
                IDUserDermRequest = UserDermRequest.IDUserDermRequest,
                DermComment = "haven't respond",
                DermPrescription = "haven't respond",
                DermSuggestion = "haven't respond",
                IsCaseClosed = false,
                IsPhysicalConsultationRequired = false,
                IsVirtualConsultationPossible = true


        };

            _context.UserDermRequestResponses.Add(newResponse);
            await _context.SaveChangesAsync();


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
