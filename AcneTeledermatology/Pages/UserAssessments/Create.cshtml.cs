using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using Tensorflow;
using Tensorflow.Sessions;
using Tensorflow.Graphs;

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class CreateModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public CreateModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserAssessment UserAssessment { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; } // Property for handling image file upload


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find the maximum existing ID in the table
            int maxId = _context.UserAssessments.Max(u => u.IDUserAssessment);

            // Generate a new unique ID by incrementing the maximum ID
            UserAssessment.IDUserAssessment = maxId + 1;

            // Assign the current date and time to DateCreated
            UserAssessment.DateCreated = DateTime.Now;

            // Handle image file upload
            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memoryStream);
                    UserAssessment.image_to_test_path = memoryStream.ToArray(); // Store image data as byte array
                }
            }

            return RedirectToPage("./Index");
        }



    }
}
