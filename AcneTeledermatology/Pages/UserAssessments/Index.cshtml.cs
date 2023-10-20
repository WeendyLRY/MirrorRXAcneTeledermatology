using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;

using X.PagedList;

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class IndexModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public IndexModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IList<UserAssessment> UserAssessment { get; set; } = default!;
        public string UserId { get; set; } = "";

        public async Task OnGetAsync(string uid = "")
        {
            if (!string.IsNullOrEmpty(uid))
            {
                // Filter user assessments by user ID
                UserAssessment = await _context.UserAssessments
                    .Where(ua => ua.Id == uid)
                    .ToListAsync();
            }
            else
            {
                UserAssessment = await _context.UserAssessments.ToListAsync();
            }

            UserId = uid;
        }
    }
}
