using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemProject.Model.UserAccount;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserAccount>> CreateUserAccount  (UserAccount userAccount )
        {
            return Ok(userAccount);
        }
    }
}
