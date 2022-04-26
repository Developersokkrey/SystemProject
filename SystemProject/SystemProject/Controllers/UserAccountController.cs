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

        [HttpPost("CreateUserAccount/userAccount")]
        public async Task<ActionResult> CreateUserAccount  ([FromBody] UserAccount userAccount )
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
                    ModelState.AddModelError("success", "Username save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                    msg.Approve();                      
                }
                return Ok(await Task.FromResult(msg.Bind(ModelState)));
            }
        }

        private void ValidateSummary(UserAccount usacc)
        {
            if (string.IsNullOrWhiteSpace(usacc.Username) || usacc.Username.Length < 5)
            {
                ModelState.AddModelError("Username", "Username is required 5 charater !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }
            if (Regex.IsMatch(usacc.Username?? "", "\\s+"))
            {
                ModelState.AddModelError("Username", "Username is not allow whitespace!/ឈ្មោះអ្នកប្រើប្រាស់មិនអនុញ្ញាតឱ្យដកឃ្លាទេ!");
            }
            if (string.IsNullOrWhiteSpace(usacc.Password) || usacc.Password.Length > 5)
            {
                ModelState.AddModelError("Password", "Password is required 5 charater !/ត្រូវការលេខសម្ងាត់ 5 តួអក្សរ!");
            }else if(Regex.IsMatch(usacc.Password ?? "", "\\s+"))
            {
                ModelState.AddModelError("Password", "Password is not allow whitespace!/ពាក្យ​សម្ងាត់​មិន​អនុញ្ញាត​ឱ្យ​ដកឃ្លា​ឡើយ!");
            }             
            if (string.IsNullOrWhiteSpace(usacc.ConfirmPassword) || usacc.Username.Length < 5)
            {
                ModelState.AddModelError("ConfirmPassword", "ConfirmPassword is required 5 charater !/បញ្ជាក់ពាក្យសម្ងាត់គឺទាមទារ 5 តួអក្សរ !");
            }
            else if (usacc.Password != usacc.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "ConfirmPassword not equal Password !/បញ្ជាក់​លេខ​សម្ងាត់​មិន​ស្មើ​លេខ​សម្ងាត់ !");
            }
            if (usacc.Rule == 0)
            {
                ModelState.AddModelError("Rules", "Rules is required select !/ប្រភេទអ្នកប្រើប្រាស់តម្រូវឱ្យជ្រើសរើស!");
            }
            if (usacc.Gender == 0)
            {
                ModelState.AddModelError("Gender", "Gender is required select !/ភេទគឺត្រូវការជ្រើសរើស!");
            }
            if (usacc.Status == 0)
            {
                ModelState.AddModelError("Status", "Status is required select !/ស្ថានភាពត្រូវបានទាមទារជ្រើសរើស!");
            }
        }
    }
}
