using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class DetailsModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DetailsModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

      public UserDermRequestResponse UserDermRequestResponse { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id, int?idudr)
        //{
        //    if (id == null || _context.UserDermRequestResponses == null)
        //    {
        //        return NotFound();
        //    }

        //    if (idudr != null)
        //    {
        //        // Use IDUserDermRequest from the query parameter to find the associated UserDermRequestResponse
        //        var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequest == idudr);
        //        if (userDermRequestResponse != null)
        //        {
        //            UserDermRequestResponse = userDermRequestResponse;
        //            return Page();
        //        }
        //    }

        //    var userdermrequestresponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);
        //    if (userdermrequestresponse == null)
        //    {
        //        return NotFound();
        //    }
        //    else 
        //    {
        //        UserDermRequestResponse = userdermrequestresponse;
        //    }
        //    return Page();
        //}

        public string DermName { get; set; }

        public bool ShowOptionsToLetPatientFollowUp { get; set; }
        public bool InformUserDermHaveNotRespondedYet { get; set; }
        public string reasonCaseClosed { get; set; }

        public bool isCaseClosed { get; set; }




        public async Task<IActionResult> OnGetAsync(int? idudr, int? id)
        {

            if (_context.UserDermRequestResponses == null && _context.UserDermRequests == null)
            {
                return NotFound();
            }





            if (idudr != null)
            {
                // Use IDUserDermRequest from the query parameter to find the associated UserDermRequestResponse
                var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequest == idudr);
                if (userDermRequestResponse != null)
                {
                    var idDermprofile = userDermRequestResponse.IDDermProfile;
                    var dermProfile = await _context.DermProfiles.FirstOrDefaultAsync(m => m.IDDermProfile == idDermprofile);
                    
                    if (dermProfile.DermName != null)
                    { 
                    DermName = dermProfile.DermName;
                    }

                    DermName = "Doctor House";

                    UserDermRequestResponse = userDermRequestResponse;
                    if (userDermRequestResponse.IsCaseClosed)
                    {
                        ShowOptionsToLetPatientFollowUp = false;
                        reasonCaseClosed = "Acne progress is already satisfactory level.";
                        isCaseClosed = true;
                    }                    

                    if (userDermRequestResponse.IsVirtualConsultationPossible == false || userDermRequestResponse.IsPhysicalConsultationRequired == true)
                    {
                        reasonCaseClosed = "Virtual consultation not possible. Require physical consultation.";
                        isCaseClosed = true;

                    }

                    if (userDermRequestResponse.DermComment == "haven't respond")
                    {
                        ShowOptionsToLetPatientFollowUp = false;
                        InformUserDermHaveNotRespondedYet = true;

                    }

                  

                    if (!userDermRequestResponse.IsCaseClosed && userDermRequestResponse.DermComment != "haven't respond")
                    {
                        ShowOptionsToLetPatientFollowUp = true;
                        
                    }

                    return Page();
                }
            }
            if (id != null)
            {
                // Use IDUserDermRequestResponse from the query parameter to find the associated UserDermRequestResponse
                var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);
                if (userDermRequestResponse != null)
                {
                    UserDermRequestResponse = userDermRequestResponse;
                    return Page();
                }
            }

            return NotFound();
        }


    }
}
