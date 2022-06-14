using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainDeparturesSchedule.Models;
using TrainDeparturesSchedule.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TrainDeparturesSchedule.Pages.DeparturesManagement
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IEnumerable<TrainDeparture> TrainDepartures { get; set; }
        public IndexModel(ApplicationDbContext db, ILogger<PrivacyModel> logger, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<IActionResult> OnGet()
        {
            TrainDepartures = _db.TrainDepartures;

            var userName = _signInManager.Context.User.Identity.Name;

            if (userName != null && userName == "admin@gmail.com")
            {
                return RedirectToPage("IndexAdmin");
            }
            return Page();
        }
    }
}