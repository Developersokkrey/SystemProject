using KEDI.Core.Repository;
using KSystemProject.References;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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
        readonly SecurityManager _securityManager;
        public UserAccountController(DataContext dataContext, SecurityManager securityManager)
        {
            _dataContext = dataContext;
            _securityManager = securityManager;
        }

        [HttpGet("userAccountForm")]
        public IActionResult UserAccountForm()
        {
            UserAccount userAccount = new();             
            return Ok(userAccount);
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
                    _securityManager.TryComputeHash(userAccount.Password, out string _hash, out string _salt);
                    var hash = $"{_hash}.{_salt}";
                    userAccount.PasswordHash = hash;
                    _dataContext.OUSR.Update(userAccount);
                    _dataContext.SaveChanges();
                    t.Commit();
                    ModelState.AddModelError("success", "Item save successfully.");
                    msg.Approve();                      
                }
                return Ok(await Task.FromResult(msg.Bind(ModelState)));
            }
        }

        private void ValidateSummary(UserAccount usacc)
        {
            if (string.IsNullOrWhiteSpace(usacc.Username) || usacc.Username.Length > 5)
            {
                ModelState.AddModelError("Username", "Username is required 5 charater !");
            }
            if (Regex.IsMatch(usacc.Username, "\\s+"))
            {
                ModelState.AddModelError("Username", "Username is not allow whitespace!");
            }
            if (string.IsNullOrWhiteSpace(usacc.Password) || usacc.Password.Length > 5)
            {
                ModelState.AddModelError("Password", "Password is required 5 charater !");
            }               
            if(usacc.Rule == 0)
            {
                ModelState.AddModelError("Rules", "Rules is required !");
            }
            if (usacc.Gender == 0)
            {
                ModelState.AddModelError("Gender", "Gender is required !");
            }
            if (usacc.Status == 0)
            {
                ModelState.AddModelError("Status", "Status is required !");
            }
        }
    }
}
