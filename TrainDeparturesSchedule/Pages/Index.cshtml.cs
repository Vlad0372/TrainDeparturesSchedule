using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainDeparturesSchedule.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(ILogger<PrivacyModel> logger, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var userName = _signInManager.Context.User.Identity.Name;

            if (userName != null)
            {
                if(userName == "admin@gmail.com")
                {
                    return RedirectToPage("DeparturesManagement/IndexAdmin");
                }
                return RedirectToPage("DeparturesManagement/Index");
            }
            return Page();
        }
    }
}