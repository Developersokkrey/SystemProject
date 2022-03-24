using KSystemProject.References;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.UserAccount;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserAccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        public async Task<ActionResult> CreateUserAccount  (UserAccount userAccount )
        {   
            ValidateSummary(userAccount);
            ModelMessage msg = new();
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    t.Commit();
                    ModelState.AddModelError("success", "Item save successfully.");
                    msg.Approve();                      
                }
                return Ok(await Task.FromResult(msg.Bind(ModelState)));
            }
        }

        private void ValidateSummary(dynamic usacc)
        {
            if (string.IsNullOrEmpty(usacc.Username))
            {
                ModelState.AddModelError("Username", "Username is required !");
            }
            if (string.IsNullOrEmpty(usacc.Password))
            {
                ModelState.AddModelError("Password", "Password is required !");
            }               
            if (string.IsNullOrEmpty(usacc.Company))
            {
                ModelState.AddModelError("Company", "Password is company !");             
                
            }             
        }
    }
}
