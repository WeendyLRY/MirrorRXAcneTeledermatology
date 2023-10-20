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
                    UserDermRequestResponse = userDermRequestResponse;
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
