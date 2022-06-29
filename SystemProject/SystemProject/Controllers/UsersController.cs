using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SystemProject.Models.Jwt;
using SystemProject.Models.Jwt.Repository;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }
        [HttpGet]
        [Route("userlist")]
        public List<string> Get()
        {
            var users = new List<string>
            {
                "Satinder Singh",
                "Amit Sarna",
                "Davin Jon"
            };
            return users;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
