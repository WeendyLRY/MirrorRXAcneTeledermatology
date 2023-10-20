using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AcneTeledermatology.Pages
{
    [AllowAnonymous]
    public class DermUserLoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<UserLoginModel> _logger;
        private readonly AcneTeleContext _dbContext;


        public DermUserLoginModel(SignInManager<User> signInManager, ILogger<UserLoginModel> logger, AcneTeleContext dbContext)
        {
            _signInManager = signInManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync()
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // Get the list of external authentication providers
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberMe, lockoutOnFailure: true);

                //new function added for claims//
                var claims = new List<Claim>
                {
                    new Claim("isDerm", "1")
                };

                var identity = new ClaimsIdentity(claims, "custom");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);
                //end of new function added for claims//

                //just to test the error about claims//
                foreach (var claim in claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }
                //end of //just to test the error about claims////


                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var isReallyDerm = await IsLoggedInAsDerm(userId);

                    if (isReallyDerm)
                    {
                        //goto to the derm page if user is derm
                        return RedirectToPage("/UserHomeViewModels/DermIndex", new { userId = userId });
                    }

                    var loggedInWrongDirectory = "true";
                    //goto to the desired page
                    return RedirectToPage("/UserLoginViewModels/UserLogin", new { loggedInWrongDirectory });
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            


            // If we reach this point, something failed, redisplay the form
            return Page();
        }


        public async Task<bool> IsLoggedInAsDerm(string userId)
        {
            var user = await _dbContext.Users
            .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            bool isReallyDerm;

            if (user != null && user.isDerm)
            {
                isReallyDerm = true;

            }
            else
            {
                isReallyDerm = false;
            }

            return isReallyDerm;
        }

    }
}
