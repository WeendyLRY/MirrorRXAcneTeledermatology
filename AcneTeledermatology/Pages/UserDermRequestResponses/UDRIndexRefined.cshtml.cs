using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using static AcneTeledermatology.Pages.UserDermRequestResponses.UDRIndexRefinedModel;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class UDRIndexRefinedModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public UDRIndexRefinedModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        // Define a view model class
        public class UserDermViewModel
        {
            public string UserName { get; set; }
            public string RequestTitle { get; set; }
            public int UserDermRequestId { get; set; }

            public bool responded { get; set; }

            public DateTime UserDermRequestDate { get; set; }

            public string UserId { get; set; }

        }

        public IList<UserDermRequestResponse> UserDermRequestResponse { get; set; } = default!;
        public IList<UserDermRequest> UserDermRequest { get; set; } = default!;
        public IList<User> User { get; set; } = default!;

        public IList<UserDermViewModel> UserDermViewModels { get; set; } = default!;


        //weakness: didn't handle null value
        //public async Task OnGetAsync(string uid, bool? isViewUnattendedPatient)
        //{


        //    if (_context.UserDermRequestResponses != null)
        //    {
        //        // Get the IDDermProfile of the User based on the provided uid
        //        var dermProfile = await _context.DermProfiles.FirstOrDefaultAsync(u => u.Id == uid);
        //        if (dermProfile != null)
        //        {
        //            int dermProfileId = dermProfile.IDDermProfile;

        //            // Filter the UserDermRequestResponses where IDDermProfile matches the userDermProfileId
        //            UserDermRequestResponse = await _context.UserDermRequestResponses
        //                .Where(udr => udr.IDDermProfile == dermProfileId)
        //                .ToListAsync();

        //        }
        //        else
        //        {
        //            // Handle the case when user is not found
        //            UserDermRequestResponse = new List<UserDermRequestResponse>();
        //        }


        //    }


        // }

        public async Task OnGetAsync(string DermID, string PatientID , string? checkHav)
        {



            if (_context.UserDermRequestResponses != null)
            {
                // Get the IDDermProfile of the User based on the provided uid
                var dermProfile = await _context.DermProfiles.FirstOrDefaultAsync(u => u.Id == DermID);
                var idDermProfile = dermProfile.IDDermProfile;

                if (dermProfile != null)
                {
                    int dermProfileId = dermProfile.IDDermProfile;

                    // added code starts here for the related model data display

                    // retrieve all the IDUserDermRequestResponse for UserDermRequests that are associated 
                    var uddrCollectionOfIDUdr = await _context.UserDermRequestResponses
                        .Where(udr => udr.IDDermProfile == idDermProfile) 
                        .Select(udr => udr.IDUserDermRequest)
                        .ToListAsync();
                    
                    // retrieve all the userdermrequests for that patient
                    var userDermRequestCollection = await _context.UserDermRequests
                        .Where(udr => uddrCollectionOfIDUdr.Contains(udr.IDUserDermRequest) && udr.Id == PatientID)
                        .ToListAsync();

                    // get all the Id
                    var userIdList = userDermRequestCollection
                        .Select(udr => udr.Id)
                        .ToList();

                    // find all the user that has that Id
                    var userCollection = await _context.Users
                       .Where(udr => userIdList.Contains(udr.Id))
                       .ToListAsync();


                    // end of new code
                    // question: how to connect them all together 

                    // from User table: User.Username
                    // from UserDermRequest table: UserDermRequest.Title, UserDermRequest.Date
                    // from UserDermRequestResponse table: UserDermRequestResponse.IsFollowUp



                }
                else
                {
                    // Handle the case when user is not found
                    UserDermRequestResponse = new List<UserDermRequestResponse>();
                }
            }
            else
            {


                // Handle the case when _context.UserDermRequestResponses is null
                UserDermRequestResponse = new List<UserDermRequestResponse>();
                UserDermRequest = new List<UserDermRequest>();
                User = new List<User>();
                UserDermViewModels = new List<UserDermViewModel>();


            }
        }



    }
}
