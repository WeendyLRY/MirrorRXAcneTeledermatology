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
    public class IndexModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public IndexModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IList<UserDermRequestResponse> UserDermRequestResponse { get;set; } = default!;


        public async Task OnGetAsync(string uid, bool? isViewUnattendedPatient)
        {


            if (_context.UserDermRequestResponses != null)
            {
                // Get the IDDermProfile of the User based on the provided uid
                var dermProfile = await _context.DermProfiles.FirstOrDefaultAsync(u => u.Id == uid);
                if (dermProfile != null)
                {
                    int dermProfileId = dermProfile.IDDermProfile;

                    // Filter the UserDermRequestResponses where IDDermProfile matches the userDermProfileId
                    UserDermRequestResponse = await _context.UserDermRequestResponses
                        .Where(udr => udr.IDDermProfile == dermProfileId)
                        .ToListAsync();

                }
                else
                {
                    // Handle the case when user is not found
                    UserDermRequestResponse = new List<UserDermRequestResponse>();
                }


            }


        }

    }
}
