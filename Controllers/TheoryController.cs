using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.SqlClient;
using physics_webserver.Models;

namespace physics_webserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheoryController : ControllerBase
    {
        private readonly PhysicsDbContext _physicsDbContext;

        public TheoryController(PhysicsDbContext physicsDbContext)
        {
            _physicsDbContext = physicsDbContext;
        }

        [HttpGet]
        [Route("Theory")]
        public async Task<IActionResult> GetTheory()
        {
            try
            {
                List<Theory> listTheory = _physicsDbContext.Theories.ToList();
                if (listTheory != null)
                {
                    return Ok(listTheory);
                }
                return Ok("Данные отсутствуют");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
