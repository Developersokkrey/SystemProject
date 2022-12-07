using KEDI.Core.Repository;
using KSystemProject.References;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.UserAccount;
using System.Linq;
using static SystemProject.Model.EnumService.EnumServices;
using KEDI.Core.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using SystemProject.Repository.ServicesClass;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        readonly SecurityManager _securityManager;
        private readonly IConfiguration iconfiguration;
        private readonly ServicesInsertOrUpdate _servicesInsertOrUpdate;
        public UserAccountController(DataContext dataContext, SecurityManager securityManager, IConfiguration configuration, ServicesInsertOrUpdate servicesInsertOrUpdate)
        {
            _dataContext = dataContext;
            _securityManager = securityManager;
            this.iconfiguration = configuration;
            _servicesInsertOrUpdate = servicesInsertOrUpdate;
        }
        [AllowAnonymous]
        [HttpGet("userAccountForm")]
        public IActionResult UserAccountForm(string usid)
        {
            if (usid == "0")
            {
                UserAccount userAccount = new();
                userAccount.Roles = _dataContext.ROLES.ToList();
                return Ok(userAccount);
            }
            else
            {
                var userAccount = _dataContext.OUSR.FirstOrDefault(w => w.ID == usid) ?? new UserAccount();
                userAccount.Roles = _dataContext.ROLES.ToList();
                return Ok(userAccount);
            }
        }
        [AllowAnonymous]
        [HttpPost("CreateUserAccount/userAccount")]
        public async Task<ActionResult> CreateUserAccount([FromBody] UserAccount userAccount)
        {
            ValidateSummary(userAccount);
            ModelMessage msg = new();
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    await _servicesInsertOrUpdate.InsertOrUpdateOCURE(userAccount);
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
            if (Regex.IsMatch(usacc.Username ?? "", "\\s+"))
            {
                ModelState.AddModelError("Username", "Username is not allow whitespace!/ឈ្មោះអ្នកប្រើប្រាស់មិនអនុញ្ញាតឱ្យដកឃ្លាទេ!");
            }
            if (string.IsNullOrWhiteSpace(usacc.Password) || usacc.Password.Length < 5)
            {
                ModelState.AddModelError("Password", "Password is required 5 charater !/ត្រូវការលេខសម្ងាត់ 5 តួអក្សរ!");
            }
            else if (Regex.IsMatch(usacc.Password ?? "", "\\s+"))
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
            if (usacc.RoleID == "0")
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
            if (usacc.BranID == "0")
            {
                ModelState.AddModelError("BranID", "Branch is required select !/ស្ថានភាពត្រូវបានទាមទារជ្រើសរើស!");
            }
        }
        [HttpGet("getUserAccount")]
        public IActionResult GetUserAccount()
        {
            var userobjs = from u in _dataContext.OUSR
                           join b in _dataContext.BRAN on u.BranID equals b.ID
                           join r in _dataContext.ROLES on u.RoleID equals r.ID
                           select new
                           {
                               ID = u.ID,
                               UserName = u.Username,
                               Rule = r.Name,
                               Gender = ((Genders)u.Gender).ToString(),
                               Status = ((UserStatus)u.Status).ToString(),
                               Branch = b.Name,
                           };
            return Ok(userobjs);
        }
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signIn)
        {
            ModelMessage msg = new();
            if (string.IsNullOrWhiteSpace(signIn.Username) || string.IsNullOrWhiteSpace(signIn.Password))
            {
                ModelState.AddModelError("Username", "Username or Password is invalid !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
                msg.Reject();
            }
            else
            {
                ModelState.AddModelError("success", "Username save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                var user = _dataContext.OUSR.FirstOrDefault(u => u.Username.ToLower() == signIn.Username.ToLower()) ?? new UserAccount();
                bool isVerified = false;
                if (!String.IsNullOrEmpty(user.ID))
                {
                    isVerified = false;
                    string[] tokens = user.PasswordHash.Split('.');
                    string hash = tokens[0];
                    string salt = tokens[1];
                    isVerified = HashSecurity.Verify(signIn.Password, hash, salt);
                }
                if (isVerified)
                {
                    UserMap userMap = new();
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                      {
                        new Claim(ClaimTypes.Name, signIn.Username)
                      }),
                        Expires = DateTime.UtcNow.AddHours(6),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    //add userMap
                    var access = from usp in _dataContext.USERPRIVI.Where(w => w.Enable == true && w.UserID == user.ID)
                                 join func in _dataContext.FUNCTI on usp.FuncID equals func.ID
                                 select func.Code;
                    userMap.Username = user.Username;
                    userMap.UserID = user.ID;
                    userMap.Access = access.ToArray();
                    userMap.Token = tokenHandler.WriteToken(token);
                    userMap.Avatar = "https://file.iviewui.com/dist/a0e88e83800f138b94d2414621bd9704.png";
                    msg.AddItem(userMap, "userMap");
                    msg.Approve();
                }
                else
                {
                    ModelState.AddModelError("success", "Username or password incorrect !/រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                }
            }
            return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }

    }
}
