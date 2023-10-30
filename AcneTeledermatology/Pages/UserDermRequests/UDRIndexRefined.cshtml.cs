using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserDermRequests
{
    public class UDRIndexRefinedModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public UDRIndexRefinedModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IList<UserDermRequest> UserDermRequest { get; set; } = default!;

        public string user_to_see_derm_request { get; set; }

        public string userId { get; set; }

        public int IDSupplementalAcneProfile { get; set; }

        public async Task OnGetAsync(string PatientID, string uid)
        {





            // if dermView is set to true
            if (PatientID != null)
            {
                // display only when UserDermRequest.hasDerm = False
                UserDermRequest = await _context.UserDermRequests
                    .Where(udr => udr.Id == PatientID)  // Filter only when hasDerm is False
                    .ToListAsync();

                var userSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(m => m.Id == PatientID);

                IDSupplementalAcneProfile = userSupplementalAcneProfile.IDUserSupplementalAcneProfile;

                var userr = await _context.Users.FirstOrDefaultAsync(m => m.Id == PatientID);
                string theName = userr.UserName;

                if (theName != null) 
                {
                    user_to_see_derm_request = theName;
                    userId = PatientID;
                }

            }


            // if dermView is not true, make display for user wher user can only see Requests made by them. 
            // how to make this display only when 

            if (PatientID == null)
            {
                UserDermRequest = await _context.UserDermRequests
                    .Where(udr => udr.Id == uid)  // Filter by the specified uid
                    .ToListAsync();
            }

        }
    }
}
