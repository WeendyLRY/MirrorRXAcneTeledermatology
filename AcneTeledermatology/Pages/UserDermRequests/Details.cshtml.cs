using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using Tensorflow.Contexts;

namespace AcneTeledermatology.Pages.UserDermRequests
{
    public class DetailsModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DetailsModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

      public UserDermRequest UserDermRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserDermRequests == null)
            {
                return NotFound();
            }

            var userdermrequest = await _context.UserDermRequests.FirstOrDefaultAsync(m => m.IDUserDermRequest == id);
            if (userdermrequest == null)
            {
                return NotFound();
            }
            else
            {
                UserDermRequest = userdermrequest;
            }
            return Page();
        }

        // public async Task<IActionResult> OnGetAsync(int ?id)
        // {
        //     UserDermRequest = _context.UserDermRequests
        //.Include(udr => udr.UserSupplementalAcneProfile)
        //.Include(udr => udr.UserProfile)
        //.FirstOrDefault(udr => udr.IDUserDermRequest == id);

        //     if (UserDermRequest == null)
        //     {
        //         return NotFound();
        //     }

        // }
    }
}
