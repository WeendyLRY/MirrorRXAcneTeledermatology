using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserSupplementalAcneProfiles
{
    public class IndexModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public IndexModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IList<UserSupplementalAcneProfile> UserSupplementalAcneProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserSupplementalAcneProfiles != null)
            {
                UserSupplementalAcneProfile = await _context.UserSupplementalAcneProfiles.ToListAsync();
            }
        }
    }
}
