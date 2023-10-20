using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AcneTeledermatology.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AcneTeledermatology.Data;
using System.Security.Claims;
using OneOf.Types;

namespace AcneTeledermatology.Pages
{
    public class DermCreateProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AcneTeleContext _dbContext;

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string UserEmail { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            //[Display(Name = "Profile Image")]
            //public IFormFile ProfileImage { get; set; }

            // Add properties for other profile information as needed
        }

        public DermCreateProfileModel(
     UserManager<User> userManager,
     SignInManager<User> signInManager,
     AcneTeleContext dbContext) // Add dbContext as a constructor parameter
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext; // Initialize _dbContext
        }

        public void OnGet()
        {
            // This is the initial page load logic
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Create a new user with the provided email and password
                var newUser = new User
                {
                    UserName = Input.UserEmail,
                    Email = Input.UserEmail,
                    isDerm = true,
                    isPatient = false,
                    Id = Guid.NewGuid().ToString(), // Set a unique Id
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(newUser, Input.Password);


                if (result.Succeeded)
                {
                    // Sign in the newly created user
                    await _signInManager.SignInAsync(newUser, isPersistent: false);

                    // Fetch the newly created user from the database to get its Id
                    var createdUser = await _userManager.FindByEmailAsync(Input.UserEmail);

                    // Create a new UserProfile with optional ProfileImagePath
                    var dermProfile = new DermProfile
                    {
                        Id = createdUser.Id, // Set the foreign key to the User table's Id
                        DermEmail = Input.UserEmail,
                        // ProfileImagePath is left as null if not provided
                    };

                    // Add the userProfile to the DbContext and save changes
                    _dbContext.DermProfiles.Add(dermProfile);
                    await _dbContext.SaveChangesAsync();

                    // Redirect to a success page or return a success message
                    return RedirectToPage("/ProfileCreated");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If ModelState is not valid or user creation fails, show errors and return to the same page
            return Page();
        }





    }
}
