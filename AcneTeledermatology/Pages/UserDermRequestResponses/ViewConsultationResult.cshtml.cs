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
    public class ViewConsultationResultModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public ViewConsultationResultModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public UserDermRequestResponse UserDermRequestResponse { get; set; } = default!;

        public UserDermRequest UserDermRequest { get; set; } = default!;


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

        //public string RequestTitle { get; set; }
        //public string RequestComment { get; set; }

        //public string DermatologigistComment { get; set; }
        //public string DermatologigistSuggestion { get; set; }
        //public string DermatologigistPrescription {  get; set; }    

        public bool ShowOptionsToLetPatientFollowUp { get; set; }
        public bool InformUserDermHaveNotRespondedYet { get; set; }
        public string reasonCaseClosed { get; set; }

        public bool isCaseClosed { get; set; }

        public bool ShowRespondButton { get; set; }

        public bool ShowCaseClosedButtonMessage { get; set; }

        public string UserName { get; set; }

        public string DermUserID { get; set; }

        public string? PatientUserID { get; set; }



        public async Task<IActionResult> OnGetAsync(int? idudr, string? dermUserID, string? patientUserID)
        {

            if (_context.UserDermRequestResponses == null && _context.UserDermRequests == null)
            {
                return NotFound();
            }

            if (idudr != null && dermUserID != null)
            {
                // Use IDUserDermRequest from the query parameter to find the associated UserDermRequestResponse
                var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequest == idudr);
                if (userDermRequestResponse != null)
                {
                    DermUserID = dermUserID;

                     UserDermRequestResponse = userDermRequestResponse;

                    if (userDermRequestResponse.DermComment == "haven't respond")
                    {
                        ShowRespondButton = true;
                        InformUserDermHaveNotRespondedYet = true;

                    }

                    if (!userDermRequestResponse.IsCaseClosed && userDermRequestResponse.DermComment != "haven't respond")
                    {
                        ShowCaseClosedButtonMessage = true;
                    }

                    var userDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(m => m.IDUserDermRequest == idudr);

                    UserDermRequest = userDermRequest;

                    var userId = UserDermRequest.Id;

                    var theUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                    UserName = theUser.UserName;



                    return Page();
                }
            }

            if (idudr != null && patientUserID != null)
            {
                // Use IDUserDermRequest from the query parameter to find the associated UserDermRequestResponse
                var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequest == idudr);
                if (userDermRequestResponse != null)
                {
                    PatientUserID = patientUserID;

                    UserDermRequestResponse = userDermRequestResponse;

                    if (userDermRequestResponse.DermComment == "haven't respond")
                    {
                        ShowRespondButton = true;
                        InformUserDermHaveNotRespondedYet = true;
                        ShowOptionsToLetPatientFollowUp = false;

                    }

                    if (!userDermRequestResponse.IsCaseClosed && userDermRequestResponse.DermComment != "haven't respond")
                    {
                        ShowOptionsToLetPatientFollowUp = true;

                    }

                    var userDermRequest = await _context.UserDermRequests.FirstOrDefaultAsync(m => m.IDUserDermRequest == idudr);

                    UserDermRequest = userDermRequest;

                    var userId = UserDermRequest.Id;

                    var theUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                    UserName = theUser.UserName;



                    return Page();
                }
            }

            //if (id != null)
            //{
            //    // Use IDUserDermRequestResponse from the query parameter to find the associated UserDermRequestResponse
            //    var userDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);
            //    if (userDermRequestResponse != null)
            //    {
            //        UserDermRequestResponse = userDermRequestResponse;
            //        return Page();
            //    }
            //}

            return NotFound();
        }


    }
}
