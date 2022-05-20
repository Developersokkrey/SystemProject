using KEDI.Core.Helpers.Enumerations;
using KSystemProject.References;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Company;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CompanyController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost("Currency/currency")]
        public async Task<IActionResult> Currency([FromBody] Currency currency)
        {
            ModelMessage msg = new();
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {   
                    _dataContext.OCURE.Update(currency);
                    _dataContext.SaveChanges();
                    t.Commit();
                    ModelState.AddModelError("success", "Currency save successfully./ការរក្សាទុករូបិយប័ណ្ណដោយជោគជ័យ។");
                    msg.Approve();
                }
            }
            return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }
        [HttpGet("getCurrency")]
        public IActionResult GetCurrency()
        {
            var currModel = new
            {
                Currencies = _dataContext.OCURE.ToList(),
                UserStatus = EnumHelper.ToDictionary<UserStatus>()
            };
            currModel.Currencies.ForEach(c => {
                c.StatusName = currModel.UserStatus[(int)c.Status];
            });
            var cur = _dataContext.OCURE;
            return Ok(currModel);
        } 
        [HttpPost("CreateCompany/{comp}")]
        public async Task<IActionResult> CreateCompany([FromBody] Company comp)
        {
            ValidateSummary(comp);
            ModelMessage msg = new();
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    _dataContext.COMP.Update(comp);
                    _dataContext.SaveChanges();
                    t.Commit();
                    ModelState.AddModelError("success", "Username save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                    msg.Approve();
                }
            }
            return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }
        private void ValidateSummary(Company comp)
        {
            if (string.IsNullOrWhiteSpace(comp.Name) || comp.Name.Length < 5)
            {
                ModelState.AddModelError("Name", "Username is required 5 charater !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }
            if(comp.SC == 0)
            {
                ModelState.AddModelError("SC", "System Currency is required select !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }
            if (comp.LC == 0)
            {
                ModelState.AddModelError("LC", "Local Currency is required select !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }
        }
        [HttpGet("GetCompany")]
        public IActionResult GetCompany()
        {
            var companyModel = new
            {
                Currencies = from c in _dataContext.OCURE
                             select new Currency {
                                 Value = c.ID,
                                 Title = c.Name,
                                 Symbol = c.Symbol,
                             },
                Company = _dataContext.COMP.FirstOrDefault(),
            };
            //companyModel.Currencies.ForEach(c => {
            //    c.StatusName = currModel.UserStatus[(int)c.Status];
            //});                  
            return Ok(companyModel);
        }
    }
}
