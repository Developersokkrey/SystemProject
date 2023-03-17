using KEDI.Core.Helpers.Enumerations;
using KSystemProject.References;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Company;
using SystemProject.Repository.ServicesClass;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ServicesInsertOrUpdate _servicesInsertOrUpdate;
        public CompanyController(DataContext dataContext, ServicesInsertOrUpdate servicesInsertOrUpdate)
        {
            _dataContext = dataContext;
            _servicesInsertOrUpdate = servicesInsertOrUpdate;
        }
        [HttpPost("CreateCurrency")]
        public async Task<IActionResult> CreateCurrency([FromBody] Currency currency)
        {
            ModelMessage msg = new();
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {                      
                    await _servicesInsertOrUpdate.InsertOrUpdateOCURE(currency);                                                               
                    await _servicesInsertOrUpdate.InsertOrUpdateEXRATE(currency.ID,true);
                    t.Commit();
                    ModelState.AddModelError("success", "Currency save successfully./ការរក្សាទុករូបិយប័ណ្ណដោយជោគជ័យ។");
                    msg.Approve();
                }
            }
            return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }
        [HttpPost("SaveRate/{exchange}")]
        public async Task<IActionResult> SaveRate([FromBody] List<ExchangeRate> exchange)
        {
            ModelMessage msg = new();
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in exchange)
                    {                         
                       await _servicesInsertOrUpdate.InsertOrUpdateEXRATE(item.CurrID,false);
                    }
                    t.Commit();
                    ModelState.AddModelError("success", "ExchangeRate save successfully./ការរក្សាទុករូបិយប័ណ្ណដោយជោគជ័យ។");
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
                    await _servicesInsertOrUpdate.InsertOrUpdateCOMP(comp, true);
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
            if(comp.SC == "0")
            {
                ModelState.AddModelError("SC", "System Currency is required select !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }
            if (comp.LC == "0")
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
            return Ok(companyModel);
        }
        [HttpGet("GetCompanyEmty")]
        public IActionResult GetCompanyEmty()
        {
            var companyModel = new
            {
                Currencies = from c in _dataContext.OCURE
                             select new Currency
                             {
                                 Value = c.ID,
                                 Title = c.Name,
                                 Symbol = c.Symbol,
                             },
                Company = new Company()
            };
            return Ok(companyModel);
        }
        [HttpGet("GetExchangeRate")]
        public IActionResult GetExchangeRate()
        {
            var exchangeRateModel = new
            {
                Company = from c in _dataContext.COMP
                          join s in _dataContext.OCURE on c.SC equals s.ID
                          select new Company { ID = c.ID, SCName = s.Name },
                Exchange = from c in _dataContext.EXRATE
                           join x in _dataContext.OCURE on c.CurrID equals x.ID
                               select new ExchangeRate
                               {
                                   ID = c.ID,
                                   CurrID = c.ID,
                                   Rate1 = c.Rate1,
                                   Rate2 = c.Rate2,
                                   CurrName = x.Name,
                               },                   
             }; 
            return Ok(exchangeRateModel);
        }
    }
}
