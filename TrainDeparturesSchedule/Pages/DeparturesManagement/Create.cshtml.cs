using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainDeparturesSchedule.Models;
using TrainDeparturesSchedule.Data;

namespace TrainDeparturesSchedule.Pages.DeparturesManagement
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public TrainDeparture TrainDeparture { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.TrainDepartures.AddAsync(TrainDeparture);
                await _db.SaveChangesAsync();
                TempData["success"] = "Train Departure created successfully";
                return RedirectToPage("IndexAdmin");
            }
            return Page();
        }
    }
}
