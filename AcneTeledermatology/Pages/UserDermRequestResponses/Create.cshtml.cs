using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class CreateModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public CreateModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                // Handle the case when uid is not provided
                return RedirectToPage("/Error");
            }

            // 1) UserDermRequestResponse.IDDermProfile = find current's user ID in the DermProfile table and get the IDDermProfile from that row
            int dermProfileId = await LoadDermProfileIdForUser(uid);

            // 2) UserDermRequestResponse.IDUserDermRequest = actually, before getting to UserAssessment page, the user navigated to this page from UserSupplementalAcneProfile.
            // Use the IDUserDermRequest from the UserDermRequest page that was accessed through here.
            if (HttpContext.Request.Query.ContainsKey("idudr"))
            {
                int idudr = int.Parse(HttpContext.Request.Query["idudr"]);
                UserDermRequestResponse.IDUserDermRequest = idudr;
                UserDermRequestResponse.IDDermProfile = dermProfileId;
            }

            return Page();
           
        }

        [BindProperty]
        public UserDermRequestResponse UserDermRequestResponse { get; set; } = new UserDermRequestResponse();

        public UserDermRequest UserDermRequest { get; set; } = new UserDermRequest();

        public async Task<IActionResult> OnPostAsync()
        {
            // 3) UserDermRequestResponse.DermComment = Input.DermComment
            // 4) UserDermRequestResponse.DermPrescription = Input.DermPrescription
            // 5) UserDermRequestResponse.DermSuggestion = Input.DermSuggestion

            if (!ModelState.IsValid || _context.UserDermRequestResponses == null || UserDermRequestResponse == null)
            {
                return Page();
            }

            _context.UserDermRequestResponses.Add(UserDermRequestResponse);
            await _context.SaveChangesAsync();

            // Retrieve IDUserDermRequest from query parameter
            string queryParamValue = HttpContext.Request.Query["idudr"];

            // Update UserDermRequest.HasDerm to true
            if (int.TryParse(queryParamValue, out int idudr))
            {
                var userDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(udr => udr.IDUserDermRequest == idudr);
                if (userDermRequest != null)
                {
                    userDermRequest.hasDerm = true;
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
            }

            string queryParamValueUID = HttpContext.Request.Query["uid"];

            return RedirectToPage("./Index", new { uid = queryParamValueUID, isDerm = "false" });
        }


        public async Task<int> LoadDermProfileIdForUser(string uid)
        {
            // Implement your logic to load the DermProfile ID based on the provided uid
            // Example:
            var dermProfile = await _context.DermProfiles.FirstOrDefaultAsync(d => d.Id == uid);
            if (dermProfile != null)
            {
                return dermProfile.IDDermProfile;
            }

            return 0; // Return a default value or handle the case when no DermProfile is found
        }
    }
}
