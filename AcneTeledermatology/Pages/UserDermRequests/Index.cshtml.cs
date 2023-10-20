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
    public class IndexModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public IndexModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IList<UserDermRequest> UserDermRequest { get;set; } = default!;

        public async Task OnGetAsync(bool isDerm, string uid)
        {

            
            //if (dermView == true)
            //{

            //    // how to make this display only when UserDermRequest.hasDerm = False?

            //    if (_context.UserDermRequests != null)
            //    {
            //        UserDermRequest = await _context.UserDermRequests.ToListAsync();
            //    }

            //}

            // if dermView is set to true
            if (isDerm)
            {
                // display only when UserDermRequest.hasDerm = False
                UserDermRequest = await _context.UserDermRequests
                    .Where(udr => !udr.hasDerm)  // Filter only when hasDerm is False
                    .ToListAsync();
            }


            // if dermView is not true, make display for user wher user can only see Requests made by them. 
            // how to make this display only when 

            if (!isDerm && !string.IsNullOrEmpty(uid))
            {
                UserDermRequest = await _context.UserDermRequests
                    .Where(udr => udr.Id == uid)  // Filter by the specified uid
                    .ToListAsync();
            }

        }
    }
}
