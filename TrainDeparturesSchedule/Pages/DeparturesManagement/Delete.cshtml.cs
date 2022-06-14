using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainDeparturesSchedule.Models;
using TrainDeparturesSchedule.Data;

namespace TrainDeparturesSchedule.Pages.DeparturesManagement
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TrainDeparture TrainDeparture { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            TrainDeparture = _db.TrainDepartures.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var departureFromDb = _db.TrainDepartures.Find(TrainDeparture.Id);

            if (departureFromDb != null)
            {
                _db.TrainDepartures.Remove(departureFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Train Departure deleted successfully";
                return RedirectToPage("IndexAdmin");
            }

            return Page();
        }
    }
}
