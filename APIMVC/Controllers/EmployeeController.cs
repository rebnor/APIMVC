using APIMVC.Data;
using APIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employeeRepo;

        public EmployeeController(IEmployee employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public async Task<ActionResult> List()
        {
            var users = await employeeRepo.GetAllEmployees();
            return View(users);
        }

        
        public async Task<ActionResult> Contact(int? id)
        {
            var employee = await employeeRepo.GetEmployeeById(id);
            return View(employee);
        }

    }
}
