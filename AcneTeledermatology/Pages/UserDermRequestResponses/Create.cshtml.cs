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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class CreateModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;
        private readonly ILogger<CreateModel> _logger;


        public CreateModel(AcneTeledermatology.Data.AcneTeleContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger; // Inject the logger

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
                UserDermRequestResponse.IsCaseClosed = false;
                UserDermRequestResponse.IsPhysicalConsultationRequired = false;
                UserDermRequestResponse.IsVirtualConsultationPossible = true;
                UserDermRequestResponse.DermComment = "...";
                UserDermRequestResponse.DermPrescription = "Over-the-counter Prescriptions\n";

            }
            
            

            return Page();
           
        }

        [BindProperty]
        public UserDermRequestResponse UserDermRequestResponse { get; set; } = new UserDermRequestResponse();

        public UserDermRequest UserDermRequest { get; set; } = new UserDermRequest();

        


        public bool ShowField { get; set; }

        [BindProperty]
        public bool SkinDiscoloration { get; set; }

        [BindProperty]
        public bool PustulesAndRedness { get; set; }

        [BindProperty]
        public bool BlackheadsAndWhiteheads { get; set; }

        [BindProperty]
        public bool NodulesAndCysts { get; set; }


        [BindProperty]
        public bool ContinuePrescribedTreatment { get; set; }

        [BindProperty]
        public bool FollowUpForProgressCheck { get; set; }

        [BindProperty]
        public  bool AvoidSunExposure { get; set; }

        [BindProperty]
        public bool MaintainHealthyDietAndLifeStyle { get; set; }

        [BindProperty]
        public bool Diagnosis_acneVulgaris { get; set; }

        [BindProperty]
        public bool Diagnosis_contactDermatitis { get; set; }

        [BindProperty]
        public bool Diagnosis_fungalskin { get; set; }

        [BindProperty]
        public bool Diagnosis_rosacea { get; set; }

        [BindProperty]
        public bool Allergic { get; set; }

        [BindProperty]
        public bool SensitivitiesAndAllergies { get; set; }

        [BindProperty]
        public bool AdverseReactionToSkincare { get; set; }

        [BindProperty]
        public bool NodulesOrCyst { get; set; }

        [BindProperty]
        public bool Medications { get; set; }

        [BindProperty]
        public bool BenzoylPeroxide { get; set; }

        [BindProperty]
        public bool SalicylicAcid { get; set; }

        [BindProperty]
        public bool AHA { get; set; }

        [BindProperty]
        public bool Sulfur { get; set; }

        [BindProperty]
        public bool TopicalRetinoids { get; set; }



        public async Task<IActionResult> OnPostAsync()
        {
            // 3) UserDermRequestResponse.DermComment = Input.DermComment
            // 4) UserDermRequestResponse.DermPrescription = Input.DermPrescription
            // 5) UserDermRequestResponse.DermSuggestion = Input.DermSuggestion

            //if (!ModelState.IsValid || _context.UserDermRequestResponses == null || UserDermRequestResponse == null)
            //{
            //    return Page();
            //}


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

            if (_context.UserDermRequestResponses == null || UserDermRequestResponse == null)
            {
                return Page();
            }


            // Initialize DermComment as an empty string
            UserDermRequestResponse.DermComment = "\nSection 1: Aftercare Instructions\n";

            // Check the values of the individual properties and build DermComment
            if (ContinuePrescribedTreatment)
            {
                UserDermRequestResponse.DermComment += "Continue with the prescribed treatment as discussed during the consultation.\n";
            }
            if (FollowUpForProgressCheck)
            {
                UserDermRequestResponse.DermComment += "Follow up in 2 weeks for a progress check.\n";
            }
            if (AvoidSunExposure)
            {
                UserDermRequestResponse.DermComment += "Avoid prolonged sun exposure and use SPF [X] sunscreen.\n";
            }

            if (MaintainHealthyDietAndLifeStyle)
            {
                UserDermRequestResponse.DermComment += "Maintain healthy diet and lifeStyle\n";
            }


            UserDermRequestResponse.DermComment += "\nSection 2: Examination Findings\n";

            if (SkinDiscoloration)
            {
                UserDermRequestResponse.DermComment += "Detailed description of affected areas: Skin discoloration. \n ";
            }

            if (PustulesAndRedness)
            {
                UserDermRequestResponse.DermComment += "Observed pustules and redness around the affected area. \n";
            }

            if (BlackheadsAndWhiteheads)
            {
                UserDermRequestResponse.DermComment += "Noted the presence of blackheads and whiteheads. \n";
            }

            if (NodulesAndCysts)
            {
                UserDermRequestResponse.DermComment += "Noted the presence of nodules and cysts.\n ";
            }

            UserDermRequestResponse.DermComment += "\nSection 3: Diagnosis\n";

            if (Diagnosis_acneVulgaris)
            {
                UserDermRequestResponse.DermComment += "Provided a diagnosis of acne vulgaris.\n ";
            }

            if (Diagnosis_contactDermatitis)
            {
                UserDermRequestResponse.DermComment += "Diagnosed contact dermatitis caused by an allergen.\n ";
            }

            if (Diagnosis_fungalskin)
            {
                UserDermRequestResponse.DermComment += "Identified a fungal skin infection (tinea versicolor).\n ";
            }

            if (Diagnosis_rosacea)
            {
                UserDermRequestResponse.DermComment += "Determined the presence of rosacea.\n ";
            }

            UserDermRequestResponse.DermComment += "\nSection 4: Derm's Questions\n";

            if (Allergic)
            {
                UserDermRequestResponse.DermComment += "Are you allergic to anything (e.g., dust, seafood)?\n";
            }

            if (SensitivitiesAndAllergies)
            {
                UserDermRequestResponse.DermComment += "Do you have any known skin sensitivities or allergies?\n ";
            }

            if (AdverseReactionToSkincare)
            {
                UserDermRequestResponse.DermComment += "Have you experienced any adverse reactions to skincare products in the past? \n";
            }

            if (NodulesOrCyst)
            {
                UserDermRequestResponse.DermComment += "Have you used any specific products or treatments recently that might have impacted your skin? \n";
            }

            if (Medications)
            {
                UserDermRequestResponse.DermComment += "Are you currently taking any medications or using any topical treatments?\n ";
            }

            UserDermRequestResponse.DermPrescription += "\nOver-the-counter Prescriptions\n";


            if (BenzoylPeroxide)
            {
                UserDermRequestResponse.DermPrescription += "Benzoyl Peroxide, ";
            }

            if (SalicylicAcid)
            {
                UserDermRequestResponse.DermPrescription += "Salicylic Acid, ";
            }

            if (AHA)
            {
                UserDermRequestResponse.DermPrescription += "AHA, ";
            }

            if (Sulfur)
            {
                UserDermRequestResponse.DermPrescription += "Sulfur, ";
            }

            if (TopicalRetinoids)
            {
                UserDermRequestResponse.DermPrescription += "Topical Retinoids, ";
            }






            Console.WriteLine("derm comment before trimend = ", UserDermRequestResponse.DermComment);

            // Remove the trailing newline character, if any
            UserDermRequestResponse.DermComment = UserDermRequestResponse.DermComment.TrimEnd('\n');


            Console.WriteLine("derm comment after trimend = ", UserDermRequestResponse.DermComment);

            _context.UserDermRequestResponses.Add(UserDermRequestResponse);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving changes to the database: {ex.Message}");
                throw; // Optionally, rethrow the exception to see more details in the browser.
            }

            //await _context.SaveChangesAsync();

            // Retrieve IDUserDermRequest from query parameter
            string queryParamValue = HttpContext.Request.Query["idudr"];

            // Update UserDermRequest.HasDerm to true
            if (int.TryParse(queryParamValue, out int idudr))
            {
                var userDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(udr => udr.IDUserDermRequest == idudr);
                if (userDermRequest != null)
                {
                    userDermRequest.hasDerm = true;
                    userDermRequest.IDState = 2;
                    
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
            }

            string queryParamValueUID = HttpContext.Request.Query["uid"];

            return RedirectToPage("./Index", new { uid = queryParamValueUID, isDerm = "true", isViewUnattendedPatient=true });
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
