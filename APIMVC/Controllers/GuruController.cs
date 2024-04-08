using APIMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIMVC.Controllers
{
    public class GuruController : Controller
    {
        private readonly IGuru guruRepo;

        public GuruController(IGuru guruRepo) 
        {
            this.guruRepo = guruRepo;
        }
        public async Task<IActionResult> ListPartners()
        {
            var guruProviders = await guruRepo.GetPartners();
            return View(guruProviders);
        }
    }
}
