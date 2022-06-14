using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainDeparturesSchedule.Models;
using TrainDeparturesSchedule.Data;

namespace TrainDeparturesSchedule.Pages.DeparturesManagement
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TrainDeparture TrainDeparture { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            TrainDeparture = _db.TrainDepartures.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.TrainDepartures.Update(TrainDeparture);
                await _db.SaveChangesAsync();
                TempData["success"] = "Train Departure updated successfully";
                return RedirectToPage("IndexAdmin");
            }
            return Page();
        }
    }
}