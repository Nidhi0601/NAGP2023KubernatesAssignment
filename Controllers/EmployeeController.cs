using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAGP2023KubernatesAssignment.Models;

namespace NAGP2023KubernatesAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly CoreDbContext _context;
        public EmployeeController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDetails
        [HttpGet(Name = "GetAllEmployees")]
        public async Task<IActionResult> Index()
        {
            Console.WriteLine("Inside GetAllEmployees");
            var result = await _context.EmployeeDetails.ToListAsync();
            return Ok(result);
        }
    }
}
