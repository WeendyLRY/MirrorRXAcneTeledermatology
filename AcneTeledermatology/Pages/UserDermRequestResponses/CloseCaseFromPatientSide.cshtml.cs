using AcneTeledermatology.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AcneTeledermatology.Pages.UserDermRequestResponses
{
    public class CloseCaseFromPatientSideModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public CloseCaseFromPatientSideModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserDermRequestResponse UserDermRequestResponse { get; set; }

        public bool IsCaseClosed { get; set; }

        public async Task OnGet(int? id)
        {
            if (id == null)
            {
                // Handle invalid ID
                RedirectToPage("/UserDermRequestResponses/Index");
            }

            UserDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);

            if (UserDermRequestResponse == null)
            {
                // Handle UserDermRequestResponse not found
                RedirectToPage("/UserDermRequestResponses/Index");
            }

            // Check if the case is already closed
            IsCaseClosed = UserDermRequestResponse.IsCaseClosed;
        }

        public async Task<IActionResult> OnPost(int? id)
        {

            UserDermRequestResponse = await _context.UserDermRequestResponses.FirstOrDefaultAsync(m => m.IDUserDermRequestResponse == id);

            if (UserDermRequestResponse == null)
            {
                // Handle null UserDermRequestResponse
                return RedirectToPage("/UserDermRequests/Index");
            }

            // Log the current value
            var oldValue = UserDermRequestResponse.IsCaseClosed;

            // Update the UserDermRequestResponse and set IsCaseClosed to true
            UserDermRequestResponse.IsCaseClosed = true;
            await _context.SaveChangesAsync();

            // Log the new value
            var newValue = UserDermRequestResponse.IsCaseClosed;

            // You can use a logging framework or display the values in the view
            Console.WriteLine("Old Value: " + oldValue);
            Console.WriteLine("New Value: " + newValue);
            Console.WriteLine("New Value: " + UserDermRequestResponse.IDUserDermRequestResponse);

            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isDerm = "false"; // You can set this to "false" or any other value you need

            return RedirectToPage("/UserDermRequest/Index", new { uid, isDerm });
        }




    }
}
