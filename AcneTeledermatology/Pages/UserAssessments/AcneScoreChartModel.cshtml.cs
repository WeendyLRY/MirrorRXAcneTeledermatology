using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using System.Security.Claims;

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class AcneScoreChartModel : PageModel
    {
        private readonly AcneTeleContext _context;

        public AcneScoreChartModel(AcneTeleContext context)
        {
            _context = context;
        }

        public string DateLabelsJson { get; set; }
        public string AcneScoresJson { get; set; }

        public void OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Query your database to retrieve data
            var data = _context.UserAssessments
                .Where(ua => ua.Id == userId) // Filter by user
                .OrderBy(ua => ua.DateCreated) // Order by date
                .Select(ua => new { ua.DateCreated, ua.Score })
                .ToList();

            // Separate the data into date labels and acne scores
            var dateLabels = data.Select(d => d.DateCreated.ToString("yyyy-MM-dd")).ToList();
            var acneScores = data.Select(d => d.Score).ToList();

            // Convert data to JSON
            DateLabelsJson = Newtonsoft.Json.JsonConvert.SerializeObject(dateLabels);
            AcneScoresJson = Newtonsoft.Json.JsonConvert.SerializeObject(acneScores);
        }
    }
}
