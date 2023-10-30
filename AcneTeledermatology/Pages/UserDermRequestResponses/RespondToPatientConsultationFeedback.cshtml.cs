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

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class RespondToPatientConsultationFeedbackModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public RespondToPatientConsultationFeedbackModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public bool ShowIsCaseClosedField {  get; set; }

        public bool ShowIsVirtualConsultationPossibleField { get; set; }

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
        public bool AvoidSunExposure { get; set; }

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


        [BindProperty]
        public 
        UserDermRequestResponse UserDermRequestResponse { get; set; } = default!;
        UserDermRequest UserDermRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            // Retrieve IDUserDermRequest from query parameter
            string queryParamValueForIDUserDermRequest = HttpContext.Request.Query["idDermRequestForReAssessment"];

            UserDermRequest userDermRequest = null;

            ShowIsVirtualConsultationPossibleField = true;

            if (int.TryParse(queryParamValueForIDUserDermRequest, out int idDermRequestForReAssessment))
            {
                userDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(udr => udr.IDUserDermRequest == idDermRequestForReAssessment);
                if (userDermRequest.IsAcneConditionHealing == true)
                {
                    ShowIsCaseClosedField = true;
                    ShowIsVirtualConsultationPossibleField = false;

                    

                }
            }

            if (_context.UserDermRequestResponses == null)
            {
                return NotFound();
            }

            if (id == null)
            {
                if (queryParamValueForIDUserDermRequest == null)
                {
                    return NotFound();
                }

                // use userDermRequest ID to find the IDUserDermRequestResponse
                var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(udrr => udrr.IDUserDermRequest == idDermRequestForReAssessment);

                id = userDermRequestResponse.IDUserDermRequestResponse;

            }

            var userdermrequestresponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);
            if (userdermrequestresponse == null)
            {
                return NotFound();
            }
            UserDermRequestResponse = userdermrequestresponse;


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
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

            UserDermRequestResponse.DermPrescription = "\nOver-the-counter Prescriptions\n";


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

            _context.Attach(UserDermRequestResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDermRequestResponseExists(UserDermRequestResponse.IDUserDermRequestResponse))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            string queryParamValueUID = HttpContext.Request.Query["uid"];


            return RedirectToPage("/UserDermRequestResponses/PendingandPostedConsultationView", new
            {
                uid = queryParamValueUID,
                isDerm = "true",
                checkHav = "see_all"
            });


        }

        private bool UserDermRequestResponseExists(int id)
        {
            return (_context.UserDermRequestResponses?.Any(e => e.IDUserDermRequestResponse == id)).GetValueOrDefault();
        }
    }
}
