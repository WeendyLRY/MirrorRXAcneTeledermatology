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

using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace AcneTeledermatology.Pages.UserAssessments
{
    public class CreateModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;
        
        public string Message { get; set; }
        public CreateModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

    

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public UserAssessment UserAssessment { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.UserAssessments.Add(UserAssessment);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Edit");
        //}

        [BindProperty]
        public bool AutomaticCreate { get; set; } // Property to indicate automatic creation

        public IActionResult OnGet(bool automaticCreate = false)
        {
            if (automaticCreate)
            {
                // Create a new UserAssessment record
                var newAssessment = new UserAssessment
                {
                    IDUser = 1, // Hardcoded user ID
                    DateCreated = DateTime.Now,
                    Score = 0,
                    Ingredients = "undefined"
                };

                _context.UserAssessments.Add(newAssessment);
                _context.SaveChanges();

                // Redirect to the Edit page for the newly created UserAssessment
                return RedirectToPage("/UserAssessments/Edit", new { id = newAssessment.IDUserAssessment });
            }

            return Page();
        }





    }
}
