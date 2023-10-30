using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using Syncfusion;

namespace AcneTeledermatology.Pages.UserSupplementalAcneProfiles
{

    public static class MappingHelper
    {
        // Define dictionaries for property mappings
        public static Dictionary<int, string> SleepingPatternMapping = new Dictionary<int, string>
            {
                { 1, "Less than 5 hours of regular sleep" },
                { 2, "Less than 8 hours of regular sleep" },
                { 3, "A regular sleep of at least 8 hours every day" },
            };

        public static Dictionary<int, string> SunblockHabitMapping = new Dictionary<int, string>

            {
                { 1, "Doesn't wear sunscreen regularly when going outdoor" },
                { 2, "Wears sunscreen sometimes when going outdoor" },
                { 3, "Wears sunscreen regularly" },
                { 4, "Wears sunscreen regularly and sometimes touch up sunscreen throughout the day" },
                { 5, "Regular sunscreen application when going outdoor and frequently touch up sunscreen" },
            };

        public static Dictionary<int, string> DietHabitMapping = new Dictionary<int, string>
            {
                { 1, "Junk food on a regular basis, barely drink water" },
                { 2, "Fast food and junk food less than 3 times a week, less than 4 glasses of water" },
                { 3, "Balanced diet sometimes but regular hydration every day (8 glasses of water)" },
                { 4, "Balanced diet at least 5 times a week, at least 6 glasses of water every day" },
                { 5, "Balanced diet almost every day and at least 8 glasses of water every day" },
            };

        public static Dictionary<int, string> SunExposureMapping = new Dictionary<int, string>
            {
                { 1, "Getting at least 8 hours of sun every day" },
                { 2, "Getting about 4 hours to 7 hours of sunlight almost every day" },
                { 3, "Getting about 4 hours to 5 hours of sunlight at least 4 days a week" },
                { 4, "Getting about less than 5 hours of sunlight, maximum 4 days" },
                { 5, "Less than 3 hours of sunlight, maximum 3 days" },
            };




        // Define similar dictionaries for other properties (DietHabit, SunExposure, etc.)

    }


    public class DetailsModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public DetailsModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }


      public UserSupplementalAcneProfile UserSupplementalAcneProfile { get; set; } = default!;


        public string GetStringForProperty(int value, Dictionary<int, string> propertyMapping)
        {
            if (propertyMapping.ContainsKey(value))
            {
                return propertyMapping[value];
            }

            return "Unknown";
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.UserSupplementalAcneProfiles == null)
            {
                return NotFound();
            }

            var usersupplementalacneprofile = await _context.UserSupplementalAcneProfiles.FirstOrDefaultAsync(m => m.IDUserSupplementalAcneProfile == id);
            if (usersupplementalacneprofile == null)
            {
                return NotFound();
            }
            else 
            {
                UserSupplementalAcneProfile = usersupplementalacneprofile;
            }
            return Page();
        }
    }
}
