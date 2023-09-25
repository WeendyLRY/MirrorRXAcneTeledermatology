using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class IndexModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public IndexModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IList<UserAssessment> UserAssessment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserAssessments != null)
            {
                UserAssessment = await _context.UserAssessments.ToListAsync();
            }
        }
    }
}
