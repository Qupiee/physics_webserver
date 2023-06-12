using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using physics_webserver.Models;
using System.Data.SqlClient;

namespace physics_webserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]
        public string register(User user)
        {
            string query = "insert into _User('UserRole', 'UserLogin', 'UserPassword') values('"+user.UserRole +"','"+ user.UserLogin +"','"+ user.UserPassword +"')";
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PhysicsConnection").ToString());
            SqlCommand command = new SqlCommand(query, connection);
            int i = command.ExecuteNonQuery();
            if (i > 0)
            {
                return "Пользователь зарегистрирован";
            }
            else
            {
                return "Ошибка ввода данных";
            }
        }
    }
}
