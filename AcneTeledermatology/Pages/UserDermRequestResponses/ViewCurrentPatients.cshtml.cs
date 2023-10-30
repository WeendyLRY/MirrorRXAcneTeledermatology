using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using static AcneTeledermatology.Pages.UserDermRequestResponses.ViewCurrentPatientsModel;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class ViewCurrentPatientsModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public ViewCurrentPatientsModel(AcneTeledermatology.Data.AcneTeleContext context)
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

        public async Task OnGetAsync(string uid, bool isViewUnattendedPatient, string? checkHav)
        {



            if (_context.UserDermRequestResponses != null)
            {
                // Get the IDDermProfile of the User based on the provided uid
                var dermProfile = await _context.DermProfiles.FirstOrDefaultAsync(u => u.Id == uid);
                var idDermProfile = dermProfile.IDDermProfile;

                if (dermProfile != null)
                {
                    int dermProfileId = dermProfile.IDDermProfile;

                    // added code starts here for the related model data display

                    // retrieve all the IDUserDermRequestResponse for UserDermRequests that are associated 
                    // with the derm if the IDUserDermRequestResponse is "havent't respond".
                    var uddrCollectionOfIDUdr_haventrespond = await _context.UserDermRequestResponses
                        .Where(udr => udr.DermComment == "haven't respond")
                        .Where(udr => udr.IDDermProfile == idDermProfile)  // Added condition
                        .Select(udr => udr.IDUserDermRequest)
                        .ToListAsync();

                    // same but for all

                    var uddrCollectionOfIDUdr_seeall = await _context.UserDermRequestResponses
                        .Where(udr => udr.IDDermProfile == idDermProfile)  // Added condition
                        .Select(udr => udr.IDUserDermRequest)
                        .ToListAsync();

                    var uddrCollectionOfIDUdr = uddrCollectionOfIDUdr_haventrespond;

                    if (checkHav == "see_all")
                    {
                         uddrCollectionOfIDUdr = uddrCollectionOfIDUdr_seeall;
                    }

                    var userDermRequestCollection = await _context.UserDermRequests
                        .Where(udr => uddrCollectionOfIDUdr.Contains(udr.IDUserDermRequest))
                        .ToListAsync();

                    // get all the Id
                    var userIdList = userDermRequestCollection
                        .Select(udr => udr.Id)
                        .ToList();

                    // find all the user that has that Id
                    var userCollection = await _context.Users
                       .Where(udr => userIdList.Contains(udr.Id))
                       .ToListAsync();


                    User = await _context.Users
                          .Where(udr => udr.Id == "havent respond")
                          .ToListAsync();

                    // end of new code
                    // question: how to connect them all together 

                    var viewModelList = userDermRequestCollection
                      .Join(userCollection, udr => udr.Id, user => user.Id, (udr, user) => new UserDermViewModel
                      {
                          UserName = user.UserName,
                          RequestTitle = udr.Title,
                          UserDermRequestId = udr.IDUserDermRequest,
                          UserDermRequestDate = udr.DateCreated,
                          UserId = udr.Id
                      })
                      .ToList();

                    if (checkHav == "see_all")
                    {

                         viewModelList = userDermRequestCollection
                          .Join(userCollection, udr => udr.Id, user => user.Id, (udr, user) => new UserDermViewModel
                          {
                              UserName = user.UserName,
                              RequestTitle = udr.Title,
                              UserDermRequestId = udr.IDUserDermRequest,
                              UserDermRequestDate = udr.DateCreated,
                              UserId = udr.Id
                          })
                          .GroupBy(vm => vm.UserName)  // Group by UserName
                          .Select(group => group.OrderByDescending(vm => vm.UserDermRequestDate).First())  // Select the latest record from each group
                          .ToList();

                    }


                    UserDermViewModels = viewModelList; // Assign the populated list to the property


                 


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
